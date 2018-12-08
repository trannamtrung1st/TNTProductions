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
	public partial interface IPaySlipTemplateRepository : IBaseRepository<PaySlipTemplate, int>
	{
	}
	
	public partial class PaySlipTemplateRepository : BaseRepository<PaySlipTemplate, int>, IPaySlipTemplateRepository
	{
		public PaySlipTemplateRepository(DbContext context) : base(context)
		{
		}
		
		public PaySlipTemplateRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaySlipTemplate FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PaySlipTemplate FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PaySlipTemplate> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PaySlipTemplate> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PaySlipTemplate Activate(PaySlipTemplate entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaySlipTemplate Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaySlipTemplate Deactivate(PaySlipTemplate entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaySlipTemplate Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaySlipTemplate> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PaySlipTemplate> GetActive(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
