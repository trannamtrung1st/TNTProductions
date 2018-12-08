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
	public partial interface IRoomFloorRepository : IBaseRepository<RoomFloor, int>
	{
	}
	
	public partial class RoomFloorRepository : BaseRepository<RoomFloor, int>, IRoomFloorRepository
	{
		public RoomFloorRepository(DbContext context) : base(context)
		{
		}
		
		public RoomFloorRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RoomFloor FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FloorID == key);
			return entity;
		}
		
		public override RoomFloor FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.FloorID == key);
			return entity;
		}
		
		public override async Task<RoomFloor> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FloorID == key);
			return entity;
		}
		
		public override async Task<RoomFloor> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.FloorID == key);
			return entity;
		}
		
		public override RoomFloor Activate(RoomFloor entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomFloor Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomFloor Deactivate(RoomFloor entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomFloor Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<RoomFloor> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<RoomFloor> GetActive(Expression<Func<RoomFloor, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
