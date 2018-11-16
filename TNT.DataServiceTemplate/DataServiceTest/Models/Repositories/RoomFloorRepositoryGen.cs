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
		public RoomFloorRepository() : base()
		{
		}
		
		public RoomFloorRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RoomFloor Add(RoomFloor entity)
		{
			
			entity = context.RoomFloors.Add(entity);
			return entity;
		}
		
		public override RoomFloor Remove(RoomFloor entity)
		{
			context.RoomFloors.Attach(entity);
			entity = context.RoomFloors.Remove(entity);
			return entity;
		}
		
		public override RoomFloor Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RoomFloors.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<RoomFloor> RemoveIf(Expression<Func<RoomFloor, bool>> expr)
		{
			return context.RoomFloors.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<RoomFloor> RemoveRange(IEnumerable<RoomFloor> list)
		{
			return context.RoomFloors.RemoveRange(list);
		}
		
		public override RoomFloor FindById(int key)
		{
			var entity = context.RoomFloors.FirstOrDefault(
				e => e.FloorID == key);
			return entity;
		}
		
		public override RoomFloor FindActiveById(int key)
		{
			var entity = context.RoomFloors.FirstOrDefault(
				e => e.FloorID == key);
			return entity;
		}
		
		public override async Task<RoomFloor> FindByIdAsync(int key)
		{
			var entity = await context.RoomFloors.FirstOrDefaultAsync(
				e => e.FloorID == key);
			return entity;
		}
		
		public override async Task<RoomFloor> FindActiveByIdAsync(int key)
		{
			var entity = await context.RoomFloors.FirstOrDefaultAsync(
				e => e.FloorID == key);
			return entity;
		}
		
		public override RoomFloor FindByIdInclude<TProperty>(int key, params Expression<Func<RoomFloor, TProperty>>[] members)
		{
			IQueryable<RoomFloor> dbSet = context.RoomFloors;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.FloorID == key);
		}
		
		public override async Task<RoomFloor> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<RoomFloor, TProperty>>[] members)
		{
			IQueryable<RoomFloor> dbSet = context.RoomFloors;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.FloorID == key);
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
			return context.RoomFloors;
		}
		
		public override IQueryable<RoomFloor> GetActive(Expression<Func<RoomFloor, bool>> expr)
		{
			return context.RoomFloors.Where(expr);
		}
		
		public override RoomFloor FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override RoomFloor FirstOrDefault(Expression<Func<RoomFloor, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<RoomFloor> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<RoomFloor> FirstOrDefaultAsync(Expression<Func<RoomFloor, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override RoomFloor SingleOrDefault(Expression<Func<RoomFloor, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<RoomFloor> SingleOrDefaultAsync(Expression<Func<RoomFloor, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override RoomFloor Update(RoomFloor entity)
		{
			entity = context.RoomFloors.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
