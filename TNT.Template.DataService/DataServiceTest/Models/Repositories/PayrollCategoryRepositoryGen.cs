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
	public partial interface IPayrollCategoryRepository : IBaseRepository<PayrollCategory, int>
	{
	}
	
	public partial class PayrollCategoryRepository : BaseRepository<PayrollCategory, int>, IPayrollCategoryRepository
	{
		public PayrollCategoryRepository(DbContext context) : base(context)
		{
		}
		
		public PayrollCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayrollCategory FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollCategory FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayrollCategory> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollCategory> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayrollCategory Activate(PayrollCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayrollCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayrollCategory Deactivate(PayrollCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayrollCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayrollCategory> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PayrollCategory> GetActive(Expression<Func<PayrollCategory, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
