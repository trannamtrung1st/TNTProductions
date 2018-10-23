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
	public partial interface IOrderFeeItemRepository : IBaseRepository<OrderFeeItem, int>
	{
	}
	
	public partial class OrderFeeItemRepository : BaseRepository<OrderFeeItem, int>, IOrderFeeItemRepository
	{
		public OrderFeeItemRepository() : base()
		{
		}
		
		public OrderFeeItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderFeeItem Add(OrderFeeItem entity)
		{
			
			entity = context.OrderFeeItems.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderFeeItem> AddAsync(OrderFeeItem entity)
		{
			
			entity = context.OrderFeeItems.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderFeeItem Delete(OrderFeeItem entity)
		{
			context.OrderFeeItems.Attach(entity);
			entity = context.OrderFeeItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderFeeItem> DeleteAsync(OrderFeeItem entity)
		{
			context.OrderFeeItems.Attach(entity);
			entity = context.OrderFeeItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderFeeItem Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderFeeItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderFeeItem> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderFeeItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderFeeItem FindById(int key)
		{
			var entity = context.OrderFeeItems.FirstOrDefault(
				e => e.OrderId == key);
			return entity;
		}
		
		public override OrderFeeItem FindActiveById(int key)
		{
			var entity = context.OrderFeeItems.FirstOrDefault(
				e => e.OrderId == key);
			return entity;
		}
		
		public override async Task<OrderFeeItem> FindByIdAsync(int key)
		{
			var entity = await context.OrderFeeItems.FirstOrDefaultAsync(
				e => e.OrderId == key);
			return entity;
		}
		
		public override async Task<OrderFeeItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.OrderFeeItems.FirstOrDefaultAsync(
				e => e.OrderId == key);
			return entity;
		}
		
		public override OrderFeeItem FindByIdInclude<TProperty>(int key, params Expression<Func<OrderFeeItem, TProperty>>[] members)
		{
			IQueryable<OrderFeeItem> dbSet = context.OrderFeeItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.OrderId == key);
		}
		
		public override async Task<OrderFeeItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<OrderFeeItem, TProperty>>[] members)
		{
			IQueryable<OrderFeeItem> dbSet = context.OrderFeeItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.OrderId == key);
		}
		
		public override OrderFeeItem Activate(OrderFeeItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderFeeItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderFeeItem Deactivate(OrderFeeItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderFeeItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<OrderFeeItem> GetActive()
		{
			return context.OrderFeeItems;
		}
		
		public override IQueryable<OrderFeeItem> GetActive(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return context.OrderFeeItems.Where(expr);
		}
		
		public override OrderFeeItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override OrderFeeItem FirstOrDefault(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<OrderFeeItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<OrderFeeItem> FirstOrDefaultAsync(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override OrderFeeItem SingleOrDefault(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<OrderFeeItem> SingleOrDefaultAsync(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override OrderFeeItem Update(OrderFeeItem entity)
		{
			entity = context.OrderFeeItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderFeeItem> UpdateAsync(OrderFeeItem entity)
		{
			entity = context.OrderFeeItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
