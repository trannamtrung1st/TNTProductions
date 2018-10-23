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
	public partial interface IProductCollectionRepository : IBaseRepository<ProductCollection, int>
	{
	}
	
	public partial class ProductCollectionRepository : BaseRepository<ProductCollection, int>, IProductCollectionRepository
	{
		public ProductCollectionRepository() : base()
		{
		}
		
		public ProductCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductCollection Add(ProductCollection entity)
		{
			entity.Active = true;
			entity = context.ProductCollections.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollection> AddAsync(ProductCollection entity)
		{
			entity.Active = true;
			entity = context.ProductCollections.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCollection Delete(ProductCollection entity)
		{
			context.ProductCollections.Attach(entity);
			entity = context.ProductCollections.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollection> DeleteAsync(ProductCollection entity)
		{
			context.ProductCollections.Attach(entity);
			entity = context.ProductCollections.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCollection Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductCollections.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollection> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductCollections.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCollection FindById(int key)
		{
			var entity = context.ProductCollections.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductCollection FindActiveById(int key)
		{
			var entity = context.ProductCollections.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductCollection> FindByIdAsync(int key)
		{
			var entity = await context.ProductCollections.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductCollection> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductCollections.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductCollection FindByIdInclude<TProperty>(int key, params Expression<Func<ProductCollection, TProperty>>[] members)
		{
			IQueryable<ProductCollection> dbSet = context.ProductCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ProductCollection> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductCollection, TProperty>>[] members)
		{
			IQueryable<ProductCollection> dbSet = context.ProductCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ProductCollection Activate(ProductCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductCollection Deactivate(ProductCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductCollection> GetActive()
		{
			return context.ProductCollections.Where(e => e.Active);
		}
		
		public override IQueryable<ProductCollection> GetActive(Expression<Func<ProductCollection, bool>> expr)
		{
			return context.ProductCollections.Where(e => e.Active).Where(expr);
		}
		
		public override ProductCollection FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductCollection FirstOrDefault(Expression<Func<ProductCollection, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductCollection> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductCollection> FirstOrDefaultAsync(Expression<Func<ProductCollection, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductCollection SingleOrDefault(Expression<Func<ProductCollection, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductCollection> SingleOrDefaultAsync(Expression<Func<ProductCollection, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductCollection Update(ProductCollection entity)
		{
			entity = context.ProductCollections.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCollection> UpdateAsync(ProductCollection entity)
		{
			entity = context.ProductCollections.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
