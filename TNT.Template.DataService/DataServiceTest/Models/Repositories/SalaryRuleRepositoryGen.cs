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
		public SalaryRuleRepository(DbContext context) : base(context)
		{
		}
		
		public SalaryRuleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SalaryRule FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override SalaryRule FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<SalaryRule> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<SalaryRule> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<SalaryRule> GetActive(Expression<Func<SalaryRule, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
