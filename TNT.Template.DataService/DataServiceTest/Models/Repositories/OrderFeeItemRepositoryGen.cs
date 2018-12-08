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
	public partial interface IOrderFeeItemRepository : IBaseRepository<OrderFeeItem, int>
	{
	}
	
	public partial class OrderFeeItemRepository : BaseRepository<OrderFeeItem, int>, IOrderFeeItemRepository
	{
		public OrderFeeItemRepository(DbContext context) : base(context)
		{
		}
		
		public OrderFeeItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderFeeItem FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.OrderId == key);
			return entity;
		}
		
		public override OrderFeeItem FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.OrderId == key);
			return entity;
		}
		
		public override async Task<OrderFeeItem> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.OrderId == key);
			return entity;
		}
		
		public override async Task<OrderFeeItem> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.OrderId == key);
			return entity;
		}
		
		public override OrderFeeItem Activate(OrderFeeItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderFeeItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderFeeItem Deactivate(OrderFeeItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderFeeItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<OrderFeeItem> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<OrderFeeItem> GetActive(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
