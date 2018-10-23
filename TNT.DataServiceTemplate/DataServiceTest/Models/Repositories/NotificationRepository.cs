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
	public partial interface INotificationRepository : IBaseRepository<Notification, int>
	{
	}
	
	public partial class NotificationRepository : BaseRepository<Notification, int>, INotificationRepository
	{
		public NotificationRepository() : base()
		{
		}
		
		public NotificationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Notification Add(Notification entity)
		{
			
			entity = context.Notifications.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Notification> AddAsync(Notification entity)
		{
			
			entity = context.Notifications.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Notification Delete(Notification entity)
		{
			context.Notifications.Attach(entity);
			entity = context.Notifications.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Notification> DeleteAsync(Notification entity)
		{
			context.Notifications.Attach(entity);
			entity = context.Notifications.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Notification Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Notifications.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Notification> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Notifications.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Notification FindById(int key)
		{
			var entity = context.Notifications.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Notification FindActiveById(int key)
		{
			var entity = context.Notifications.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Notification> FindByIdAsync(int key)
		{
			var entity = await context.Notifications.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Notification> FindActiveByIdAsync(int key)
		{
			var entity = await context.Notifications.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Notification FindByIdInclude<TProperty>(int key, params Expression<Func<Notification, TProperty>>[] members)
		{
			IQueryable<Notification> dbSet = context.Notifications;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Notification> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Notification, TProperty>>[] members)
		{
			IQueryable<Notification> dbSet = context.Notifications;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Notification Activate(Notification entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Notification Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Notification Deactivate(Notification entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Notification Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Notification> GetActive()
		{
			return context.Notifications;
		}
		
		public override IQueryable<Notification> GetActive(Expression<Func<Notification, bool>> expr)
		{
			return context.Notifications.Where(expr);
		}
		
		public override Notification FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Notification FirstOrDefault(Expression<Func<Notification, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Notification> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Notification> FirstOrDefaultAsync(Expression<Func<Notification, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Notification SingleOrDefault(Expression<Func<Notification, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Notification> SingleOrDefaultAsync(Expression<Func<Notification, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Notification Update(Notification entity)
		{
			entity = context.Notifications.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Notification> UpdateAsync(Notification entity)
		{
			entity = context.Notifications.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
