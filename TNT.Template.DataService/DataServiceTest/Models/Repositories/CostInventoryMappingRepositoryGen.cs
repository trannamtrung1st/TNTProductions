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
	public partial interface ICostInventoryMappingRepository : IBaseRepository<CostInventoryMapping, CostInventoryMappingPK>
	{
	}
	
	public partial class CostInventoryMappingRepository : BaseRepository<CostInventoryMapping, CostInventoryMappingPK>, ICostInventoryMappingRepository
	{
		public CostInventoryMappingRepository(DbContext context) : base(context)
		{
		}
		
		public CostInventoryMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CostInventoryMapping FindById(CostInventoryMappingPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override CostInventoryMapping FindActiveById(CostInventoryMappingPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override async Task<CostInventoryMapping> FindByIdAsync(CostInventoryMappingPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override async Task<CostInventoryMapping> FindActiveByIdAsync(CostInventoryMappingPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override CostInventoryMapping Activate(CostInventoryMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CostInventoryMapping Activate(CostInventoryMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CostInventoryMapping Deactivate(CostInventoryMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CostInventoryMapping Deactivate(CostInventoryMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CostInventoryMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<CostInventoryMapping> GetActive(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
