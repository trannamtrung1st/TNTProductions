using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestCodeFirst.Models.Repositories
{
	public partial interface IAspNetUserRolesRepository : IBaseRepository<AspNetUserRoles, AspNetUserRolesPK>
	{
	}
	
	public partial class AspNetUserRolesRepository : BaseRepository<AspNetUserRoles, AspNetUserRolesPK>, IAspNetUserRolesRepository
	{
		public AspNetUserRolesRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUserRoles FindById(AspNetUserRolesPK key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
			return entity;
		}
		
		public override async Task<AspNetUserRoles> FindByIdAsync(AspNetUserRolesPK key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.UserId == key.UserId && e.RoleId == key.RoleId);
			return entity;
		}
		
		public override EntityEntry<AspNetUserRoles> Remove(AspNetUserRolesPK key)
		{
			var entity = new AspNetUserRoles { UserId = key.UserId,RoleId = key.RoleId };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<AspNetUserRoles> RemoveIf(Expression<Func<AspNetUserRoles, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new AspNetUserRoles { UserId = o.UserId,RoleId = o.RoleId }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlCommandAsync("DELETE FROM AspNetUserRoles");
			return result;
		}
		
		#endregion
	}
}
