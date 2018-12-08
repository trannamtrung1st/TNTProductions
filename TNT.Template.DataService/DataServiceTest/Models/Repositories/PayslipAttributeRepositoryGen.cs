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
	public partial interface IPayslipAttributeRepository : IBaseRepository<PayslipAttribute, int>
	{
	}
	
	public partial class PayslipAttributeRepository : BaseRepository<PayslipAttribute, int>, IPayslipAttributeRepository
	{
		public PayslipAttributeRepository(DbContext context) : base(context)
		{
		}
		
		public PayslipAttributeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayslipAttribute FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayslipAttribute FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayslipAttribute> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayslipAttribute> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayslipAttribute Activate(PayslipAttribute entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayslipAttribute Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayslipAttribute Deactivate(PayslipAttribute entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayslipAttribute Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayslipAttribute> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PayslipAttribute> GetActive(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
