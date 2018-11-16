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
	public partial interface ISalaryRuleRepository : IBaseRepository<SalaryRule, int>
	{
	}
	
	public partial class SalaryRuleRepository : BaseRepository<SalaryRule, int>, ISalaryRuleRepository
	{
		public SalaryRuleRepository() : base()
		{
		}
		
		public SalaryRuleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SalaryRule Add(SalaryRule entity)
		{
			entity.Active = true;
			entity = context.SalaryRules.Add(entity);
			return entity;
		}
		
		public override SalaryRule Remove(SalaryRule entity)
		{
			context.SalaryRules.Attach(entity);
			entity = context.SalaryRules.Remove(entity);
			return entity;
		}
		
		public override SalaryRule Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.SalaryRules.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<SalaryRule> RemoveIf(Expression<Func<SalaryRule, bool>> expr)
		{
			return context.SalaryRules.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<SalaryRule> RemoveRange(IEnumerable<SalaryRule> list)
		{
			return context.SalaryRules.RemoveRange(list);
		}
		
		public override SalaryRule FindById(int key)
		{
			var entity = context.SalaryRules.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override SalaryRule FindActiveById(int key)
		{
			var entity = context.SalaryRules.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<SalaryRule> FindByIdAsync(int key)
		{
			var entity = await context.SalaryRules.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SalaryRule> FindActiveByIdAsync(int key)
		{
			var entity = await context.SalaryRules.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override SalaryRule FindByIdInclude<TProperty>(int key, params Expression<Func<SalaryRule, TProperty>>[] members)
		{
			IQueryable<SalaryRule> dbSet = context.SalaryRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<SalaryRule> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<SalaryRule, TProperty>>[] members)
		{
			IQueryable<SalaryRule> dbSet = context.SalaryRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override SalaryRule Activate(SalaryRule entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override SalaryRule Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override SalaryRule Deactivate(SalaryRule entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override SalaryRule Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<SalaryRule> GetActive()
		{
			return context.SalaryRules.Where(e => e.Active);
		}
		
		public override IQueryable<SalaryRule> GetActive(Expression<Func<SalaryRule, bool>> expr)
		{
			return context.SalaryRules.Where(e => e.Active).Where(expr);
		}
		
		public override SalaryRule FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override SalaryRule FirstOrDefault(Expression<Func<SalaryRule, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<SalaryRule> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<SalaryRule> FirstOrDefaultAsync(Expression<Func<SalaryRule, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override SalaryRule SingleOrDefault(Expression<Func<SalaryRule, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<SalaryRule> SingleOrDefaultAsync(Expression<Func<SalaryRule, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override SalaryRule Update(SalaryRule entity)
		{
			entity = context.SalaryRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
