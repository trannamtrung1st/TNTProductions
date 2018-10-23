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
	public partial interface IStoreWebRouteModelRepository : IBaseRepository<StoreWebRouteModel, int>
	{
	}
	
	public partial class StoreWebRouteModelRepository : BaseRepository<StoreWebRouteModel, int>, IStoreWebRouteModelRepository
	{
		public StoreWebRouteModelRepository() : base()
		{
		}
		
		public StoreWebRouteModelRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebRouteModel Add(StoreWebRouteModel entity)
		{
			entity.Active = true;
			entity = context.StoreWebRouteModels.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> AddAsync(StoreWebRouteModel entity)
		{
			entity.Active = true;
			entity = context.StoreWebRouteModels.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebRouteModel Delete(StoreWebRouteModel entity)
		{
			context.StoreWebRouteModels.Attach(entity);
			entity = context.StoreWebRouteModels.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> DeleteAsync(StoreWebRouteModel entity)
		{
			context.StoreWebRouteModels.Attach(entity);
			entity = context.StoreWebRouteModels.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebRouteModel Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebRouteModels.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebRouteModels.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreWebRouteModel FindById(int key)
		{
			var entity = context.StoreWebRouteModels.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebRouteModel FindActiveById(int key)
		{
			var entity = context.StoreWebRouteModels.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> FindByIdAsync(int key)
		{
			var entity = await context.StoreWebRouteModels.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreWebRouteModels.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebRouteModel FindByIdInclude<TProperty>(int key, params Expression<Func<StoreWebRouteModel, TProperty>>[] members)
		{
			IQueryable<StoreWebRouteModel> dbSet = context.StoreWebRouteModels;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<StoreWebRouteModel> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreWebRouteModel, TProperty>>[] members)
		{
			IQueryable<StoreWebRouteModel> dbSet = context.StoreWebRouteModels;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override StoreWebRouteModel Activate(StoreWebRouteModel entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebRouteModel Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebRouteModel Deactivate(StoreWebRouteModel entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebRouteModel Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebRouteModel> GetActive()
		{
			return context.StoreWebRouteModels.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebRouteModel> GetActive(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return context.StoreWebRouteModels.Where(e => e.Active).Where(expr);
		}
		
		public override StoreWebRouteModel FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreWebRouteModel FirstOrDefault(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreWebRouteModel> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreWebRouteModel> FirstOrDefaultAsync(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreWebRouteModel SingleOrDefault(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreWebRouteModel> SingleOrDefaultAsync(Expression<Func<StoreWebRouteModel, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreWebRouteModel Update(StoreWebRouteModel entity)
		{
			entity = context.StoreWebRouteModels.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreWebRouteModel> UpdateAsync(StoreWebRouteModel entity)
		{
			entity = context.StoreWebRouteModels.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
