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
	public partial interface ITimeModeRuleRepository : IBaseRepository<TimeModeRule, int>
	{
	}
	
	public partial class TimeModeRuleRepository : BaseRepository<TimeModeRule, int>, ITimeModeRuleRepository
	{
		public TimeModeRuleRepository() : base()
		{
		}
		
		public TimeModeRuleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TimeModeRule Add(TimeModeRule entity)
		{
			entity.Active = true;
			entity = context.TimeModeRules.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeRule> AddAsync(TimeModeRule entity)
		{
			entity.Active = true;
			entity = context.TimeModeRules.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeModeRule Delete(TimeModeRule entity)
		{
			context.TimeModeRules.Attach(entity);
			entity = context.TimeModeRules.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeRule> DeleteAsync(TimeModeRule entity)
		{
			context.TimeModeRules.Attach(entity);
			entity = context.TimeModeRules.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeModeRule Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TimeModeRules.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeRule> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TimeModeRules.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeModeRule FindById(int key)
		{
			var entity = context.TimeModeRules.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TimeModeRule FindActiveById(int key)
		{
			var entity = context.TimeModeRules.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TimeModeRule> FindByIdAsync(int key)
		{
			var entity = await context.TimeModeRules.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TimeModeRule> FindActiveByIdAsync(int key)
		{
			var entity = await context.TimeModeRules.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TimeModeRule FindByIdInclude<TProperty>(int key, params Expression<Func<TimeModeRule, TProperty>>[] members)
		{
			IQueryable<TimeModeRule> dbSet = context.TimeModeRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TimeModeRule> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TimeModeRule, TProperty>>[] members)
		{
			IQueryable<TimeModeRule> dbSet = context.TimeModeRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TimeModeRule Activate(TimeModeRule entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TimeModeRule Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TimeModeRule Deactivate(TimeModeRule entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TimeModeRule Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TimeModeRule> GetActive()
		{
			return context.TimeModeRules.Where(e => e.Active);
		}
		
		public override IQueryable<TimeModeRule> GetActive(Expression<Func<TimeModeRule, bool>> expr)
		{
			return context.TimeModeRules.Where(e => e.Active).Where(expr);
		}
		
		public override TimeModeRule FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TimeModeRule FirstOrDefault(Expression<Func<TimeModeRule, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TimeModeRule> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TimeModeRule> FirstOrDefaultAsync(Expression<Func<TimeModeRule, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TimeModeRule SingleOrDefault(Expression<Func<TimeModeRule, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TimeModeRule> SingleOrDefaultAsync(Expression<Func<TimeModeRule, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TimeModeRule Update(TimeModeRule entity)
		{
			entity = context.TimeModeRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeRule> UpdateAsync(TimeModeRule entity)
		{
			entity = context.TimeModeRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
