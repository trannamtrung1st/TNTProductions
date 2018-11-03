using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface IEventRepository : IBaseRepository<Event, int>
	{
	}
	
	public partial class EventRepository : BaseRepository<Event, int>, IEventRepository
	{
		public EventRepository() : base()
		{
		}
		
		public EventRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Event Add(Event entity)
		{
			
			entity = context.Events.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Event> AddAsync(Event entity)
		{
			
			entity = context.Events.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Event Delete(Event entity)
		{
			context.Events.Attach(entity);
			entity = context.Events.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Event> DeleteAsync(Event entity)
		{
			context.Events.Attach(entity);
			entity = context.Events.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Event Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Events.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Event> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Events.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Event FindById(int key)
		{
			var entity = context.Events.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override Event FindActiveById(int key)
		{
			var entity = context.Events.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Event> FindByIdAsync(int key)
		{
			var entity = await context.Events.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<Event> FindActiveByIdAsync(int key)
		{
			var entity = await context.Events.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override Event FindByIdInclude<TProperty>(int key, params Expression<Func<Event, TProperty>>[] members)
		{
			IQueryable<Event> dbSet = context.Events;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<Event> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Event, TProperty>>[] members)
		{
			IQueryable<Event> dbSet = context.Events;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override Event Activate(Event entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Event Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Event Deactivate(Event entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Event Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Event> GetActive()
		{
			return context.Events;
		}
		
		public override IQueryable<Event> GetActive(Expression<Func<Event, bool>> expr)
		{
			return context.Events.Where(expr);
		}
		
		public override Event FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Event FirstOrDefault(Expression<Func<Event, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Event> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Event> FirstOrDefaultAsync(Expression<Func<Event, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Event SingleOrDefault(Expression<Func<Event, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Event> SingleOrDefaultAsync(Expression<Func<Event, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Event Update(Event entity)
		{
			entity = context.Events.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Event> UpdateAsync(Event entity)
		{
			entity = context.Events.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
