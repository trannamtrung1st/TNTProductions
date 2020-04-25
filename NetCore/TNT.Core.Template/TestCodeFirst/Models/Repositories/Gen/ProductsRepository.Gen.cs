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
	public partial interface IProductsRepository : IBaseRepository<Products, int>
	{
	}
	
	public partial class ProductsRepository : BaseRepository<Products, int>, IProductsRepository
	{
		public ProductsRepository(DbContext context) : base(context)
		{
		}
		
		#region CRUD area
		public override Products FindById(int key)
		{
			var entity = QuerySet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Products> FindByIdAsync(int key)
		{
			var entity = await QuerySet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override EntityEntry<Products> Remove(int key)
		{
			var entity = new Products { Id = key };
			return dbSet.Remove(entity);
		}
		
		public override IEnumerable<Products> RemoveIf(Expression<Func<Products, bool>> expr)
		{
			var list = dbSet.Where(expr).Select(o => new Products { Id = o.Id }).ToList();
			dbSet.RemoveRange(list);
			return list;
		}
		
		//Default DELETE command, override if there's any exception
		public override async Task<int> SqlRemoveAllAsync()
		{
			var result = await context.Database.ExecuteSqlRawAsync("DELETE FROM Products");
			return result;
		}
		
		#endregion
	}
}
