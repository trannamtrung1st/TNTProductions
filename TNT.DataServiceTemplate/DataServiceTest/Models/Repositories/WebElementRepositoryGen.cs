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
	public partial interface IWebElementRepository : IBaseRepository<WebElement, int>
	{
	}
	
	public partial class WebElementRepository : BaseRepository<WebElement, int>, IWebElementRepository
	{
		public WebElementRepository() : base()
		{
		}
		
		public WebElementRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebElement Add(WebElement entity)
		{
			entity.Active = true;
			entity = context.WebElements.Add(entity);
			return entity;
		}
		
		public override WebElement Remove(WebElement entity)
		{
			context.WebElements.Attach(entity);
			entity = context.WebElements.Remove(entity);
			return entity;
		}
		
		public override WebElement Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebElements.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<WebElement> RemoveIf(Expression<Func<WebElement, bool>> expr)
		{
			return context.WebElements.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<WebElement> RemoveRange(IEnumerable<WebElement> list)
		{
			return context.WebElements.RemoveRange(list);
		}
		
		public override WebElement FindById(int key)
		{
			var entity = context.WebElements.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebElement FindActiveById(int key)
		{
			var entity = context.WebElements.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebElement> FindByIdAsync(int key)
		{
			var entity = await context.WebElements.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebElement> FindActiveByIdAsync(int key)
		{
			var entity = await context.WebElements.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebElement FindByIdInclude<TProperty>(int key, params Expression<Func<WebElement, TProperty>>[] members)
		{
			IQueryable<WebElement> dbSet = context.WebElements;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<WebElement> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<WebElement, TProperty>>[] members)
		{
			IQueryable<WebElement> dbSet = context.WebElements;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override WebElement Activate(WebElement entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override WebElement Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override WebElement Deactivate(WebElement entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override WebElement Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<WebElement> GetActive()
		{
			return context.WebElements.Where(e => e.Active);
		}
		
		public override IQueryable<WebElement> GetActive(Expression<Func<WebElement, bool>> expr)
		{
			return context.WebElements.Where(e => e.Active).Where(expr);
		}
		
		public override WebElement FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override WebElement FirstOrDefault(Expression<Func<WebElement, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<WebElement> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<WebElement> FirstOrDefaultAsync(Expression<Func<WebElement, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override WebElement SingleOrDefault(Expression<Func<WebElement, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<WebElement> SingleOrDefaultAsync(Expression<Func<WebElement, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override WebElement Update(WebElement entity)
		{
			entity = context.WebElements.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
