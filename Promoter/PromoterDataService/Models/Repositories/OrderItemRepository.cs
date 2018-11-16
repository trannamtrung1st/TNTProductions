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
	public partial interface IOrderItemRepository : IBaseRepository<OrderItem, int>
	{
	}
	
	public partial class OrderItemRepository : BaseRepository<OrderItem, int>, IOrderItemRepository
	{
		public OrderItemRepository() : base()
		{
		}
		
		public OrderItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderItem Add(OrderItem entity)
		{
			
			entity = context.OrderItems.Add(entity);
			return entity;
		}
		
		public override OrderItem Remove(OrderItem entity)
		{
			context.OrderItems.Attach(entity);
			entity = context.OrderItems.Remove(entity);
			return entity;
		}
		
		public override OrderItem Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderItems.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<OrderItem> RemoveIf(Expression<Func<OrderItem, bool>> expr)
		{
			return context.OrderItems.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<OrderItem> RemoveRange(IEnumerable<OrderItem> list)
		{
			return context.OrderItems.RemoveRange(list);
		}
		
		public override OrderItem FindById(int key)
		{
			var entity = context.OrderItems.FirstOrDefault(
				e => e.IID == key);
			return entity;
		}
		
		public override OrderItem FindActiveById(int key)
		{
			var entity = context.OrderItems.FirstOrDefault(
				e => e.IID == key);
			return entity;
		}
		
		public override async Task<OrderItem> FindByIdAsync(int key)
		{
			var entity = await context.OrderItems.FirstOrDefaultAsync(
				e => e.IID == key);
			return entity;
		}
		
		public override async Task<OrderItem> FindActiveByIdAsync(int key)
		{
			var entity = await context.OrderItems.FirstOrDefaultAsync(
				e => e.IID == key);
			return entity;
		}
		
		public override OrderItem FindByIdInclude<TProperty>(int key, params Expression<Func<OrderItem, TProperty>>[] members)
		{
			IQueryable<OrderItem> dbSet = context.OrderItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.IID == key);
		}
		
		public override async Task<OrderItem> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<OrderItem, TProperty>>[] members)
		{
			IQueryable<OrderItem> dbSet = context.OrderItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.IID == key);
		}
		
		public override OrderItem Activate(OrderItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderItem Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderItem Deactivate(OrderItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderItem Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<OrderItem> GetActive()
		{
			return context.OrderItems;
		}
		
		public override IQueryable<OrderItem> GetActive(Expression<Func<OrderItem, bool>> expr)
		{
			return context.OrderItems.Where(expr);
		}
		
		public override OrderItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override OrderItem FirstOrDefault(Expression<Func<OrderItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<OrderItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<OrderItem> FirstOrDefaultAsync(Expression<Func<OrderItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override OrderItem SingleOrDefault(Expression<Func<OrderItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<OrderItem> SingleOrDefaultAsync(Expression<Func<OrderItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override OrderItem Update(OrderItem entity)
		{
			entity = context.OrderItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
