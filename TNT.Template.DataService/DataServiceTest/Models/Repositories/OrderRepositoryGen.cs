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
	public partial interface IOrderRepository : IBaseRepository<Order, int>
	{
	}
	
	public partial class OrderRepository : BaseRepository<Order, int>, IOrderRepository
	{
		public OrderRepository(DbContext context) : base(context)
		{
		}
		
		public OrderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Order FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RentID == key);
			return entity;
		}
		
		public override Order FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RentID == key);
			return entity;
		}
		
		public override async Task<Order> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RentID == key);
			return entity;
		}
		
		public override async Task<Order> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RentID == key);
			return entity;
		}
		
		public override Order Activate(Order entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Order Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Order Deactivate(Order entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Order Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Order> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Order> GetActive(Expression<Func<Order, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
