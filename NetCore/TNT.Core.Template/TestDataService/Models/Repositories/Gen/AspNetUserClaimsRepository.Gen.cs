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
	public partial interface IAspNetUserClaimsRepository : IBaseRepository<AspNetUserClaims, int>
	{
	}
	
	public partial class AspNetUserClaimsRepository : BaseRepository<AspNetUserClaims, int>, IAspNetUserClaimsRepository
	{
		public AspNetUserClaimsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override AspNetUserClaims FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUserClaims> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<AspNetUserClaims> Remove(int key)
		{
			var entity = new AspNetUserClaims { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<AspNetUserClaims> RemoveIf(Expression<Func<AspNetUserClaims, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new AspNetUserClaims { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlCommandAsync("DELETE FROM AspNetUserClaims");
			return result;
		}
		
		#endregion
	}
}
