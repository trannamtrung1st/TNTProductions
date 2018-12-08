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
	public partial interface IPaySlipRepository : IBaseRepository<PaySlip, int>
	{
	}
	
	public partial class PaySlipRepository : BaseRepository<PaySlip, int>, IPaySlipRepository
	{
		public PaySlipRepository(DbContext context) : base(context)
		{
		}
		
		public PaySlipRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaySlip FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PaySlip FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PaySlip> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PaySlip> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PaySlip Activate(PaySlip entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaySlip Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaySlip Deactivate(PaySlip entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaySlip Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaySlip> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PaySlip> GetActive(Expression<Func<PaySlip, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
