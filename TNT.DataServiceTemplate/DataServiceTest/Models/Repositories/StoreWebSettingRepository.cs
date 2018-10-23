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
	public partial interface IStoreWebSettingRepository : IBaseRepository<StoreWebSetting, int>
	{
	}
	
	public partial class StoreWebSettingRepository : BaseRepository<StoreWebSetting, int>, IStoreWebSettingRepository
	{
		public StoreWebSettingRepository() : base()
		{
		}
		
		public StoreWebSettingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebSetting Add(StoreWebSetting entity)
		{
			entity.Active = true;
			entity = context.StoreWebSettings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebSetting> AddAsync(StoreWebSetting entity)
		{
			entity.Active = true;
			entity = context.StoreWebSettings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebSetting Delete(StoreWebSetting entity)
		{
			context.StoreWebSettings.Attach(entity);
			entity = context.StoreWebSettings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebSetting> DeleteAsync(StoreWebSetting entity)
		{
			context.StoreWebSettings.Attach(entity);
			entity = context.StoreWebSettings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebSetting Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebSettings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebSetting> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebSettings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebSetting FindById(int key)
		{
			var entity = context.StoreWebSettings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebSetting FindActiveById(int key)
		{
			var entity = context.StoreWebSettings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebSetting> FindByIdAsync(int key)
		{
			var entity = await context.StoreWebSettings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebSetting> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreWebSettings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebSetting FindByIdInclude<TProperty>(int key, params Expression<Func<StoreWebSetting, TProperty>>[] members)
		{
			IQueryable<StoreWebSetting> dbSet = context.StoreWebSettings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<StoreWebSetting> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreWebSetting, TProperty>>[] members)
		{
			IQueryable<StoreWebSetting> dbSet = context.StoreWebSettings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override StoreWebSetting Activate(StoreWebSetting entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebSetting Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebSetting Deactivate(StoreWebSetting entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebSetting Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebSetting> GetActive()
		{
			return context.StoreWebSettings.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebSetting> GetActive(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return context.StoreWebSettings.Where(e => e.Active).Where(expr);
		}
		
		public override StoreWebSetting FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreWebSetting FirstOrDefault(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreWebSetting> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreWebSetting> FirstOrDefaultAsync(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreWebSetting SingleOrDefault(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreWebSetting> SingleOrDefaultAsync(Expression<Func<StoreWebSetting, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreWebSetting Update(StoreWebSetting entity)
		{
			entity = context.StoreWebSettings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebSetting> UpdateAsync(StoreWebSetting entity)
		{
			entity = context.StoreWebSettings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
