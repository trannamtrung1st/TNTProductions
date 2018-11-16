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
	public partial interface IStoreWebViewCounterRepository : IBaseRepository<StoreWebViewCounter, int>
	{
	}
	
	public partial class StoreWebViewCounterRepository : BaseRepository<StoreWebViewCounter, int>, IStoreWebViewCounterRepository
	{
		public StoreWebViewCounterRepository() : base()
		{
		}
		
		public StoreWebViewCounterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreWebViewCounter Add(StoreWebViewCounter entity)
		{
			entity.Active = true;
			entity = context.StoreWebViewCounters.Add(entity);
			return entity;
		}
		
		public override StoreWebViewCounter Remove(StoreWebViewCounter entity)
		{
			context.StoreWebViewCounters.Attach(entity);
			entity = context.StoreWebViewCounters.Remove(entity);
			return entity;
		}
		
		public override StoreWebViewCounter Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreWebViewCounters.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<StoreWebViewCounter> RemoveIf(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return context.StoreWebViewCounters.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<StoreWebViewCounter> RemoveRange(IEnumerable<StoreWebViewCounter> list)
		{
			return context.StoreWebViewCounters.RemoveRange(list);
		}
		
		public override StoreWebViewCounter FindById(int key)
		{
			var entity = context.StoreWebViewCounters.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreWebViewCounter FindActiveById(int key)
		{
			var entity = context.StoreWebViewCounters.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreWebViewCounter> FindByIdAsync(int key)
		{
			var entity = await context.StoreWebViewCounters.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreWebViewCounter> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreWebViewCounters.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreWebViewCounter FindByIdInclude<TProperty>(int key, params Expression<Func<StoreWebViewCounter, TProperty>>[] members)
		{
			IQueryable<StoreWebViewCounter> dbSet = context.StoreWebViewCounters;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<StoreWebViewCounter> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreWebViewCounter, TProperty>>[] members)
		{
			IQueryable<StoreWebViewCounter> dbSet = context.StoreWebViewCounters;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override StoreWebViewCounter Activate(StoreWebViewCounter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreWebViewCounter Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreWebViewCounter Deactivate(StoreWebViewCounter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreWebViewCounter Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreWebViewCounter> GetActive()
		{
			return context.StoreWebViewCounters.Where(e => e.Active);
		}
		
		public override IQueryable<StoreWebViewCounter> GetActive(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return context.StoreWebViewCounters.Where(e => e.Active).Where(expr);
		}
		
		public override StoreWebViewCounter FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreWebViewCounter FirstOrDefault(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreWebViewCounter> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreWebViewCounter> FirstOrDefaultAsync(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreWebViewCounter SingleOrDefault(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreWebViewCounter> SingleOrDefaultAsync(Expression<Func<StoreWebViewCounter, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreWebViewCounter Update(StoreWebViewCounter entity)
		{
			entity = context.StoreWebViewCounters.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
