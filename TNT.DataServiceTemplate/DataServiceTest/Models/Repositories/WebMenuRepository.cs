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
	public partial interface IWebMenuRepository : IBaseRepository<WebMenu, int>
	{
	}
	
	public partial class WebMenuRepository : BaseRepository<WebMenu, int>, IWebMenuRepository
	{
		public WebMenuRepository() : base()
		{
		}
		
		public WebMenuRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebMenu Add(WebMenu entity)
		{
			entity.Active = true;
			entity = context.WebMenus.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebMenu> AddAsync(WebMenu entity)
		{
			entity.Active = true;
			entity = context.WebMenus.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebMenu Delete(WebMenu entity)
		{
			context.WebMenus.Attach(entity);
			entity = context.WebMenus.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebMenu> DeleteAsync(WebMenu entity)
		{
			context.WebMenus.Attach(entity);
			entity = context.WebMenus.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebMenu Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebMenus.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebMenu> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebMenus.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebMenu FindById(int key)
		{
			var entity = context.WebMenus.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebMenu FindActiveById(int key)
		{
			var entity = context.WebMenus.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebMenu> FindByIdAsync(int key)
		{
			var entity = await context.WebMenus.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebMenu> FindActiveByIdAsync(int key)
		{
			var entity = await context.WebMenus.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebMenu FindByIdInclude<TProperty>(int key, params Expression<Func<WebMenu, TProperty>>[] members)
		{
			IQueryable<WebMenu> dbSet = context.WebMenus;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<WebMenu> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<WebMenu, TProperty>>[] members)
		{
			IQueryable<WebMenu> dbSet = context.WebMenus;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override WebMenu Activate(WebMenu entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override WebMenu Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override WebMenu Deactivate(WebMenu entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override WebMenu Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<WebMenu> GetActive()
		{
			return context.WebMenus.Where(e => e.Active);
		}
		
		public override IQueryable<WebMenu> GetActive(Expression<Func<WebMenu, bool>> expr)
		{
			return context.WebMenus.Where(e => e.Active).Where(expr);
		}
		
		public override WebMenu FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override WebMenu FirstOrDefault(Expression<Func<WebMenu, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<WebMenu> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<WebMenu> FirstOrDefaultAsync(Expression<Func<WebMenu, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override WebMenu SingleOrDefault(Expression<Func<WebMenu, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<WebMenu> SingleOrDefaultAsync(Expression<Func<WebMenu, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override WebMenu Update(WebMenu entity)
		{
			entity = context.WebMenus.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebMenu> UpdateAsync(WebMenu entity)
		{
			entity = context.WebMenus.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
