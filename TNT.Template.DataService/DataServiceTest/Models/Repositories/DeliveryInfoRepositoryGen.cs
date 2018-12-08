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
	public partial interface IDeliveryInfoRepository : IBaseRepository<DeliveryInfo, int>
	{
	}
	
	public partial class DeliveryInfoRepository : BaseRepository<DeliveryInfo, int>, IDeliveryInfoRepository
	{
		public DeliveryInfoRepository(DbContext context) : base(context)
		{
		}
		
		public DeliveryInfoRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DeliveryInfo FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override DeliveryInfo FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DeliveryInfo> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DeliveryInfo> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override DeliveryInfo Activate(DeliveryInfo entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DeliveryInfo Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DeliveryInfo Deactivate(DeliveryInfo entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DeliveryInfo Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DeliveryInfo> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<DeliveryInfo> GetActive(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
