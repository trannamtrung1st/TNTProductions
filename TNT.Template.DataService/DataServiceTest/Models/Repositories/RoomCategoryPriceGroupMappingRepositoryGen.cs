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
	public partial interface IRoomCategoryPriceGroupMappingRepository : IBaseRepository<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingPK>
	{
	}
	
	public partial class RoomCategoryPriceGroupMappingRepository : BaseRepository<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingPK>, IRoomCategoryPriceGroupMappingRepository
	{
		public RoomCategoryPriceGroupMappingRepository(DbContext context) : base(context)
		{
		}
		
		public RoomCategoryPriceGroupMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RoomCategoryPriceGroupMapping FindById(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override RoomCategoryPriceGroupMapping FindActiveById(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FindByIdAsync(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FindActiveByIdAsync(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override RoomCategoryPriceGroupMapping Activate(RoomCategoryPriceGroupMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategoryPriceGroupMapping Activate(RoomCategoryPriceGroupMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategoryPriceGroupMapping Deactivate(RoomCategoryPriceGroupMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategoryPriceGroupMapping Deactivate(RoomCategoryPriceGroupMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<RoomCategoryPriceGroupMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<RoomCategoryPriceGroupMapping> GetActive(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
