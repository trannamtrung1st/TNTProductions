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
	public partial interface IImageCollectionRepository : IBaseRepository<ImageCollection, int>
	{
	}
	
	public partial class ImageCollectionRepository : BaseRepository<ImageCollection, int>, IImageCollectionRepository
	{
		public ImageCollectionRepository() : base()
		{
		}
		
		public ImageCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ImageCollection Add(ImageCollection entity)
		{
			entity.Active = true;
			entity = context.ImageCollections.Add(entity);
			return entity;
		}
		
		public override ImageCollection Remove(ImageCollection entity)
		{
			context.ImageCollections.Attach(entity);
			entity = context.ImageCollections.Remove(entity);
			return entity;
		}
		
		public override ImageCollection Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ImageCollections.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<ImageCollection> RemoveIf(Expression<Func<ImageCollection, bool>> expr)
		{
			return context.ImageCollections.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<ImageCollection> RemoveRange(IEnumerable<ImageCollection> list)
		{
			return context.ImageCollections.RemoveRange(list);
		}
		
		public override ImageCollection FindById(int key)
		{
			var entity = context.ImageCollections.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ImageCollection FindActiveById(int key)
		{
			var entity = context.ImageCollections.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ImageCollection> FindByIdAsync(int key)
		{
			var entity = await context.ImageCollections.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ImageCollection> FindActiveByIdAsync(int key)
		{
			var entity = await context.ImageCollections.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override ImageCollection FindByIdInclude<TProperty>(int key, params Expression<Func<ImageCollection, TProperty>>[] members)
		{
			IQueryable<ImageCollection> dbSet = context.ImageCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ImageCollection> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ImageCollection, TProperty>>[] members)
		{
			IQueryable<ImageCollection> dbSet = context.ImageCollections;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ImageCollection Activate(ImageCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ImageCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ImageCollection Deactivate(ImageCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ImageCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ImageCollection> GetActive()
		{
			return context.ImageCollections.Where(e => e.Active);
		}
		
		public override IQueryable<ImageCollection> GetActive(Expression<Func<ImageCollection, bool>> expr)
		{
			return context.ImageCollections.Where(e => e.Active).Where(expr);
		}
		
		public override ImageCollection FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ImageCollection FirstOrDefault(Expression<Func<ImageCollection, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ImageCollection> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ImageCollection> FirstOrDefaultAsync(Expression<Func<ImageCollection, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ImageCollection SingleOrDefault(Expression<Func<ImageCollection, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ImageCollection> SingleOrDefaultAsync(Expression<Func<ImageCollection, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ImageCollection Update(ImageCollection entity)
		{
			entity = context.ImageCollections.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
