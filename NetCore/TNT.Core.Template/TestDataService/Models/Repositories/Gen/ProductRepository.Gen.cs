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
	public partial interface IProductRepository : IBaseRepository<Product, int>
	{
	}
	
	public partial class ProductRepository : BaseRepository<Product, int>, IProductRepository
	{
		public ProductRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Product FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Product> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<Product> Remove(int key)
		{
			var entity = new Product { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<Product> RemoveIf(Expression<Func<Product, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new Product { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM Product");
			return result;
		}
		
		#endregion
	}
}
