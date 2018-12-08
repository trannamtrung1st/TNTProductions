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
	public partial interface IRoomRepository : IBaseRepository<Room, int>
	{
	}
	
	public partial class RoomRepository : BaseRepository<Room, int>, IRoomRepository
	{
		public RoomRepository(DbContext context) : base(context)
		{
		}
		
		public RoomRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Room FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RoomID == key);
			return entity;
		}
		
		public override Room FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RoomID == key);
			return entity;
		}
		
		public override async Task<Room> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RoomID == key);
			return entity;
		}
		
		public override async Task<Room> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RoomID == key);
			return entity;
		}
		
		public override Room Activate(Room entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Room Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Room Deactivate(Room entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Room Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Room> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Room> GetActive(Expression<Func<Room, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
