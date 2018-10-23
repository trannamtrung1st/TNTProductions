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
	public partial interface IInventoryCheckingRepository : IBaseRepository<InventoryChecking, int>
	{
	}
	
	public partial class InventoryCheckingRepository : BaseRepository<InventoryChecking, int>, IInventoryCheckingRepository
	{
		public InventoryCheckingRepository() : base()
		{
		}
		
		public InventoryCheckingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryChecking Add(InventoryChecking entity)
		{
			
			entity = context.InventoryCheckings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryChecking> AddAsync(InventoryChecking entity)
		{
			
			entity = context.InventoryCheckings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryChecking Delete(InventoryChecking entity)
		{
			context.InventoryCheckings.Attach(entity);
			entity = context.InventoryCheckings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryChecking> DeleteAsync(InventoryChecking entity)
		{
			context.InventoryCheckings.Attach(entity);
			entity = context.InventoryCheckings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryChecking Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryCheckings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryChecking> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryCheckings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryChecking FindById(int key)
		{
			var entity = context.InventoryCheckings.FirstOrDefault(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override InventoryChecking FindActiveById(int key)
		{
			var entity = context.InventoryCheckings.FirstOrDefault(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override async Task<InventoryChecking> FindByIdAsync(int key)
		{
			var entity = await context.InventoryCheckings.FirstOrDefaultAsync(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override async Task<InventoryChecking> FindActiveByIdAsync(int key)
		{
			var entity = await context.InventoryCheckings.FirstOrDefaultAsync(
				e => e.CheckingId == key);
			return entity;
		}
		
		public override InventoryChecking FindByIdInclude<TProperty>(int key, params Expression<Func<InventoryChecking, TProperty>>[] members)
		{
			IQueryable<InventoryChecking> dbSet = context.InventoryCheckings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CheckingId == key);
		}
		
		public override async Task<InventoryChecking> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<InventoryChecking, TProperty>>[] members)
		{
			IQueryable<InventoryChecking> dbSet = context.InventoryCheckings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CheckingId == key);
		}
		
		public override InventoryChecking Activate(InventoryChecking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryChecking Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryChecking Deactivate(InventoryChecking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryChecking Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryChecking> GetActive()
		{
			return context.InventoryCheckings;
		}
		
		public override IQueryable<InventoryChecking> GetActive(Expression<Func<InventoryChecking, bool>> expr)
		{
			return context.InventoryCheckings.Where(expr);
		}
		
		public override InventoryChecking FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryChecking FirstOrDefault(Expression<Func<InventoryChecking, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryChecking> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryChecking> FirstOrDefaultAsync(Expression<Func<InventoryChecking, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryChecking SingleOrDefault(Expression<Func<InventoryChecking, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryChecking> SingleOrDefaultAsync(Expression<Func<InventoryChecking, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryChecking Update(InventoryChecking entity)
		{
			entity = context.InventoryCheckings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryChecking> UpdateAsync(InventoryChecking entity)
		{
			entity = context.InventoryCheckings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
