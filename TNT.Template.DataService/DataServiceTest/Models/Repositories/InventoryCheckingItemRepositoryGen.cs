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
	public partial interface IInventoryCheckingItemRepository : IBaseRepository<InventoryCheckingItem, int>
	{
	}
	
	public partial class InventoryCheckingItemRepository : BaseRepository<InventoryCheckingItem, int>, IInventoryCheckingItemRepository
	{
		public InventoryCheckingItemRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryCheckingItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryCheckingItem FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override InventoryCheckingItem FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override InventoryCheckingItem Activate(InventoryCheckingItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryCheckingItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryCheckingItem Deactivate(InventoryCheckingItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryCheckingItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryCheckingItem> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<InventoryCheckingItem> GetActive(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
