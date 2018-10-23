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
	public partial interface IThemeRepository : IBaseRepository<Theme, int>
	{
	}
	
	public partial class ThemeRepository : BaseRepository<Theme, int>, IThemeRepository
	{
		public ThemeRepository() : base()
		{
		}
		
		public ThemeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Theme Add(Theme entity)
		{
			entity.Active = true;
			entity = context.Themes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Theme> AddAsync(Theme entity)
		{
			entity.Active = true;
			entity = context.Themes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Theme Delete(Theme entity)
		{
			context.Themes.Attach(entity);
			entity = context.Themes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Theme> DeleteAsync(Theme entity)
		{
			context.Themes.Attach(entity);
			entity = context.Themes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Theme Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Themes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Theme> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Themes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Theme FindById(int key)
		{
			var entity = context.Themes.FirstOrDefault(
				e => e.ThemeId == key);
			return entity;
		}
		
		public override Theme FindActiveById(int key)
		{
			var entity = context.Themes.FirstOrDefault(
				e => e.ThemeId == key && e.Active);
			return entity;
		}
		
		public override async Task<Theme> FindByIdAsync(int key)
		{
			var entity = await context.Themes.FirstOrDefaultAsync(
				e => e.ThemeId == key);
			return entity;
		}
		
		public override async Task<Theme> FindActiveByIdAsync(int key)
		{
			var entity = await context.Themes.FirstOrDefaultAsync(
				e => e.ThemeId == key && e.Active);
			return entity;
		}
		
		public override Theme FindByIdInclude<TProperty>(int key, params Expression<Func<Theme, TProperty>>[] members)
		{
			IQueryable<Theme> dbSet = context.Themes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ThemeId == key);
		}
		
		public override async Task<Theme> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Theme, TProperty>>[] members)
		{
			IQueryable<Theme> dbSet = context.Themes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ThemeId == key);
		}
		
		public override Theme Activate(Theme entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Theme Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Theme Deactivate(Theme entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Theme Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Theme> GetActive()
		{
			return context.Themes.Where(e => e.Active);
		}
		
		public override IQueryable<Theme> GetActive(Expression<Func<Theme, bool>> expr)
		{
			return context.Themes.Where(e => e.Active).Where(expr);
		}
		
		public override Theme FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Theme FirstOrDefault(Expression<Func<Theme, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Theme> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Theme> FirstOrDefaultAsync(Expression<Func<Theme, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Theme SingleOrDefault(Expression<Func<Theme, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Theme> SingleOrDefaultAsync(Expression<Func<Theme, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Theme Update(Theme entity)
		{
			entity = context.Themes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Theme> UpdateAsync(Theme entity)
		{
			entity = context.Themes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
