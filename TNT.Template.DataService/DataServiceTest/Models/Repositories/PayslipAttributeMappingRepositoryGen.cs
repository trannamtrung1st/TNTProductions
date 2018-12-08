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
	public partial interface IPayslipAttributeMappingRepository : IBaseRepository<PayslipAttributeMapping, int>
	{
	}
	
	public partial class PayslipAttributeMappingRepository : BaseRepository<PayslipAttributeMapping, int>, IPayslipAttributeMappingRepository
	{
		public PayslipAttributeMappingRepository(DbContext context) : base(context)
		{
		}
		
		public PayslipAttributeMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayslipAttributeMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayslipAttributeMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayslipAttributeMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayslipAttributeMapping Activate(PayslipAttributeMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayslipAttributeMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayslipAttributeMapping Deactivate(PayslipAttributeMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayslipAttributeMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayslipAttributeMapping> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PayslipAttributeMapping> GetActive(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
