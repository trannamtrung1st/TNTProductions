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
	public partial interface IVATOrderRepository : IBaseRepository<VATOrder, int>
	{
	}
	
	public partial class VATOrderRepository : BaseRepository<VATOrder, int>, IVATOrderRepository
	{
		public VATOrderRepository(DbContext context) : base(context)
		{
		}
		
		public VATOrderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override VATOrder FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override VATOrder FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override async Task<VATOrder> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override async Task<VATOrder> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.InvoiceID == key);
			return entity;
		}
		
		public override VATOrder Activate(VATOrder entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrder Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrder Deactivate(VATOrder entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override VATOrder Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<VATOrder> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<VATOrder> GetActive(Expression<Func<VATOrder, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
