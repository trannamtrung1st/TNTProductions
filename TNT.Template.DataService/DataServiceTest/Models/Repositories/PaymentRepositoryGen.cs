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
	public partial interface IPaymentRepository : IBaseRepository<Payment, int>
	{
	}
	
	public partial class PaymentRepository : BaseRepository<Payment, int>, IPaymentRepository
	{
		public PaymentRepository(DbContext context) : base(context)
		{
		}
		
		public PaymentRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Payment FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override Payment FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override async Task<Payment> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override async Task<Payment> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PaymentID == key);
			return entity;
		}
		
		public override Payment Activate(Payment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Payment Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Payment Deactivate(Payment entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Payment Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Payment> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Payment> GetActive(Expression<Func<Payment, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
