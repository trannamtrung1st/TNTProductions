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
	public partial interface ITimeFrameRepository : IBaseRepository<TimeFrame, int>
	{
	}
	
	public partial class TimeFrameRepository : BaseRepository<TimeFrame, int>, ITimeFrameRepository
	{
		public TimeFrameRepository() : base()
		{
		}
		
		public TimeFrameRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TimeFrame Add(TimeFrame entity)
		{
			entity.Active = true;
			entity = context.TimeFrames.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeFrame> AddAsync(TimeFrame entity)
		{
			entity.Active = true;
			entity = context.TimeFrames.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeFrame Delete(TimeFrame entity)
		{
			context.TimeFrames.Attach(entity);
			entity = context.TimeFrames.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeFrame> DeleteAsync(TimeFrame entity)
		{
			context.TimeFrames.Attach(entity);
			entity = context.TimeFrames.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeFrame Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TimeFrames.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeFrame> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TimeFrames.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeFrame FindById(int key)
		{
			var entity = context.TimeFrames.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TimeFrame FindActiveById(int key)
		{
			var entity = context.TimeFrames.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TimeFrame> FindByIdAsync(int key)
		{
			var entity = await context.TimeFrames.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TimeFrame> FindActiveByIdAsync(int key)
		{
			var entity = await context.TimeFrames.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TimeFrame FindByIdInclude<TProperty>(int key, params Expression<Func<TimeFrame, TProperty>>[] members)
		{
			IQueryable<TimeFrame> dbSet = context.TimeFrames;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TimeFrame> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TimeFrame, TProperty>>[] members)
		{
			IQueryable<TimeFrame> dbSet = context.TimeFrames;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TimeFrame Activate(TimeFrame entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TimeFrame Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TimeFrame Deactivate(TimeFrame entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TimeFrame Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TimeFrame> GetActive()
		{
			return context.TimeFrames.Where(e => e.Active);
		}
		
		public override IQueryable<TimeFrame> GetActive(Expression<Func<TimeFrame, bool>> expr)
		{
			return context.TimeFrames.Where(e => e.Active).Where(expr);
		}
		
		public override TimeFrame FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TimeFrame FirstOrDefault(Expression<Func<TimeFrame, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TimeFrame> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TimeFrame> FirstOrDefaultAsync(Expression<Func<TimeFrame, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TimeFrame SingleOrDefault(Expression<Func<TimeFrame, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TimeFrame> SingleOrDefaultAsync(Expression<Func<TimeFrame, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TimeFrame Update(TimeFrame entity)
		{
			entity = context.TimeFrames.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeFrame> UpdateAsync(TimeFrame entity)
		{
			entity = context.TimeFrames.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
