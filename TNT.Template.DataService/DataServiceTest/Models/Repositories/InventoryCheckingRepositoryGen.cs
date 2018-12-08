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
	public partial interface IInventoryCheckingRepository : IBaseRepository<InventoryChecking, int>
	{
	}
	
	public partial class InventoryCheckingRepository : BaseRepository<InventoryChecking, int>, IInventoryCheckingRepository
	{
		public InventoryCheckingRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryCheckingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryChecking FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override InventoryChecking FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override async Task<InventoryChecking> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override async Task<InventoryChecking> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override InventoryChecking Activate(InventoryChecking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryChecking Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryChecking Deactivate(InventoryChecking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryChecking Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryChecking> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<InventoryChecking> GetActive(Expression<Func<InventoryChecking, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
