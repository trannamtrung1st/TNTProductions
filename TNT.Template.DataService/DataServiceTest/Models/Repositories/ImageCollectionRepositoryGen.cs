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
		public ImageCollectionRepository(DbContext context) : base(context)
		{
		}
		
		public ImageCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ImageCollection FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ImageCollection FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<ImageCollection> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ImageCollection> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<ImageCollection> GetActive(Expression<Func<ImageCollection, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
