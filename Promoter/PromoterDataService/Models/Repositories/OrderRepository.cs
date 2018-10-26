using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface IOrderRepository : IBaseRepository<Order, int>
	{
	}
	
	public partial class OrderRepository : BaseRepository<Order, int>, IOrderRepository
	{
		public OrderRepository() : base()
		{
		}
		
		public OrderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Order Add(Order entity)
		{
			
			entity = context.Orders.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Order> AddAsync(Order entity)
		{
			
			entity = context.Orders.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Order Delete(Order entity)
		{
			context.Orders.Attach(entity);
			entity = context.Orders.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Order> DeleteAsync(Order entity)
		{
			context.Orders.Attach(entity);
			entity = context.Orders.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Order Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Orders.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Order> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Orders.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Order FindById(int key)
		{
			var entity = context.Orders.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Order FindActiveById(int key)
		{
			var entity = context.Orders.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Order> FindByIdAsync(int key)
		{
			var entity = await context.Orders.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Order> FindActiveByIdAsync(int key)
		{
			var entity = await context.Orders.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Order FindByIdInclude<TProperty>(int key, params Expression<Func<Order, TProperty>>[] members)
		{
			IQueryable<Order> dbSet = context.Orders;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Order> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Order, TProperty>>[] members)
		{
			IQueryable<Order> dbSet = context.Orders;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Order Activate(Order entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Order Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Order Deactivate(Order entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Order Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Order> GetActive()
		{
			return context.Orders;
		}
		
		public override IQueryable<Order> GetActive(Expression<Func<Order, bool>> expr)
		{
			return context.Orders.Where(expr);
		}
		
		public override Order FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Order FirstOrDefault(Expression<Func<Order, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Order> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Order SingleOrDefault(Expression<Func<Order, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Order> SingleOrDefaultAsync(Expression<Func<Order, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Order Update(Order entity)
		{
			entity = context.Orders.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Order> UpdateAsync(Order entity)
		{
			entity = context.Orders.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
