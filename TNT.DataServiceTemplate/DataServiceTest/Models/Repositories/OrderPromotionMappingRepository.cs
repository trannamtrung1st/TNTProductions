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
	public partial interface IOrderPromotionMappingRepository : IBaseRepository<OrderPromotionMapping, int>
	{
	}
	
	public partial class OrderPromotionMappingRepository : BaseRepository<OrderPromotionMapping, int>, IOrderPromotionMappingRepository
	{
		public OrderPromotionMappingRepository() : base()
		{
		}
		
		public OrderPromotionMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderPromotionMapping Add(OrderPromotionMapping entity)
		{
			entity.Active = true;
			entity = context.OrderPromotionMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> AddAsync(OrderPromotionMapping entity)
		{
			entity.Active = true;
			entity = context.OrderPromotionMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderPromotionMapping Delete(OrderPromotionMapping entity)
		{
			context.OrderPromotionMappings.Attach(entity);
			entity = context.OrderPromotionMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> DeleteAsync(OrderPromotionMapping entity)
		{
			context.OrderPromotionMappings.Attach(entity);
			entity = context.OrderPromotionMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderPromotionMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderPromotionMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderPromotionMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderPromotionMapping FindById(int key)
		{
			var entity = context.OrderPromotionMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override OrderPromotionMapping FindActiveById(int key)
		{
			var entity = context.OrderPromotionMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> FindByIdAsync(int key)
		{
			var entity = await context.OrderPromotionMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.OrderPromotionMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override OrderPromotionMapping FindByIdInclude<TProperty>(int key, params Expression<Func<OrderPromotionMapping, TProperty>>[] members)
		{
			IQueryable<OrderPromotionMapping> dbSet = context.OrderPromotionMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<OrderPromotionMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<OrderPromotionMapping, TProperty>>[] members)
		{
			IQueryable<OrderPromotionMapping> dbSet = context.OrderPromotionMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override OrderPromotionMapping Activate(OrderPromotionMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override OrderPromotionMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override OrderPromotionMapping Deactivate(OrderPromotionMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override OrderPromotionMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<OrderPromotionMapping> GetActive()
		{
			return context.OrderPromotionMappings.Where(e => e.Active);
		}
		
		public override IQueryable<OrderPromotionMapping> GetActive(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return context.OrderPromotionMappings.Where(e => e.Active).Where(expr);
		}
		
		public override OrderPromotionMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override OrderPromotionMapping FirstOrDefault(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<OrderPromotionMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<OrderPromotionMapping> FirstOrDefaultAsync(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override OrderPromotionMapping SingleOrDefault(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<OrderPromotionMapping> SingleOrDefaultAsync(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override OrderPromotionMapping Update(OrderPromotionMapping entity)
		{
			entity = context.OrderPromotionMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderPromotionMapping> UpdateAsync(OrderPromotionMapping entity)
		{
			entity = context.OrderPromotionMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
