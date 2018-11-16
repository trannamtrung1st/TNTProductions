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
	public partial interface IProductItemCategoryRepository : IBaseRepository<ProductItemCategory, int>
	{
	}
	
	public partial class ProductItemCategoryRepository : BaseRepository<ProductItemCategory, int>, IProductItemCategoryRepository
	{
		public ProductItemCategoryRepository() : base()
		{
		}
		
		public ProductItemCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductItemCategory Add(ProductItemCategory entity)
		{
			entity.Active = true;
			entity = context.ProductItemCategories.Add(entity);
			return entity;
		}
		
		public override ProductItemCategory Remove(ProductItemCategory entity)
		{
			context.ProductItemCategories.Attach(entity);
			entity = context.ProductItemCategories.Remove(entity);
			return entity;
		}
		
		public override ProductItemCategory Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductItemCategories.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<ProductItemCategory> RemoveIf(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return context.ProductItemCategories.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<ProductItemCategory> RemoveRange(IEnumerable<ProductItemCategory> list)
		{
			return context.ProductItemCategories.RemoveRange(list);
		}
		
		public override ProductItemCategory FindById(int key)
		{
			var entity = context.ProductItemCategories.FirstOrDefault(
				e => e.CateID == key);
			return entity;
		}
		
		public override ProductItemCategory FindActiveById(int key)
		{
			var entity = context.ProductItemCategories.FirstOrDefault(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductItemCategory> FindByIdAsync(int key)
		{
			var entity = await context.ProductItemCategories.FirstOrDefaultAsync(
				e => e.CateID == key);
			return entity;
		}
		
		public override async Task<ProductItemCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductItemCategories.FirstOrDefaultAsync(
				e => e.CateID == key && e.Active);
			return entity;
		}
		
		public override ProductItemCategory FindByIdInclude<TProperty>(int key, params Expression<Func<ProductItemCategory, TProperty>>[] members)
		{
			IQueryable<ProductItemCategory> dbSet = context.ProductItemCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CateID == key);
		}
		
		public override async Task<ProductItemCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductItemCategory, TProperty>>[] members)
		{
			IQueryable<ProductItemCategory> dbSet = context.ProductItemCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CateID == key);
		}
		
		public override ProductItemCategory Activate(ProductItemCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductItemCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductItemCategory Deactivate(ProductItemCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductItemCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductItemCategory> GetActive()
		{
			return context.ProductItemCategories.Where(e => e.Active);
		}
		
		public override IQueryable<ProductItemCategory> GetActive(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return context.ProductItemCategories.Where(e => e.Active).Where(expr);
		}
		
		public override ProductItemCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductItemCategory FirstOrDefault(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductItemCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductItemCategory> FirstOrDefaultAsync(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductItemCategory SingleOrDefault(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductItemCategory> SingleOrDefaultAsync(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductItemCategory Update(ProductItemCategory entity)
		{
			entity = context.ProductItemCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
