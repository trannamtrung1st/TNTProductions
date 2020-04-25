using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeFirst.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;

namespace TestCodeFirst.Models.Repositories
{
	public partial interface IIdentityRoleRepository : IBaseRepository<IdentityRole, string>
	{
	}
	
	public partial class IdentityRoleRepository : BaseRepository<IdentityRole, string>, IIdentityRoleRepository
	{
		public IdentityRoleRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityRole FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<IdentityRole> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<IdentityRole> Remove(string key)
		{
			var entity = new IdentityRole { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityRole> RemoveIf(Expression<Func<IdentityRole, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityRole { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityRole");
			return result;
		}
		
		#endregion
	}
}
