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
		public RoomRepository() : base()
		{
		}
		
		public RoomRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Room Add(Room entity)
		{
			
			entity = context.Rooms.Add(entity);
			return entity;
		}
		
		public override Room Remove(Room entity)
		{
			context.Rooms.Attach(entity);
			entity = context.Rooms.Remove(entity);
			return entity;
		}
		
		public override Room Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Rooms.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Room> RemoveIf(Expression<Func<Room, bool>> expr)
		{
			return context.Rooms.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Room> RemoveRange(IEnumerable<Room> list)
		{
			return context.Rooms.RemoveRange(list);
		}
		
		public override Room FindById(int key)
		{
			var entity = context.Rooms.FirstOrDefault(
				e => e.RoomID == key);
			return entity;
		}
		
		public override Room FindActiveById(int key)
		{
			var entity = context.Rooms.FirstOrDefault(
				e => e.RoomID == key);
			return entity;
		}
		
		public override async Task<Room> FindByIdAsync(int key)
		{
			var entity = await context.Rooms.FirstOrDefaultAsync(
				e => e.RoomID == key);
			return entity;
		}
		
		public override async Task<Room> FindActiveByIdAsync(int key)
		{
			var entity = await context.Rooms.FirstOrDefaultAsync(
				e => e.RoomID == key);
			return entity;
		}
		
		public override Room FindByIdInclude<TProperty>(int key, params Expression<Func<Room, TProperty>>[] members)
		{
			IQueryable<Room> dbSet = context.Rooms;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.RoomID == key);
		}
		
		public override async Task<Room> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Room, TProperty>>[] members)
		{
			IQueryable<Room> dbSet = context.Rooms;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.RoomID == key);
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
			return context.Rooms;
		}
		
		public override IQueryable<Room> GetActive(Expression<Func<Room, bool>> expr)
		{
			return context.Rooms.Where(expr);
		}
		
		public override Room FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Room FirstOrDefault(Expression<Func<Room, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Room> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Room> FirstOrDefaultAsync(Expression<Func<Room, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Room SingleOrDefault(Expression<Func<Room, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Room> SingleOrDefaultAsync(Expression<Func<Room, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Room Update(Room entity)
		{
			entity = context.Rooms.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
