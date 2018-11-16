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
	public partial interface IOrderDetailPromotionMappingRepository : IBaseRepository<OrderDetailPromotionMapping, int>
	{
	}
	
	public partial class OrderDetailPromotionMappingRepository : BaseRepository<OrderDetailPromotionMapping, int>, IOrderDetailPromotionMappingRepository
	{
		public OrderDetailPromotionMappingRepository() : base()
		{
		}
		
		public OrderDetailPromotionMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderDetailPromotionMapping Add(OrderDetailPromotionMapping entity)
		{
			entity.Active = true;
			entity = context.OrderDetailPromotionMappings.Add(entity);
			return entity;
		}
		
		public override OrderDetailPromotionMapping Remove(OrderDetailPromotionMapping entity)
		{
			context.OrderDetailPromotionMappings.Attach(entity);
			entity = context.OrderDetailPromotionMappings.Remove(entity);
			return entity;
		}
		
		public override OrderDetailPromotionMapping Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderDetailPromotionMappings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<OrderDetailPromotionMapping> RemoveIf(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return context.OrderDetailPromotionMappings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<OrderDetailPromotionMapping> RemoveRange(IEnumerable<OrderDetailPromotionMapping> list)
		{
			return context.OrderDetailPromotionMappings.RemoveRange(list);
		}
		
		public override OrderDetailPromotionMapping FindById(int key)
		{
			var entity = context.OrderDetailPromotionMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override OrderDetailPromotionMapping FindActiveById(int key)
		{
			var entity = context.OrderDetailPromotionMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<OrderDetailPromotionMapping> FindByIdAsync(int key)
		{
			var entity = await context.OrderDetailPromotionMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<OrderDetailPromotionMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.OrderDetailPromotionMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override OrderDetailPromotionMapping FindByIdInclude<TProperty>(int key, params Expression<Func<OrderDetailPromotionMapping, TProperty>>[] members)
		{
			IQueryable<OrderDetailPromotionMapping> dbSet = context.OrderDetailPromotionMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<OrderDetailPromotionMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<OrderDetailPromotionMapping, TProperty>>[] members)
		{
			IQueryable<OrderDetailPromotionMapping> dbSet = context.OrderDetailPromotionMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override OrderDetailPromotionMapping Activate(OrderDetailPromotionMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override OrderDetailPromotionMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override OrderDetailPromotionMapping Deactivate(OrderDetailPromotionMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override OrderDetailPromotionMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<OrderDetailPromotionMapping> GetActive()
		{
			return context.OrderDetailPromotionMappings.Where(e => e.Active);
		}
		
		public override IQueryable<OrderDetailPromotionMapping> GetActive(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return context.OrderDetailPromotionMappings.Where(e => e.Active).Where(expr);
		}
		
		public override OrderDetailPromotionMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override OrderDetailPromotionMapping FirstOrDefault(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<OrderDetailPromotionMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<OrderDetailPromotionMapping> FirstOrDefaultAsync(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override OrderDetailPromotionMapping SingleOrDefault(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<OrderDetailPromotionMapping> SingleOrDefaultAsync(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override OrderDetailPromotionMapping Update(OrderDetailPromotionMapping entity)
		{
			entity = context.OrderDetailPromotionMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
