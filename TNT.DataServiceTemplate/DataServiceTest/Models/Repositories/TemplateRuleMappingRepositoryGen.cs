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
	public partial interface ITemplateRuleMappingRepository : IBaseRepository<TemplateRuleMapping, int>
	{
	}
	
	public partial class TemplateRuleMappingRepository : BaseRepository<TemplateRuleMapping, int>, ITemplateRuleMappingRepository
	{
		public TemplateRuleMappingRepository() : base()
		{
		}
		
		public TemplateRuleMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TemplateRuleMapping Add(TemplateRuleMapping entity)
		{
			entity.Active = true;
			entity = context.TemplateRuleMappings.Add(entity);
			return entity;
		}
		
		public override TemplateRuleMapping Remove(TemplateRuleMapping entity)
		{
			context.TemplateRuleMappings.Attach(entity);
			entity = context.TemplateRuleMappings.Remove(entity);
			return entity;
		}
		
		public override TemplateRuleMapping Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TemplateRuleMappings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<TemplateRuleMapping> RemoveIf(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return context.TemplateRuleMappings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<TemplateRuleMapping> RemoveRange(IEnumerable<TemplateRuleMapping> list)
		{
			return context.TemplateRuleMappings.RemoveRange(list);
		}
		
		public override TemplateRuleMapping FindById(int key)
		{
			var entity = context.TemplateRuleMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateRuleMapping FindActiveById(int key)
		{
			var entity = context.TemplateRuleMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TemplateRuleMapping> FindByIdAsync(int key)
		{
			var entity = await context.TemplateRuleMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateRuleMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.TemplateRuleMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TemplateRuleMapping FindByIdInclude<TProperty>(int key, params Expression<Func<TemplateRuleMapping, TProperty>>[] members)
		{
			IQueryable<TemplateRuleMapping> dbSet = context.TemplateRuleMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TemplateRuleMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TemplateRuleMapping, TProperty>>[] members)
		{
			IQueryable<TemplateRuleMapping> dbSet = context.TemplateRuleMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TemplateRuleMapping Activate(TemplateRuleMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TemplateRuleMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TemplateRuleMapping Deactivate(TemplateRuleMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TemplateRuleMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TemplateRuleMapping> GetActive()
		{
			return context.TemplateRuleMappings.Where(e => e.Active);
		}
		
		public override IQueryable<TemplateRuleMapping> GetActive(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return context.TemplateRuleMappings.Where(e => e.Active).Where(expr);
		}
		
		public override TemplateRuleMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TemplateRuleMapping FirstOrDefault(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TemplateRuleMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TemplateRuleMapping> FirstOrDefaultAsync(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TemplateRuleMapping SingleOrDefault(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TemplateRuleMapping> SingleOrDefaultAsync(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TemplateRuleMapping Update(TemplateRuleMapping entity)
		{
			entity = context.TemplateRuleMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
