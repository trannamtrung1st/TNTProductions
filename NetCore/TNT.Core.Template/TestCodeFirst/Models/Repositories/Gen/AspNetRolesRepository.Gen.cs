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
	public partial interface IAspNetRolesRepository : IBaseRepository<AspNetRoles, string>
	{
	}
	
	public partial class AspNetRolesRepository : BaseRepository<AspNetRoles, string>, IAspNetRolesRepository
	{
		public AspNetRolesRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetRoles FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRoles> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<AspNetRoles> Remove(string key)
		{
			var entity = new AspNetRoles { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<AspNetRoles> RemoveIf(Expression<Func<AspNetRoles, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new AspNetRoles { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM AspNetRoles");
			return result;
		}
		
		#endregion
	}
}
