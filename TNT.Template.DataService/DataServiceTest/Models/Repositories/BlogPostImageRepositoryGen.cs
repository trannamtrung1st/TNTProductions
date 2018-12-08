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
	public partial interface IBlogPostImageRepository : IBaseRepository<BlogPostImage, int>
	{
	}
	
	public partial class BlogPostImageRepository : BaseRepository<BlogPostImage, int>, IBlogPostImageRepository
	{
		public BlogPostImageRepository(DbContext context) : base(context)
		{
		}
		
		public BlogPostImageRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostImage FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostImage FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostImage> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostImage> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostImage Activate(BlogPostImage entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override BlogPostImage Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override BlogPostImage Deactivate(BlogPostImage entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override BlogPostImage Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<BlogPostImage> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostImage> GetActive(Expression<Func<BlogPostImage, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
