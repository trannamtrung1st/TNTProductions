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
	public partial interface IProductImageCollectionItemMappingRepository : IBaseRepository<ProductImageCollectionItemMapping, int>
	{
	}
	
	public partial class ProductImageCollectionItemMappingRepository : BaseRepository<ProductImageCollectionItemMapping, int>, IProductImageCollectionItemMappingRepository
	{
		public ProductImageCollectionItemMappingRepository() : base()
		{
		}
		
		public ProductImageCollectionItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductImageCollectionItemMapping Add(ProductImageCollectionItemMapping entity)
		{
			entity.Active = true;
			entity = context.ProductImageCollectionItemMappings.Add(entity);
			return entity;
		}
		
		public override ProductImageCollectionItemMapping Remove(ProductImageCollectionItemMapping entity)
		{
			context.ProductImageCollectionItemMappings.Attach(entity);
			entity = context.ProductImageCollectionItemMappings.Remove(entity);
			return entity;
		}
		
		public override ProductImageCollectionItemMapping Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductImageCollectionItemMappings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<ProductImageCollectionItemMapping> RemoveIf(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return context.ProductImageCollectionItemMappings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<ProductImageCollectionItemMapping> RemoveRange(IEnumerable<ProductImageCollectionItemMapping> list)
		{
			return context.ProductImageCollectionItemMappings.RemoveRange(list);
		}
		
		public override ProductImageCollectionItemMapping FindById(int key)
		{
			var entity = context.ProductImageCollectionItemMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductImageCollectionItemMapping FindActiveById(int key)
		{
			var entity = context.ProductImageCollectionItemMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductImageCollectionItemMapping> FindByIdAsync(int key)
		{
			var entity = await context.ProductImageCollectionItemMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductImageCollectionItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductImageCollectionItemMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductImageCollectionItemMapping FindByIdInclude<TProperty>(int key, params Expression<Func<ProductImageCollectionItemMapping, TProperty>>[] members)
		{
			IQueryable<ProductImageCollectionItemMapping> dbSet = context.ProductImageCollectionItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ProductImageCollectionItemMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductImageCollectionItemMapping, TProperty>>[] members)
		{
			IQueryable<ProductImageCollectionItemMapping> dbSet = context.ProductImageCollectionItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ProductImageCollectionItemMapping Activate(ProductImageCollectionItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductImageCollectionItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductImageCollectionItemMapping Deactivate(ProductImageCollectionItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductImageCollectionItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductImageCollectionItemMapping> GetActive()
		{
			return context.ProductImageCollectionItemMappings.Where(e => e.Active);
		}
		
		public override IQueryable<ProductImageCollectionItemMapping> GetActive(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return context.ProductImageCollectionItemMappings.Where(e => e.Active).Where(expr);
		}
		
		public override ProductImageCollectionItemMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductImageCollectionItemMapping FirstOrDefault(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductImageCollectionItemMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductImageCollectionItemMapping> FirstOrDefaultAsync(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductImageCollectionItemMapping SingleOrDefault(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductImageCollectionItemMapping> SingleOrDefaultAsync(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductImageCollectionItemMapping Update(ProductImageCollectionItemMapping entity)
		{
			entity = context.ProductImageCollectionItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
