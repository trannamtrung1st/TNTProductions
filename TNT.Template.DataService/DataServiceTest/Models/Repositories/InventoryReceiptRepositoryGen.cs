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
	public partial interface IInventoryReceiptRepository : IBaseRepository<InventoryReceipt, int>
	{
	}
	
	public partial class InventoryReceiptRepository : BaseRepository<InventoryReceipt, int>, IInventoryReceiptRepository
	{
		public InventoryReceiptRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryReceiptRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryReceipt FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override InventoryReceipt FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override async Task<InventoryReceipt> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override async Task<InventoryReceipt> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override InventoryReceipt Activate(InventoryReceipt entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceipt Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceipt Deactivate(InventoryReceipt entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceipt Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryReceipt> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<InventoryReceipt> GetActive(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
