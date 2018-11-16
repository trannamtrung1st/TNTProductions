using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IProductItemRepository : IBaseRepository<ProductItem, int>
	{
	}
	
	public partial class ProductItemRepository : BaseRepository<ProductItem, int>, IProductItemRepository
	{
		public ProductItemRepository() : base()
		{
		}
		
		public ProductItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductItem Add(ProductItem entity)
		{
			
			entity = context.ProductItems.Add(entity);
			return entity;
		}
		
		public override ProductItem Remove(ProductItem entity)
		{
			context.ProductItems.Attach(entity);
			entity = context.ProductItems.Remove(entity);
			return entity;
		}
		
		public override ProductItem Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductItems.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<ProductItem> RemoveIf(Expression<Func<ProductItem, bool>> expr)
		{
			return context.ProductItems.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<ProductItem> RemoveRange(IEnumerable<ProductItem> list)
		{
			return context.ProductItems.RemoveRange(list);
		}
		
		public override ProductItem FindById(int key)
		{
			var entity = context.ProductItems.FirstOrDefault(
				e => e.ItemID == key);
			return entity;
		}
		
		public override ProductItem FindActiveById(int key)
		{
			var entity = context.ProductItems.FirstOrDefault(
				e => e.ItemID == key);
			return entity;
		}
		
		public override async Task<ProductItem> FindByIdAsync(int key)
		{
			var entity = await context.ProductItems.FirstOrDefaultAsync(
				e => e.ItemID == key);
			return entity;
		}
		
		public override async Task<ProductItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductItems.FirstOrDefaultAsync(
				e => e.ItemID == key);
			return entity;
		}
		
		public override ProductItem FindByIdInclude<TProperty>(int key, params Expression<Func<ProductItem, TProperty>>[] members)
		{
			IQueryable<ProductItem> dbSet = context.ProductItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ItemID == key);
		}
		
		public override async Task<ProductItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductItem, TProperty>>[] members)
		{
			IQueryable<ProductItem> dbSet = context.ProductItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ItemID == key);
		}
		
		public override ProductItem Activate(ProductItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItem Deactivate(ProductItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ProductItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ProductItem> GetActive()
		{
			return context.ProductItems;
		}
		
		public override IQueryable<ProductItem> GetActive(Expression<Func<ProductItem, bool>> expr)
		{
			return context.ProductItems.Where(expr);
		}
		
		public override ProductItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductItem FirstOrDefault(Expression<Func<ProductItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductItem> FirstOrDefaultAsync(Expression<Func<ProductItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductItem SingleOrDefault(Expression<Func<ProductItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductItem> SingleOrDefaultAsync(Expression<Func<ProductItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductItem Update(ProductItem entity)
		{
			entity = context.ProductItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
