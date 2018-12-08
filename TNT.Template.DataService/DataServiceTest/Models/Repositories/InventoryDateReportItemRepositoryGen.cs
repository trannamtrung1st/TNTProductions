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
	public partial interface IInventoryDateReportItemRepository : IBaseRepository<InventoryDateReportItem, InventoryDateReportItemPK>
	{
	}
	
	public partial class InventoryDateReportItemRepository : BaseRepository<InventoryDateReportItem, InventoryDateReportItemPK>, IInventoryDateReportItemRepository
	{
		public InventoryDateReportItemRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryDateReportItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryDateReportItem FindById(InventoryDateReportItemPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override InventoryDateReportItem FindActiveById(InventoryDateReportItemPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override async Task<InventoryDateReportItem> FindByIdAsync(InventoryDateReportItemPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override async Task<InventoryDateReportItem> FindActiveByIdAsync(InventoryDateReportItemPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override InventoryDateReportItem Activate(InventoryDateReportItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReportItem Activate(InventoryDateReportItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReportItem Deactivate(InventoryDateReportItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReportItem Deactivate(InventoryDateReportItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryDateReportItem> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<InventoryDateReportItem> GetActive(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
