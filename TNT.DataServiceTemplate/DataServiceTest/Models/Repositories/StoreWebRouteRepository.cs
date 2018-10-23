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
	public partial interface IStoreWebRouteRepository : IBaseRepository<StoreWebRoute, int>
	{
	}
	
	public partial class StoreWebRouteRepository : BaseRepository<StoreWebRoute, int>, IStoreWebRouteRepository
	{
		public StoreWebRouteRepository() : base()
		{
		}
		
		public StoreWebRouteRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebRoute Add(StoreWebRoute entity)
		{
			entity.Active = true;
			entity = context.StoreWebRoutes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRoute> AddAsync(StoreWebRoute entity)
		{
			entity.Active = true;
			entity = context.StoreWebRoutes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebRoute Delete(StoreWebRoute entity)
		{
			context.StoreWebRoutes.Attach(entity);
			entity = context.StoreWebRoutes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRoute> DeleteAsync(StoreWebRoute entity)
		{
			context.StoreWebRoutes.Attach(entity);
			entity = context.StoreWebRoutes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebRoute Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebRoutes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRoute> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebRoutes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebRoute FindById(int key)
		{
			var entity = context.StoreWebRoutes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebRoute FindActiveById(int key)
		{
			var entity = context.StoreWebRoutes.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebRoute> FindByIdAsync(int key)
		{
			var entity = await context.StoreWebRoutes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebRoute> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreWebRoutes.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebRoute FindByIdInclude<TProperty>(int key, params Expression<Func<StoreWebRoute, TProperty>>[] members)
		{
			IQueryable<StoreWebRoute> dbSet = context.StoreWebRoutes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<StoreWebRoute> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreWebRoute, TProperty>>[] members)
		{
			IQueryable<StoreWebRoute> dbSet = context.StoreWebRoutes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override StoreWebRoute Activate(StoreWebRoute entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebRoute Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebRoute Deactivate(StoreWebRoute entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebRoute Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebRoute> GetActive()
		{
			return context.StoreWebRoutes.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebRoute> GetActive(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return context.StoreWebRoutes.Where(e => e.Active).Where(expr);
		}
		
		public override StoreWebRoute FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreWebRoute FirstOrDefault(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreWebRoute> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreWebRoute> FirstOrDefaultAsync(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreWebRoute SingleOrDefault(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreWebRoute> SingleOrDefaultAsync(Expression<Func<StoreWebRoute, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreWebRoute Update(StoreWebRoute entity)
		{
			entity = context.StoreWebRoutes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRoute> UpdateAsync(StoreWebRoute entity)
		{
			entity = context.StoreWebRoutes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
