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
		public ImageCollectionItemRepository(DbContext context) : base(context)
		{
		}
		
		public ImageCollectionItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ImageCollectionItem FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ImageCollectionItem FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ImageCollectionItem> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ImageCollectionItem> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ImageCollectionItem> GetActive(Expression<Func<ImageCollectionItem, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
