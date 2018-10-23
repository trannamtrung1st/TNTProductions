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
		public BlogPostImageRepository() : base()
		{
		}
		
		public BlogPostImageRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override BlogPostImage Add(BlogPostImage entity)
		{
			entity.Active = true;
			entity = context.BlogPostImages.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<BlogPostImage> AddAsync(BlogPostImage entity)
		{
			entity.Active = true;
			entity = context.BlogPostImages.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override BlogPostImage Delete(BlogPostImage entity)
		{
			context.BlogPostImages.Attach(entity);
			entity = context.BlogPostImages.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<BlogPostImage> DeleteAsync(BlogPostImage entity)
		{
			context.BlogPostImages.Attach(entity);
			entity = context.BlogPostImages.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override BlogPostImage Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogPostImages.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<BlogPostImage> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.BlogPostImages.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override BlogPostImage FindById(int key)
		{
			var entity = context.BlogPostImages.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override BlogPostImage FindActiveById(int key)
		{
			var entity = context.BlogPostImages.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<BlogPostImage> FindByIdAsync(int key)
		{
			var entity = await context.BlogPostImages.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<BlogPostImage> FindActiveByIdAsync(int key)
		{
			var entity = await context.BlogPostImages.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override BlogPostImage FindByIdInclude<TProperty>(int key, params Expression<Func<BlogPostImage, TProperty>>[] members)
		{
			IQueryable<BlogPostImage> dbSet = context.BlogPostImages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<BlogPostImage> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<BlogPostImage, TProperty>>[] members)
		{
			IQueryable<BlogPostImage> dbSet = context.BlogPostImages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
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
			return context.BlogPostImages.Where(e => e.Active);
		}
		
		public override IQueryable<BlogPostImage> GetActive(Expression<Func<BlogPostImage, bool>> expr)
		{
			return context.BlogPostImages.Where(e => e.Active).Where(expr);
		}
		
		public override BlogPostImage FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override BlogPostImage FirstOrDefault(Expression<Func<BlogPostImage, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<BlogPostImage> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<BlogPostImage> FirstOrDefaultAsync(Expression<Func<BlogPostImage, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override BlogPostImage SingleOrDefault(Expression<Func<BlogPostImage, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<BlogPostImage> SingleOrDefaultAsync(Expression<Func<BlogPostImage, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override BlogPostImage Update(BlogPostImage entity)
		{
			entity = context.BlogPostImages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<BlogPostImage> UpdateAsync(BlogPostImage entity)
		{
			entity = context.BlogPostImages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
