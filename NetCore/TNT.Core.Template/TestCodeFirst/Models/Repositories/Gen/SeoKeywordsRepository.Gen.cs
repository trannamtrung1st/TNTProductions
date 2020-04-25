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
	public partial interface ISeoKeywordsRepository : IBaseRepository<SeoKeywords, string>
	{
	}
	
	public partial class SeoKeywordsRepository : BaseRepository<SeoKeywords, string>, ISeoKeywordsRepository
	{
		public SeoKeywordsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override SeoKeywords FindById(string key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Value == key);
			return entity;
		}
		
		public override async Task<SeoKeywords> FindByIdAsync(string key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Value == key);
			return entity;
		}
		
		public override EntityEntry<SeoKeywords> Remove(string key)
		{
			var entity = new SeoKeywords { Value = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<SeoKeywords> RemoveIf(Expression<Func<SeoKeywords, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new SeoKeywords { Value = o.Value }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM SeoKeywords");
			return result;
		}
		
		#endregion
	}
}
