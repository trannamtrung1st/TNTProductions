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
	public partial interface IPriceNightRepository : IBaseRepository<PriceNight, int>
	{
	}
	
	public partial class PriceNightRepository : BaseRepository<PriceNight, int>, IPriceNightRepository
	{
		public PriceNightRepository() : base()
		{
		}
		
		public PriceNightRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PriceNight Add(PriceNight entity)
		{
			
			entity = context.PriceNights.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceNight> AddAsync(PriceNight entity)
		{
			
			entity = context.PriceNights.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PriceNight Delete(PriceNight entity)
		{
			context.PriceNights.Attach(entity);
			entity = context.PriceNights.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceNight> DeleteAsync(PriceNight entity)
		{
			context.PriceNights.Attach(entity);
			entity = context.PriceNights.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PriceNight Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PriceNights.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceNight> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PriceNights.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PriceNight FindById(int key)
		{
			var entity = context.PriceNights.FirstOrDefault(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override PriceNight FindActiveById(int key)
		{
			var entity = context.PriceNights.FirstOrDefault(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override async Task<PriceNight> FindByIdAsync(int key)
		{
			var entity = await context.PriceNights.FirstOrDefaultAsync(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override async Task<PriceNight> FindActiveByIdAsync(int key)
		{
			var entity = await context.PriceNights.FirstOrDefaultAsync(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override PriceNight FindByIdInclude<TProperty>(int key, params Expression<Func<PriceNight, TProperty>>[] members)
		{
			IQueryable<PriceNight> dbSet = context.PriceNights;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.RoomPriceID == key);
		}
		
		public override async Task<PriceNight> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PriceNight, TProperty>>[] members)
		{
			IQueryable<PriceNight> dbSet = context.PriceNights;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.RoomPriceID == key);
		}
		
		public override PriceNight Activate(PriceNight entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceNight Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceNight Deactivate(PriceNight entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceNight Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PriceNight> GetActive()
		{
			return context.PriceNights;
		}
		
		public override IQueryable<PriceNight> GetActive(Expression<Func<PriceNight, bool>> expr)
		{
			return context.PriceNights.Where(expr);
		}
		
		public override PriceNight FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PriceNight FirstOrDefault(Expression<Func<PriceNight, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PriceNight> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PriceNight> FirstOrDefaultAsync(Expression<Func<PriceNight, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PriceNight SingleOrDefault(Expression<Func<PriceNight, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PriceNight> SingleOrDefaultAsync(Expression<Func<PriceNight, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PriceNight Update(PriceNight entity)
		{
			entity = context.PriceNights.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PriceNight> UpdateAsync(PriceNight entity)
		{
			entity = context.PriceNights.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
