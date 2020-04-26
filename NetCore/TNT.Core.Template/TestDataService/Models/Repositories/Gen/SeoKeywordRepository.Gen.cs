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
	public partial interface ISeoKeywordRepository : IBaseRepository<SeoKeyword, int>
	{
	}
	
	public partial class SeoKeywordRepository : BaseRepository<SeoKeyword, int>, ISeoKeywordRepository
	{
		public SeoKeywordRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override SeoKeyword FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SeoKeyword> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<SeoKeyword> Remove(int key)
		{
			var entity = new SeoKeyword { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<SeoKeyword> RemoveIf(Expression<Func<SeoKeyword, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new SeoKeyword { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM SeoKeyword");
			return result;
		}
		
		#endregion
	}
}
