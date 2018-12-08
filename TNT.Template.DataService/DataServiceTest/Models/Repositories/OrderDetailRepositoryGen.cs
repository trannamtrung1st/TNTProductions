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
	public partial interface IOrderDetailRepository : IBaseRepository<OrderDetail, int>
	{
	}
	
	public partial class OrderDetailRepository : BaseRepository<OrderDetail, int>, IOrderDetailRepository
	{
		public OrderDetailRepository(DbContext context) : base(context)
		{
		}
		
		public OrderDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderDetail FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override OrderDetail FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override async Task<OrderDetail> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override async Task<OrderDetail> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override OrderDetail Activate(OrderDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderDetail Deactivate(OrderDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<OrderDetail> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<OrderDetail> GetActive(Expression<Func<OrderDetail, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
