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
	public partial interface IImageCollectionItemRepository : IBaseRepository<ImageCollectionItem, int>
	{
	}
	
	public partial class ImageCollectionItemRepository : BaseRepository<ImageCollectionItem, int>, IImageCollectionItemRepository
	{
		public ImageCollectionItemRepository() : base()
		{
		}
		
		public ImageCollectionItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ImageCollectionItem Add(ImageCollectionItem entity)
		{
			entity.Active = true;
			entity = context.ImageCollectionItems.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ImageCollectionItem> AddAsync(ImageCollectionItem entity)
		{
			entity.Active = true;
			entity = context.ImageCollectionItems.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ImageCollectionItem Delete(ImageCollectionItem entity)
		{
			context.ImageCollectionItems.Attach(entity);
			entity = context.ImageCollectionItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ImageCollectionItem> DeleteAsync(ImageCollectionItem entity)
		{
			context.ImageCollectionItems.Attach(entity);
			entity = context.ImageCollectionItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ImageCollectionItem Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ImageCollectionItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ImageCollectionItem> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ImageCollectionItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ImageCollectionItem FindById(int key)
		{
			var entity = context.ImageCollectionItems.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ImageCollectionItem FindActiveById(int key)
		{
			var entity = context.ImageCollectionItems.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ImageCollectionItem> FindByIdAsync(int key)
		{
			var entity = await context.ImageCollectionItems.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ImageCollectionItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.ImageCollectionItems.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ImageCollectionItem FindByIdInclude<TProperty>(int key, params Expression<Func<ImageCollectionItem, TProperty>>[] members)
		{
			IQueryable<ImageCollectionItem> dbSet = context.ImageCollectionItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ImageCollectionItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ImageCollectionItem, TProperty>>[] members)
		{
			IQueryable<ImageCollectionItem> dbSet = context.ImageCollectionItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ImageCollectionItem Activate(ImageCollectionItem entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ImageCollectionItem Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ImageCollectionItem Deactivate(ImageCollectionItem entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ImageCollectionItem Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ImageCollectionItem> GetActive()
		{
			return context.ImageCollectionItems.Where(e => e.Active);
		}
		
		public override IQueryable<ImageCollectionItem> GetActive(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return context.ImageCollectionItems.Where(e => e.Active).Where(expr);
		}
		
		public override ImageCollectionItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ImageCollectionItem FirstOrDefault(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ImageCollectionItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ImageCollectionItem> FirstOrDefaultAsync(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ImageCollectionItem SingleOrDefault(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ImageCollectionItem> SingleOrDefaultAsync(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ImageCollectionItem Update(ImageCollectionItem entity)
		{
			entity = context.ImageCollectionItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ImageCollectionItem> UpdateAsync(ImageCollectionItem entity)
		{
			entity = context.ImageCollectionItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
