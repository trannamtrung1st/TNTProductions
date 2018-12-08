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
	public partial interface IInventoryDateReportRepository : IBaseRepository<InventoryDateReport, int>
	{
	}
	
	public partial class InventoryDateReportRepository : BaseRepository<InventoryDateReport, int>, IInventoryDateReportRepository
	{
		public InventoryDateReportRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryDateReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryDateReport FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ReportID == key);
			return entity;
		}
		
		public override InventoryDateReport FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ReportID == key);
			return entity;
		}
		
		public override async Task<InventoryDateReport> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ReportID == key);
			return entity;
		}
		
		public override async Task<InventoryDateReport> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ReportID == key);
			return entity;
		}
		
		public override InventoryDateReport Activate(InventoryDateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReport Deactivate(InventoryDateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryDateReport> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<InventoryDateReport> GetActive(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
