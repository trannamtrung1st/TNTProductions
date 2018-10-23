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
	public partial interface IProductImageCollectionRepository : IBaseRepository<ProductImageCollection, int>
	{
	}
	
	public partial class ProductImageCollectionRepository : BaseRepository<ProductImageCollection, int>, IProductImageCollectionRepository
	{
		public ProductImageCollectionRepository() : base()
		{
		}
		
		public ProductImageCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductImageCollection Add(ProductImageCollection entity)
		{
			entity.Active = true;
			entity = context.ProductImageCollections.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImageCollection> AddAsync(ProductImageCollection entity)
		{
			entity.Active = true;
			entity = context.ProductImageCollections.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductImageCollection Delete(ProductImageCollection entity)
		{
			context.ProductImageCollections.Attach(entity);
			entity = context.ProductImageCollections.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImageCollection> DeleteAsync(ProductImageCollection entity)
		{
			context.ProductImageCollections.Attach(entity);
			entity = context.ProductImageCollections.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductImageCollection Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductImageCollections.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImageCollection> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductImageCollections.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductImageCollection FindById(int key)
		{
			var entity = context.ProductImageCollections.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductImageCollection FindActiveById(int key)
		{
			var entity = context.ProductImageCollections.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductImageCollection> FindByIdAsync(int key)
		{
			var entity = await context.ProductImageCollections.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductImageCollection> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductImageCollections.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductImageCollection FindByIdInclude<TProperty>(int key, params Expression<Func<ProductImageCollection, TProperty>>[] members)
		{
			IQueryable<ProductImageCollection> dbSet = context.ProductImageCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ProductImageCollection> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductImageCollection, TProperty>>[] members)
		{
			IQueryable<ProductImageCollection> dbSet = context.ProductImageCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ProductImageCollection Activate(ProductImageCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductImageCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductImageCollection Deactivate(ProductImageCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductImageCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductImageCollection> GetActive()
		{
			return context.ProductImageCollections.Where(e => e.Active);
		}
		
		public override IQueryable<ProductImageCollection> GetActive(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return context.ProductImageCollections.Where(e => e.Active).Where(expr);
		}
		
		public override ProductImageCollection FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductImageCollection FirstOrDefault(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductImageCollection> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductImageCollection> FirstOrDefaultAsync(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductImageCollection SingleOrDefault(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductImageCollection> SingleOrDefaultAsync(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductImageCollection Update(ProductImageCollection entity)
		{
			entity = context.ProductImageCollections.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImageCollection> UpdateAsync(ProductImageCollection entity)
		{
			entity = context.ProductImageCollections.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
