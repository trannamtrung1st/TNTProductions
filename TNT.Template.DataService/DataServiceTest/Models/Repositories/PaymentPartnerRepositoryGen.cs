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
	public partial interface IPaymentPartnerRepository : IBaseRepository<PaymentPartner, int>
	{
	}
	
	public partial class PaymentPartnerRepository : BaseRepository<PaymentPartner, int>, IPaymentPartnerRepository
	{
		public PaymentPartnerRepository(DbContext context) : base(context)
		{
		}
		
		public PaymentPartnerRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaymentPartner FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override PaymentPartner FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<PaymentPartner> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<PaymentPartner> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override PaymentPartner Activate(PaymentPartner entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaymentPartner Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaymentPartner Deactivate(PaymentPartner entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaymentPartner Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaymentPartner> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<PaymentPartner> GetActive(Expression<Func<PaymentPartner, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
