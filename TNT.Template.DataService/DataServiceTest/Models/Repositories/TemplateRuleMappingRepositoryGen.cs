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
		public TemplateRuleMappingRepository(DbContext context) : base(context)
		{
		}
		
		public TemplateRuleMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TemplateRuleMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateRuleMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TemplateRuleMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateRuleMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<TemplateRuleMapping> GetActive(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
