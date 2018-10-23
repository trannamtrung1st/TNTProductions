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
	public partial interface IProductCollectionItemMappingRepository : IBaseRepository<ProductCollectionItemMapping, int>
	{
	}
	
	public partial class ProductCollectionItemMappingRepository : BaseRepository<ProductCollectionItemMapping, int>, IProductCollectionItemMappingRepository
	{
		public ProductCollectionItemMappingRepository() : base()
		{
		}
		
		public ProductCollectionItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductCollectionItemMapping Add(ProductCollectionItemMapping entity)
		{
			entity.Active = true;
			entity = context.ProductCollectionItemMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> AddAsync(ProductCollectionItemMapping entity)
		{
			entity.Active = true;
			entity = context.ProductCollectionItemMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCollectionItemMapping Delete(ProductCollectionItemMapping entity)
		{
			context.ProductCollectionItemMappings.Attach(entity);
			entity = context.ProductCollectionItemMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> DeleteAsync(ProductCollectionItemMapping entity)
		{
			context.ProductCollectionItemMappings.Attach(entity);
			entity = context.ProductCollectionItemMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCollectionItemMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductCollectionItemMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductCollectionItemMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCollectionItemMapping FindById(int key)
		{
			var entity = context.ProductCollectionItemMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductCollectionItemMapping FindActiveById(int key)
		{
			var entity = context.ProductCollectionItemMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> FindByIdAsync(int key)
		{
			var entity = await context.ProductCollectionItemMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductCollectionItemMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductCollectionItemMapping FindByIdInclude<TProperty>(int key, params Expression<Func<ProductCollectionItemMapping, TProperty>>[] members)
		{
			IQueryable<ProductCollectionItemMapping> dbSet = context.ProductCollectionItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ProductCollectionItemMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductCollectionItemMapping, TProperty>>[] members)
		{
			IQueryable<ProductCollectionItemMapping> dbSet = context.ProductCollectionItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ProductCollectionItemMapping Activate(ProductCollectionItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductCollectionItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductCollectionItemMapping Deactivate(ProductCollectionItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductCollectionItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductCollectionItemMapping> GetActive()
		{
			return context.ProductCollectionItemMappings.Where(e => e.Active);
		}
		
		public override IQueryable<ProductCollectionItemMapping> GetActive(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return context.ProductCollectionItemMappings.Where(e => e.Active).Where(expr);
		}
		
		public override ProductCollectionItemMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductCollectionItemMapping FirstOrDefault(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductCollectionItemMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductCollectionItemMapping> FirstOrDefaultAsync(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductCollectionItemMapping SingleOrDefault(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductCollectionItemMapping> SingleOrDefaultAsync(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductCollectionItemMapping Update(ProductCollectionItemMapping entity)
		{
			entity = context.ProductCollectionItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollectionItemMapping> UpdateAsync(ProductCollectionItemMapping entity)
		{
			entity = context.ProductCollectionItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
