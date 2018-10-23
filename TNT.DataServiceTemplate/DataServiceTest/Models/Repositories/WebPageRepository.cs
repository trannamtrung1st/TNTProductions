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
	public partial interface IWebPageRepository : IBaseRepository<WebPage, int>
	{
	}
	
	public partial class WebPageRepository : BaseRepository<WebPage, int>, IWebPageRepository
	{
		public WebPageRepository() : base()
		{
		}
		
		public WebPageRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebPage Add(WebPage entity)
		{
			
			entity = context.WebPages.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebPage> AddAsync(WebPage entity)
		{
			
			entity = context.WebPages.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebPage Delete(WebPage entity)
		{
			context.WebPages.Attach(entity);
			entity = context.WebPages.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebPage> DeleteAsync(WebPage entity)
		{
			context.WebPages.Attach(entity);
			entity = context.WebPages.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebPage Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebPages.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebPage> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebPages.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebPage FindById(int key)
		{
			var entity = context.WebPages.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebPage FindActiveById(int key)
		{
			var entity = context.WebPages.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebPage> FindByIdAsync(int key)
		{
			var entity = await context.WebPages.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebPage> FindActiveByIdAsync(int key)
		{
			var entity = await context.WebPages.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override WebPage FindByIdInclude<TProperty>(int key, params Expression<Func<WebPage, TProperty>>[] members)
		{
			IQueryable<WebPage> dbSet = context.WebPages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<WebPage> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<WebPage, TProperty>>[] members)
		{
			IQueryable<WebPage> dbSet = context.WebPages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override WebPage Activate(WebPage entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebPage Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebPage Deactivate(WebPage entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebPage Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<WebPage> GetActive()
		{
			return context.WebPages;
		}
		
		public override IQueryable<WebPage> GetActive(Expression<Func<WebPage, bool>> expr)
		{
			return context.WebPages.Where(expr);
		}
		
		public override WebPage FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override WebPage FirstOrDefault(Expression<Func<WebPage, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<WebPage> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<WebPage> FirstOrDefaultAsync(Expression<Func<WebPage, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override WebPage SingleOrDefault(Expression<Func<WebPage, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<WebPage> SingleOrDefaultAsync(Expression<Func<WebPage, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override WebPage Update(WebPage entity)
		{
			entity = context.WebPages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebPage> UpdateAsync(WebPage entity)
		{
			entity = context.WebPages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
