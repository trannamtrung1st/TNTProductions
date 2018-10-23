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
	public partial interface IOrderDetailRepository : IBaseRepository<OrderDetail, int>
	{
	}
	
	public partial class OrderDetailRepository : BaseRepository<OrderDetail, int>, IOrderDetailRepository
	{
		public OrderDetailRepository() : base()
		{
		}
		
		public OrderDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderDetail Add(OrderDetail entity)
		{
			
			entity = context.OrderDetails.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderDetail> AddAsync(OrderDetail entity)
		{
			
			entity = context.OrderDetails.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderDetail Delete(OrderDetail entity)
		{
			context.OrderDetails.Attach(entity);
			entity = context.OrderDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderDetail> DeleteAsync(OrderDetail entity)
		{
			context.OrderDetails.Attach(entity);
			entity = context.OrderDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderDetail Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderDetail> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderDetail FindById(int key)
		{
			var entity = context.OrderDetails.FirstOrDefault(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override OrderDetail FindActiveById(int key)
		{
			var entity = context.OrderDetails.FirstOrDefault(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override async Task<OrderDetail> FindByIdAsync(int key)
		{
			var entity = await context.OrderDetails.FirstOrDefaultAsync(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override async Task<OrderDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.OrderDetails.FirstOrDefaultAsync(
				e => e.OrderDetailID == key);
			return entity;
		}
		
		public override OrderDetail FindByIdInclude<TProperty>(int key, params Expression<Func<OrderDetail, TProperty>>[] members)
		{
			IQueryable<OrderDetail> dbSet = context.OrderDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.OrderDetailID == key);
		}
		
		public override async Task<OrderDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<OrderDetail, TProperty>>[] members)
		{
			IQueryable<OrderDetail> dbSet = context.OrderDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.OrderDetailID == key);
		}
		
		public override OrderDetail Activate(OrderDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderDetail Deactivate(OrderDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<OrderDetail> GetActive()
		{
			return context.OrderDetails;
		}
		
		public override IQueryable<OrderDetail> GetActive(Expression<Func<OrderDetail, bool>> expr)
		{
			return context.OrderDetails.Where(expr);
		}
		
		public override OrderDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override OrderDetail FirstOrDefault(Expression<Func<OrderDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<OrderDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<OrderDetail> FirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override OrderDetail SingleOrDefault(Expression<Func<OrderDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<OrderDetail> SingleOrDefaultAsync(Expression<Func<OrderDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override OrderDetail Update(OrderDetail entity)
		{
			entity = context.OrderDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderDetail> UpdateAsync(OrderDetail entity)
		{
			entity = context.OrderDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
