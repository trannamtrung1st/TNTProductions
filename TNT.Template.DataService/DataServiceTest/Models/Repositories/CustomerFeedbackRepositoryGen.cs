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
	public partial interface ICustomerFeedbackRepository : IBaseRepository<CustomerFeedback, CustomerFeedbackPK>
	{
	}
	
	public partial class CustomerFeedbackRepository : BaseRepository<CustomerFeedback, CustomerFeedbackPK>, ICustomerFeedbackRepository
	{
		public CustomerFeedbackRepository(DbContext context) : base(context)
		{
		}
		
		public CustomerFeedbackRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerFeedback FindById(CustomerFeedbackPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active);
			return entity;
		}
		
		public override CustomerFeedback FindActiveById(CustomerFeedbackPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active && e.Active);
			return entity;
		}
		
		public override async Task<CustomerFeedback> FindByIdAsync(CustomerFeedbackPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active);
			return entity;
		}
		
		public override async Task<CustomerFeedback> FindActiveByIdAsync(CustomerFeedbackPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active && e.Active);
			return entity;
		}
		
		public override CustomerFeedback Activate(CustomerFeedback entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CustomerFeedback Activate(CustomerFeedbackPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CustomerFeedback Deactivate(CustomerFeedback entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CustomerFeedback Deactivate(CustomerFeedbackPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CustomerFeedback> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<CustomerFeedback> GetActive(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
