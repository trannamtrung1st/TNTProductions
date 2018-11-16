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
	public partial interface IGuestRepository : IBaseRepository<Guest, int>
	{
	}
	
	public partial class GuestRepository : BaseRepository<Guest, int>, IGuestRepository
	{
		public GuestRepository() : base()
		{
		}
		
		public GuestRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Guest Add(Guest entity)
		{
			
			entity = context.Guests.Add(entity);
			return entity;
		}
		
		public override Guest Remove(Guest entity)
		{
			context.Guests.Attach(entity);
			entity = context.Guests.Remove(entity);
			return entity;
		}
		
		public override Guest Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Guests.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Guest> RemoveIf(Expression<Func<Guest, bool>> expr)
		{
			return context.Guests.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Guest> RemoveRange(IEnumerable<Guest> list)
		{
			return context.Guests.RemoveRange(list);
		}
		
		public override Guest FindById(int key)
		{
			var entity = context.Guests.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Guest FindActiveById(int key)
		{
			var entity = context.Guests.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Guest> FindByIdAsync(int key)
		{
			var entity = await context.Guests.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Guest> FindActiveByIdAsync(int key)
		{
			var entity = await context.Guests.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Guest FindByIdInclude<TProperty>(int key, params Expression<Func<Guest, TProperty>>[] members)
		{
			IQueryable<Guest> dbSet = context.Guests;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Guest> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Guest, TProperty>>[] members)
		{
			IQueryable<Guest> dbSet = context.Guests;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Guest Activate(Guest entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Guest Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Guest Deactivate(Guest entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Guest Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Guest> GetActive()
		{
			return context.Guests;
		}
		
		public override IQueryable<Guest> GetActive(Expression<Func<Guest, bool>> expr)
		{
			return context.Guests.Where(expr);
		}
		
		public override Guest FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Guest FirstOrDefault(Expression<Func<Guest, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Guest> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Guest> FirstOrDefaultAsync(Expression<Func<Guest, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Guest SingleOrDefault(Expression<Func<Guest, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Guest> SingleOrDefaultAsync(Expression<Func<Guest, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Guest Update(Guest entity)
		{
			entity = context.Guests.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
