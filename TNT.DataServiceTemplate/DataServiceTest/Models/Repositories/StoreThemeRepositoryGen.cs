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
	public partial interface IStoreThemeRepository : IBaseRepository<StoreTheme, int>
	{
	}
	
	public partial class StoreThemeRepository : BaseRepository<StoreTheme, int>, IStoreThemeRepository
	{
		public StoreThemeRepository() : base()
		{
		}
		
		public StoreThemeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreTheme Add(StoreTheme entity)
		{
			entity.Active = true;
			entity = context.StoreThemes.Add(entity);
			return entity;
		}
		
		public override StoreTheme Remove(StoreTheme entity)
		{
			context.StoreThemes.Attach(entity);
			entity = context.StoreThemes.Remove(entity);
			return entity;
		}
		
		public override StoreTheme Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreThemes.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<StoreTheme> RemoveIf(Expression<Func<StoreTheme, bool>> expr)
		{
			return context.StoreThemes.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<StoreTheme> RemoveRange(IEnumerable<StoreTheme> list)
		{
			return context.StoreThemes.RemoveRange(list);
		}
		
		public override StoreTheme FindById(int key)
		{
			var entity = context.StoreThemes.FirstOrDefault(
				e => e.StoreThemeId == key);
			return entity;
		}
		
		public override StoreTheme FindActiveById(int key)
		{
			var entity = context.StoreThemes.FirstOrDefault(
				e => e.StoreThemeId == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreTheme> FindByIdAsync(int key)
		{
			var entity = await context.StoreThemes.FirstOrDefaultAsync(
				e => e.StoreThemeId == key);
			return entity;
		}
		
		public override async Task<StoreTheme> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreThemes.FirstOrDefaultAsync(
				e => e.StoreThemeId == key && e.Active);
			return entity;
		}
		
		public override StoreTheme FindByIdInclude<TProperty>(int key, params Expression<Func<StoreTheme, TProperty>>[] members)
		{
			IQueryable<StoreTheme> dbSet = context.StoreThemes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.StoreThemeId == key);
		}
		
		public override async Task<StoreTheme> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreTheme, TProperty>>[] members)
		{
			IQueryable<StoreTheme> dbSet = context.StoreThemes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.StoreThemeId == key);
		}
		
		public override StoreTheme Activate(StoreTheme entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreTheme Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreTheme Deactivate(StoreTheme entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreTheme Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreTheme> GetActive()
		{
			return context.StoreThemes.Where(e => e.Active);
		}
		
		public override IQueryable<StoreTheme> GetActive(Expression<Func<StoreTheme, bool>> expr)
		{
			return context.StoreThemes.Where(e => e.Active).Where(expr);
		}
		
		public override StoreTheme FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreTheme FirstOrDefault(Expression<Func<StoreTheme, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreTheme> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreTheme> FirstOrDefaultAsync(Expression<Func<StoreTheme, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreTheme SingleOrDefault(Expression<Func<StoreTheme, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreTheme> SingleOrDefaultAsync(Expression<Func<StoreTheme, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreTheme Update(StoreTheme entity)
		{
			entity = context.StoreThemes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
