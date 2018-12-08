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
	public partial interface IPayrollPeriodRepository : IBaseRepository<PayrollPeriod, int>
	{
	}
	
	public partial class PayrollPeriodRepository : BaseRepository<PayrollPeriod, int>, IPayrollPeriodRepository
	{
		public PayrollPeriodRepository(DbContext context) : base(context)
		{
		}
		
		public PayrollPeriodRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayrollPeriod FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollPeriod FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollPeriod> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollPeriod> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollPeriod Activate(PayrollPeriod entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PayrollPeriod Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PayrollPeriod Deactivate(PayrollPeriod entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PayrollPeriod Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PayrollPeriod> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PayrollPeriod> GetActive(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
