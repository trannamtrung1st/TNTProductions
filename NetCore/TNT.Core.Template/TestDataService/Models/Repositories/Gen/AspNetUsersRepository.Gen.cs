using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataService.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestDataService.Models.Repositories
{
	public partial interface IAspNetUsersRepository : IBaseRepository<AspNetUsers, string>
	{
	}
	
	public partial class AspNetUsersRepository : BaseRepository<AspNetUsers, string>, IAspNetUsersRepository
	{
		public AspNetUsersRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUsers FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUsers> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<AspNetUsers> Remove(string key)
		{
			var entity = new AspNetUsers { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<AspNetUsers> RemoveIf(Expression<Func<AspNetUsers, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new AspNetUsers { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlCommandAsync("DELETE FROM AspNetUsers");
			return result;
		}
		
		#endregion
	}
}
