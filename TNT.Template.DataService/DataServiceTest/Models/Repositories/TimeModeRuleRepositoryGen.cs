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
		public TimeModeRuleRepository(DbContext context) : base(context)
		{
		}
		
		public TimeModeRuleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TimeModeRule FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TimeModeRule FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TimeModeRule> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TimeModeRule> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
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
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<TimeModeRule> GetActive(Expression<Func<TimeModeRule, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
