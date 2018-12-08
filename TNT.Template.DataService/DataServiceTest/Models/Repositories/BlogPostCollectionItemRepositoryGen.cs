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
	public partial interface IBlogPostCollectionItemRepository : IBaseRepository<BlogPostCollectionItem, int>
	{
	}
	
	public partial class BlogPostCollectionItemRepository : BaseRepository<BlogPostCollectionItem, int>, IBlogPostCollectionItemRepository
	{
		public BlogPostCollectionItemRepository(DbContext context) : base(context)
		{
		}
		
		public BlogPostCollectionItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostCollectionItem FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostCollectionItem FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItem> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItem> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostCollectionItem Activate(BlogPostCollectionItem entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItem Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostCollectionItem Deactivate(BlogPostCollectionItem entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItem Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostCollectionItem> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostCollectionItem> GetActive(Expression<Func<BlogPostCollectionItem, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
