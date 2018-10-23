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
	public partial interface IViewCounterRepository : IBaseRepository<ViewCounter, int>
	{
	}
	
	public partial class ViewCounterRepository : BaseRepository<ViewCounter, int>, IViewCounterRepository
	{
		public ViewCounterRepository() : base()
		{
		}
		
		public ViewCounterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ViewCounter Add(ViewCounter entity)
		{
			
			entity = context.ViewCounters.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ViewCounter> AddAsync(ViewCounter entity)
		{
			
			entity = context.ViewCounters.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ViewCounter Delete(ViewCounter entity)
		{
			context.ViewCounters.Attach(entity);
			entity = context.ViewCounters.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ViewCounter> DeleteAsync(ViewCounter entity)
		{
			context.ViewCounters.Attach(entity);
			entity = context.ViewCounters.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ViewCounter Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ViewCounters.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ViewCounter> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ViewCounters.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ViewCounter FindById(int key)
		{
			var entity = context.ViewCounters.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ViewCounter FindActiveById(int key)
		{
			var entity = context.ViewCounters.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ViewCounter> FindByIdAsync(int key)
		{
			var entity = await context.ViewCounters.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ViewCounter> FindActiveByIdAsync(int key)
		{
			var entity = await context.ViewCounters.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override ViewCounter FindByIdInclude<TProperty>(int key, params Expression<Func<ViewCounter, TProperty>>[] members)
		{
			IQueryable<ViewCounter> dbSet = context.ViewCounters;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<ViewCounter> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ViewCounter, TProperty>>[] members)
		{
			IQueryable<ViewCounter> dbSet = context.ViewCounters;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override ViewCounter Activate(ViewCounter entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ViewCounter Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ViewCounter Deactivate(ViewCounter entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ViewCounter Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ViewCounter> GetActive()
		{
			return context.ViewCounters;
		}
		
		public override IQueryable<ViewCounter> GetActive(Expression<Func<ViewCounter, bool>> expr)
		{
			return context.ViewCounters.Where(expr);
		}
		
		public override ViewCounter FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ViewCounter FirstOrDefault(Expression<Func<ViewCounter, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ViewCounter> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ViewCounter> FirstOrDefaultAsync(Expression<Func<ViewCounter, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ViewCounter SingleOrDefault(Expression<Func<ViewCounter, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ViewCounter> SingleOrDefaultAsync(Expression<Func<ViewCounter, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ViewCounter Update(ViewCounter entity)
		{
			entity = context.ViewCounters.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ViewCounter> UpdateAsync(ViewCounter entity)
		{
			entity = context.ViewCounters.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
