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
	public partial interface IProductCategoryRepository : IBaseRepository<ProductCategory, int>
	{
	}
	
	public partial class ProductCategoryRepository : BaseRepository<ProductCategory, int>, IProductCategoryRepository
	{
		public ProductCategoryRepository() : base()
		{
		}
		
		public ProductCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductCategory Add(ProductCategory entity)
		{
			entity.Active = true;
			entity = context.ProductCategories.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCategory> AddAsync(ProductCategory entity)
		{
			entity.Active = true;
			entity = context.ProductCategories.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCategory Delete(ProductCategory entity)
		{
			context.ProductCategories.Attach(entity);
			entity = context.ProductCategories.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCategory> DeleteAsync(ProductCategory entity)
		{
			context.ProductCategories.Attach(entity);
			entity = context.ProductCategories.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCategory Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductCategories.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCategory> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductCategories.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductCategory FindById(int key)
		{
			var entity = context.ProductCategories.FirstOrDefault(
				e => e.CateID == key);
			return entity;
		}
		
		public override ProductCategory FindActiveById(int key)
		{
			var entity = context.ProductCategories.FirstOrDefault(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductCategory> FindByIdAsync(int key)
		{
			var entity = await context.ProductCategories.FirstOrDefaultAsync(
				e => e.CateID == key);
			return entity;
		}
		
		public override async Task<ProductCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductCategories.FirstOrDefaultAsync(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override ProductCategory FindByIdInclude<TProperty>(int key, params Expression<Func<ProductCategory, TProperty>>[] members)
		{
			IQueryable<ProductCategory> dbSet = context.ProductCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CateID == key);
		}
		
		public override async Task<ProductCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductCategory, TProperty>>[] members)
		{
			IQueryable<ProductCategory> dbSet = context.ProductCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CateID == key);
		}
		
		public override ProductCategory Activate(ProductCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductCategory Deactivate(ProductCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductCategory> GetActive()
		{
			return context.ProductCategories.Where(e => e.Active);
		}
		
		public override IQueryable<ProductCategory> GetActive(Expression<Func<ProductCategory, bool>> expr)
		{
			return context.ProductCategories.Where(e => e.Active).Where(expr);
		}
		
		public override ProductCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductCategory FirstOrDefault(Expression<Func<ProductCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductCategory> FirstOrDefaultAsync(Expression<Func<ProductCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductCategory SingleOrDefault(Expression<Func<ProductCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductCategory> SingleOrDefaultAsync(Expression<Func<ProductCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductCategory Update(ProductCategory entity)
		{
			entity = context.ProductCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductCategory> UpdateAsync(ProductCategory entity)
		{
			entity = context.ProductCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
