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
	public partial interface IInventoryReceiptItemRepository : IBaseRepository<InventoryReceiptItem, InventoryReceiptItemPK>
	{
	}
	
	public partial class InventoryReceiptItemRepository : BaseRepository<InventoryReceiptItem, InventoryReceiptItemPK>, IInventoryReceiptItemRepository
	{
		public InventoryReceiptItemRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryReceiptItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryReceiptItem FindById(InventoryReceiptItemPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override InventoryReceiptItem FindActiveById(InventoryReceiptItemPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> FindByIdAsync(InventoryReceiptItemPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> FindActiveByIdAsync(InventoryReceiptItemPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override InventoryReceiptItem Activate(InventoryReceiptItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceiptItem Activate(InventoryReceiptItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceiptItem Deactivate(InventoryReceiptItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceiptItem Deactivate(InventoryReceiptItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryReceiptItem> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<InventoryReceiptItem> GetActive(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
