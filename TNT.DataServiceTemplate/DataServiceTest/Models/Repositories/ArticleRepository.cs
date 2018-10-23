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
	public partial interface IArticleRepository : IBaseRepository<Article, int>
	{
	}
	
	public partial class ArticleRepository : BaseRepository<Article, int>, IArticleRepository
	{
		public ArticleRepository() : base()
		{
		}
		
		public ArticleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Article Add(Article entity)
		{
			
			entity = context.Articles.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Article> AddAsync(Article entity)
		{
			
			entity = context.Articles.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Article Delete(Article entity)
		{
			context.Articles.Attach(entity);
			entity = context.Articles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Article> DeleteAsync(Article entity)
		{
			context.Articles.Attach(entity);
			entity = context.Articles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Article Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Articles.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Article> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Articles.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Article FindById(int key)
		{
			var entity = context.Articles.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Article FindActiveById(int key)
		{
			var entity = context.Articles.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Article> FindByIdAsync(int key)
		{
			var entity = await context.Articles.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Article> FindActiveByIdAsync(int key)
		{
			var entity = await context.Articles.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override Article FindByIdInclude<TProperty>(int key, params Expression<Func<Article, TProperty>>[] members)
		{
			IQueryable<Article> dbSet = context.Articles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<Article> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Article, TProperty>>[] members)
		{
			IQueryable<Article> dbSet = context.Articles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override Article Activate(Article entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Article Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Article Deactivate(Article entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Article Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Article> GetActive()
		{
			return context.Articles;
		}
		
		public override IQueryable<Article> GetActive(Expression<Func<Article, bool>> expr)
		{
			return context.Articles.Where(expr);
		}
		
		public override Article FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Article FirstOrDefault(Expression<Func<Article, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Article> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Article> FirstOrDefaultAsync(Expression<Func<Article, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Article SingleOrDefault(Expression<Func<Article, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Article> SingleOrDefaultAsync(Expression<Func<Article, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Article Update(Article entity)
		{
			entity = context.Articles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Article> UpdateAsync(Article entity)
		{
			entity = context.Articles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
