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
	public partial interface IBlogPostCollectionRepository : IBaseRepository<BlogPostCollection, int>
	{
	}
	
	public partial class BlogPostCollectionRepository : BaseRepository<BlogPostCollection, int>, IBlogPostCollectionRepository
	{
		public BlogPostCollectionRepository(DbContext context) : base(context)
		{
		}
		
		public BlogPostCollectionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostCollection FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostCollection FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostCollection> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostCollection> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostCollection Activate(BlogPostCollection entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostCollection Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostCollection Deactivate(BlogPostCollection entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostCollection Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostCollection> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostCollection> GetActive(Expression<Func<BlogPostCollection, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
