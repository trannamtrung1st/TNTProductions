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
	public partial interface IIdentityUserRepository : IBaseRepository<IdentityUser, string>
	{
	}
	
	public partial class IdentityUserRepository : BaseRepository<IdentityUser, string>, IIdentityUserRepository
	{
		public IdentityUserRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override IdentityUser FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<IdentityUser> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<IdentityUser> Remove(string key)
		{
			var entity = new IdentityUser { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<IdentityUser> RemoveIf(Expression<Func<IdentityUser, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new IdentityUser { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM IdentityUser");
			return result;
		}
		
		#endregion
	}
}
