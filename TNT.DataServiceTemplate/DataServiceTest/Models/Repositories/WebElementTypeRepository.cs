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
	public partial interface IWebElementTypeRepository : IBaseRepository<WebElementType, int>
	{
	}
	
	public partial class WebElementTypeRepository : BaseRepository<WebElementType, int>, IWebElementTypeRepository
	{
		public WebElementTypeRepository() : base()
		{
		}
		
		public WebElementTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebElementType Add(WebElementType entity)
		{
			entity.Active = true;
			entity = context.WebElementTypes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebElementType> AddAsync(WebElementType entity)
		{
			entity.Active = true;
			entity = context.WebElementTypes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebElementType Delete(WebElementType entity)
		{
			context.WebElementTypes.Attach(entity);
			entity = context.WebElementTypes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebElementType> DeleteAsync(WebElementType entity)
		{
			context.WebElementTypes.Attach(entity);
			entity = context.WebElementTypes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebElementType Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebElementTypes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebElementType> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebElementTypes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override WebElementType FindById(int key)
		{
			var entity = context.WebElementTypes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebElementType FindActiveById(int key)
		{
			var entity = context.WebElementTypes.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebElementType> FindByIdAsync(int key)
		{
			var entity = await context.WebElementTypes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebElementType> FindActiveByIdAsync(int key)
		{
			var entity = await context.WebElementTypes.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebElementType FindByIdInclude<TProperty>(int key, params Expression<Func<WebElementType, TProperty>>[] members)
		{
			IQueryable<WebElementType> dbSet = context.WebElementTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<WebElementType> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<WebElementType, TProperty>>[] members)
		{
			IQueryable<WebElementType> dbSet = context.WebElementTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override WebElementType Activate(WebElementType entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override WebElementType Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override WebElementType Deactivate(WebElementType entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override WebElementType Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<WebElementType> GetActive()
		{
			return context.WebElementTypes.Where(e => e.Active);
		}
		
		public override IQueryable<WebElementType> GetActive(Expression<Func<WebElementType, bool>> expr)
		{
			return context.WebElementTypes.Where(e => e.Active).Where(expr);
		}
		
		public override WebElementType FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override WebElementType FirstOrDefault(Expression<Func<WebElementType, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<WebElementType> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<WebElementType> FirstOrDefaultAsync(Expression<Func<WebElementType, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override WebElementType SingleOrDefault(Expression<Func<WebElementType, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<WebElementType> SingleOrDefaultAsync(Expression<Func<WebElementType, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override WebElementType Update(WebElementType entity)
		{
			entity = context.WebElementTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<WebElementType> UpdateAsync(WebElementType entity)
		{
			entity = context.WebElementTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
