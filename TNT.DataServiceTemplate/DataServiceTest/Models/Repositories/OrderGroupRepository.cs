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
	public partial interface IOrderGroupRepository : IBaseRepository<OrderGroup, int>
	{
	}
	
	public partial class OrderGroupRepository : BaseRepository<OrderGroup, int>, IOrderGroupRepository
	{
		public OrderGroupRepository() : base()
		{
		}
		
		public OrderGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override OrderGroup Add(OrderGroup entity)
		{
			
			entity = context.OrderGroups.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderGroup> AddAsync(OrderGroup entity)
		{
			
			entity = context.OrderGroups.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderGroup Delete(OrderGroup entity)
		{
			context.OrderGroups.Attach(entity);
			entity = context.OrderGroups.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderGroup> DeleteAsync(OrderGroup entity)
		{
			context.OrderGroups.Attach(entity);
			entity = context.OrderGroups.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderGroup Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderGroups.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderGroup> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.OrderGroups.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override OrderGroup FindById(int key)
		{
			var entity = context.OrderGroups.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override OrderGroup FindActiveById(int key)
		{
			var entity = context.OrderGroups.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<OrderGroup> FindByIdAsync(int key)
		{
			var entity = await context.OrderGroups.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<OrderGroup> FindActiveByIdAsync(int key)
		{
			var entity = await context.OrderGroups.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override OrderGroup FindByIdInclude<TProperty>(int key, params Expression<Func<OrderGroup, TProperty>>[] members)
		{
			IQueryable<OrderGroup> dbSet = context.OrderGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<OrderGroup> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<OrderGroup, TProperty>>[] members)
		{
			IQueryable<OrderGroup> dbSet = context.OrderGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override OrderGroup Activate(OrderGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderGroup Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderGroup Deactivate(OrderGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override OrderGroup Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<OrderGroup> GetActive()
		{
			return context.OrderGroups;
		}
		
		public override IQueryable<OrderGroup> GetActive(Expression<Func<OrderGroup, bool>> expr)
		{
			return context.OrderGroups.Where(expr);
		}
		
		public override OrderGroup FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override OrderGroup FirstOrDefault(Expression<Func<OrderGroup, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<OrderGroup> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<OrderGroup> FirstOrDefaultAsync(Expression<Func<OrderGroup, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override OrderGroup SingleOrDefault(Expression<Func<OrderGroup, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<OrderGroup> SingleOrDefaultAsync(Expression<Func<OrderGroup, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override OrderGroup Update(OrderGroup entity)
		{
			entity = context.OrderGroups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<OrderGroup> UpdateAsync(OrderGroup entity)
		{
			entity = context.OrderGroups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
