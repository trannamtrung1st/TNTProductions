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
	public partial interface IProductImageRepository : IBaseRepository<ProductImage, int>
	{
	}
	
	public partial class ProductImageRepository : BaseRepository<ProductImage, int>, IProductImageRepository
	{
		public ProductImageRepository() : base()
		{
		}
		
		public ProductImageRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProductImage Add(ProductImage entity)
		{
			entity.Active = true;
			entity = context.ProductImages.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImage> AddAsync(ProductImage entity)
		{
			entity.Active = true;
			entity = context.ProductImages.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductImage Delete(ProductImage entity)
		{
			context.ProductImages.Attach(entity);
			entity = context.ProductImages.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImage> DeleteAsync(ProductImage entity)
		{
			context.ProductImages.Attach(entity);
			entity = context.ProductImages.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductImage Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductImages.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImage> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProductImages.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProductImage FindById(int key)
		{
			var entity = context.ProductImages.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ProductImage FindActiveById(int key)
		{
			var entity = context.ProductImages.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ProductImage> FindByIdAsync(int key)
		{
			var entity = await context.ProductImages.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ProductImage> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProductImages.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ProductImage FindByIdInclude<TProperty>(int key, params Expression<Func<ProductImage, TProperty>>[] members)
		{
			IQueryable<ProductImage> dbSet = context.ProductImages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ProductImage> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProductImage, TProperty>>[] members)
		{
			IQueryable<ProductImage> dbSet = context.ProductImages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ProductImage Activate(ProductImage entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProductImage Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProductImage Deactivate(ProductImage entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProductImage Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProductImage> GetActive()
		{
			return context.ProductImages.Where(e => e.Active);
		}
		
		public override IQueryable<ProductImage> GetActive(Expression<Func<ProductImage, bool>> expr)
		{
			return context.ProductImages.Where(e => e.Active).Where(expr);
		}
		
		public override ProductImage FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProductImage FirstOrDefault(Expression<Func<ProductImage, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProductImage> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProductImage> FirstOrDefaultAsync(Expression<Func<ProductImage, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProductImage SingleOrDefault(Expression<Func<ProductImage, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProductImage> SingleOrDefaultAsync(Expression<Func<ProductImage, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProductImage Update(ProductImage entity)
		{
			entity = context.ProductImages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProductImage> UpdateAsync(ProductImage entity)
		{
			entity = context.ProductImages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
