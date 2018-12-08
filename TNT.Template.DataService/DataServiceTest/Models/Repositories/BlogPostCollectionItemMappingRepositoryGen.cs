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
	public partial interface IBlogPostCollectionItemMappingRepository : IBaseRepository<BlogPostCollectionItemMapping, int>
	{
	}
	
	public partial class BlogPostCollectionItemMappingRepository : BaseRepository<BlogPostCollectionItemMapping, int>, IBlogPostCollectionItemMappingRepository
	{
		public BlogPostCollectionItemMappingRepository(DbContext context) : base(context)
		{
		}
		
		public BlogPostCollectionItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostCollectionItemMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostCollectionItemMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItemMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostCollectionItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostCollectionItemMapping Activate(BlogPostCollectionItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostCollectionItemMapping Deactivate(BlogPostCollectionItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostCollectionItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostCollectionItemMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostCollectionItemMapping> GetActive(Expression<Func<BlogPostCollectionItemMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
