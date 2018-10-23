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
	public partial interface IEventLocationRepository : IBaseRepository<EventLocation, int>
	{
	}
	
	public partial class EventLocationRepository : BaseRepository<EventLocation, int>, IEventLocationRepository
	{
		public EventLocationRepository() : base()
		{
		}
		
		public EventLocationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EventLocation Add(EventLocation entity)
		{
			entity.Active = true;
			entity = context.EventLocations.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EventLocation> AddAsync(EventLocation entity)
		{
			entity.Active = true;
			entity = context.EventLocations.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override EventLocation Delete(EventLocation entity)
		{
			context.EventLocations.Attach(entity);
			entity = context.EventLocations.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EventLocation> DeleteAsync(EventLocation entity)
		{
			context.EventLocations.Attach(entity);
			entity = context.EventLocations.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override EventLocation Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EventLocations.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EventLocation> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EventLocations.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override EventLocation FindById(int key)
		{
			var entity = context.EventLocations.FirstOrDefault(
				e => e.LocationId == key);
			return entity;
		}
		
		public override EventLocation FindActiveById(int key)
		{
			var entity = context.EventLocations.FirstOrDefault(
				e => e.LocationId == key && e.Active);
			return entity;
		}
		
		public override async Task<EventLocation> FindByIdAsync(int key)
		{
			var entity = await context.EventLocations.FirstOrDefaultAsync(
				e => e.LocationId == key);
			return entity;
		}
		
		public override async Task<EventLocation> FindActiveByIdAsync(int key)
		{
			var entity = await context.EventLocations.FirstOrDefaultAsync(
				e => e.LocationId == key && e.Active);
			return entity;
		}
		
		public override EventLocation FindByIdInclude<TProperty>(int key, params Expression<Func<EventLocation, TProperty>>[] members)
		{
			IQueryable<EventLocation> dbSet = context.EventLocations;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.LocationId == key);
		}
		
		public override async Task<EventLocation> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<EventLocation, TProperty>>[] members)
		{
			IQueryable<EventLocation> dbSet = context.EventLocations;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.LocationId == key);
		}
		
		public override EventLocation Activate(EventLocation entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EventLocation Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EventLocation Deactivate(EventLocation entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EventLocation Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EventLocation> GetActive()
		{
			return context.EventLocations.Where(e => e.Active);
		}
		
		public override IQueryable<EventLocation> GetActive(Expression<Func<EventLocation, bool>> expr)
		{
			return context.EventLocations.Where(e => e.Active).Where(expr);
		}
		
		public override EventLocation FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override EventLocation FirstOrDefault(Expression<Func<EventLocation, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<EventLocation> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<EventLocation> FirstOrDefaultAsync(Expression<Func<EventLocation, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override EventLocation SingleOrDefault(Expression<Func<EventLocation, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<EventLocation> SingleOrDefaultAsync(Expression<Func<EventLocation, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override EventLocation Update(EventLocation entity)
		{
			entity = context.EventLocations.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<EventLocation> UpdateAsync(EventLocation entity)
		{
			entity = context.EventLocations.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
