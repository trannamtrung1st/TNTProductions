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
	public partial interface IPayrollDetailRepository : IBaseRepository<PayrollDetail, int>
	{
	}
	
	public partial class PayrollDetailRepository : BaseRepository<PayrollDetail, int>, IPayrollDetailRepository
	{
		public PayrollDetailRepository(DbContext context) : base(context)
		{
		}
		
		public PayrollDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayrollDetail FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollDetail FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayrollDetail> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollDetail> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayrollDetail Activate(PayrollDetail entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayrollDetail Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayrollDetail Deactivate(PayrollDetail entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayrollDetail Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayrollDetail> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PayrollDetail> GetActive(Expression<Func<PayrollDetail, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
