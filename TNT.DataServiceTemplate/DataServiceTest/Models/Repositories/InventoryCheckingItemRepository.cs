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
	public partial interface IInventoryCheckingItemRepository : IBaseRepository<InventoryCheckingItem, int>
	{
	}
	
	public partial class InventoryCheckingItemRepository : BaseRepository<InventoryCheckingItem, int>, IInventoryCheckingItemRepository
	{
		public InventoryCheckingItemRepository() : base()
		{
		}
		
		public InventoryCheckingItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryCheckingItem Add(InventoryCheckingItem entity)
		{
			
			entity = context.InventoryCheckingItems.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> AddAsync(InventoryCheckingItem entity)
		{
			
			entity = context.InventoryCheckingItems.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryCheckingItem Delete(InventoryCheckingItem entity)
		{
			context.InventoryCheckingItems.Attach(entity);
			entity = context.InventoryCheckingItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> DeleteAsync(InventoryCheckingItem entity)
		{
			context.InventoryCheckingItems.Attach(entity);
			entity = context.InventoryCheckingItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryCheckingItem Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryCheckingItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryCheckingItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryCheckingItem FindById(int key)
		{
			var entity = context.InventoryCheckingItems.FirstOrDefault(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override InventoryCheckingItem FindActiveById(int key)
		{
			var entity = context.InventoryCheckingItems.FirstOrDefault(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> FindByIdAsync(int key)
		{
			var entity = await context.InventoryCheckingItems.FirstOrDefaultAsync(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.InventoryCheckingItems.FirstOrDefaultAsync(
				e => e.InventoryCheckingID == key);
			return entity;
		}
		
		public override InventoryCheckingItem FindByIdInclude<TProperty>(int key, params Expression<Func<InventoryCheckingItem, TProperty>>[] members)
		{
			IQueryable<InventoryCheckingItem> dbSet = context.InventoryCheckingItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.InventoryCheckingID == key);
		}
		
		public override async Task<InventoryCheckingItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<InventoryCheckingItem, TProperty>>[] members)
		{
			IQueryable<InventoryCheckingItem> dbSet = context.InventoryCheckingItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.InventoryCheckingID == key);
		}
		
		public override InventoryCheckingItem Activate(InventoryCheckingItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryCheckingItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryCheckingItem Deactivate(InventoryCheckingItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryCheckingItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryCheckingItem> GetActive()
		{
			return context.InventoryCheckingItems;
		}
		
		public override IQueryable<InventoryCheckingItem> GetActive(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return context.InventoryCheckingItems.Where(expr);
		}
		
		public override InventoryCheckingItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryCheckingItem FirstOrDefault(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryCheckingItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryCheckingItem> FirstOrDefaultAsync(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryCheckingItem SingleOrDefault(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryCheckingItem> SingleOrDefaultAsync(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryCheckingItem Update(InventoryCheckingItem entity)
		{
			entity = context.InventoryCheckingItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryCheckingItem> UpdateAsync(InventoryCheckingItem entity)
		{
			entity = context.InventoryCheckingItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
