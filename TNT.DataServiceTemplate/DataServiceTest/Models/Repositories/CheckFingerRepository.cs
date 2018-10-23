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
	public partial interface ICheckFingerRepository : IBaseRepository<CheckFinger, int>
	{
	}
	
	public partial class CheckFingerRepository : BaseRepository<CheckFinger, int>, ICheckFingerRepository
	{
		public CheckFingerRepository() : base()
		{
		}
		
		public CheckFingerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CheckFinger Add(CheckFinger entity)
		{
			entity.Active = true;
			entity = context.CheckFingers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CheckFinger> AddAsync(CheckFinger entity)
		{
			entity.Active = true;
			entity = context.CheckFingers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CheckFinger Delete(CheckFinger entity)
		{
			context.CheckFingers.Attach(entity);
			entity = context.CheckFingers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CheckFinger> DeleteAsync(CheckFinger entity)
		{
			context.CheckFingers.Attach(entity);
			entity = context.CheckFingers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CheckFinger Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CheckFingers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CheckFinger> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CheckFingers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CheckFinger FindById(int key)
		{
			var entity = context.CheckFingers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CheckFinger FindActiveById(int key)
		{
			var entity = context.CheckFingers.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<CheckFinger> FindByIdAsync(int key)
		{
			var entity = await context.CheckFingers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CheckFinger> FindActiveByIdAsync(int key)
		{
			var entity = await context.CheckFingers.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override CheckFinger FindByIdInclude<TProperty>(int key, params Expression<Func<CheckFinger, TProperty>>[] members)
		{
			IQueryable<CheckFinger> dbSet = context.CheckFingers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<CheckFinger> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CheckFinger, TProperty>>[] members)
		{
			IQueryable<CheckFinger> dbSet = context.CheckFingers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override CheckFinger Activate(CheckFinger entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CheckFinger Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CheckFinger Deactivate(CheckFinger entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CheckFinger Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CheckFinger> GetActive()
		{
			return context.CheckFingers.Where(e => e.Active);
		}
		
		public override IQueryable<CheckFinger> GetActive(Expression<Func<CheckFinger, bool>> expr)
		{
			return context.CheckFingers.Where(e => e.Active).Where(expr);
		}
		
		public override CheckFinger FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CheckFinger FirstOrDefault(Expression<Func<CheckFinger, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CheckFinger> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CheckFinger> FirstOrDefaultAsync(Expression<Func<CheckFinger, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CheckFinger SingleOrDefault(Expression<Func<CheckFinger, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CheckFinger> SingleOrDefaultAsync(Expression<Func<CheckFinger, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CheckFinger Update(CheckFinger entity)
		{
			entity = context.CheckFingers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CheckFinger> UpdateAsync(CheckFinger entity)
		{
			entity = context.CheckFingers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
