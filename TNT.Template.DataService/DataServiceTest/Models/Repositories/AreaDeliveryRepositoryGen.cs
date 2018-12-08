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
	public partial interface IAreaDeliveryRepository : IBaseRepository<AreaDelivery, int>
	{
	}
	
	public partial class AreaDeliveryRepository : BaseRepository<AreaDelivery, int>, IAreaDeliveryRepository
	{
		public AreaDeliveryRepository(DbContext context) : base(context)
		{
		}
		
		public AreaDeliveryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AreaDelivery FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AreaDelivery FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AreaDelivery> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AreaDelivery> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AreaDelivery Activate(AreaDelivery entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AreaDelivery Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AreaDelivery Deactivate(AreaDelivery entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AreaDelivery Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AreaDelivery> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<AreaDelivery> GetActive(Expression<Func<AreaDelivery, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
