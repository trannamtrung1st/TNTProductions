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
	public partial interface ICustomerFilterRepository : IBaseRepository<CustomerFilter, int>
	{
	}
	
	public partial class CustomerFilterRepository : BaseRepository<CustomerFilter, int>, ICustomerFilterRepository
	{
		public CustomerFilterRepository() : base()
		{
		}
		
		public CustomerFilterRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerFilter Add(CustomerFilter entity)
		{
			entity.Active = true;
			entity = context.CustomerFilters.Add(entity);
			return entity;
		}
		
		public override CustomerFilter Remove(CustomerFilter entity)
		{
			context.CustomerFilters.Attach(entity);
			entity = context.CustomerFilters.Remove(entity);
			return entity;
		}
		
		public override CustomerFilter Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerFilters.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<CustomerFilter> RemoveIf(Expression<Func<CustomerFilter, bool>> expr)
		{
			return context.CustomerFilters.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<CustomerFilter> RemoveRange(IEnumerable<CustomerFilter> list)
		{
			return context.CustomerFilters.RemoveRange(list);
		}
		
		public override CustomerFilter FindById(int key)
		{
			var entity = context.CustomerFilters.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override CustomerFilter FindActiveById(int key)
		{
			var entity = context.CustomerFilters.FirstOrDefault(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override async Task<CustomerFilter> FindByIdAsync(int key)
		{
			var entity = await context.CustomerFilters.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<CustomerFilter> FindActiveByIdAsync(int key)
		{
			var entity = await context.CustomerFilters.FirstOrDefaultAsync(
				e => e.ID == key && e.Active);
			return entity;
		}
		
		public override CustomerFilter FindByIdInclude<TProperty>(int key, params Expression<Func<CustomerFilter, TProperty>>[] members)
		{
			IQueryable<CustomerFilter> dbSet = context.CustomerFilters;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<CustomerFilter> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CustomerFilter, TProperty>>[] members)
		{
			IQueryable<CustomerFilter> dbSet = context.CustomerFilters;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override CustomerFilter Activate(CustomerFilter entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CustomerFilter Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CustomerFilter Deactivate(CustomerFilter entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CustomerFilter Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CustomerFilter> GetActive()
		{
			return context.CustomerFilters.Where(e => e.Active);
		}
		
		public override IQueryable<CustomerFilter> GetActive(Expression<Func<CustomerFilter, bool>> expr)
		{
			return context.CustomerFilters.Where(e => e.Active).Where(expr);
		}
		
		public override CustomerFilter FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerFilter FirstOrDefault(Expression<Func<CustomerFilter, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerFilter> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerFilter> FirstOrDefaultAsync(Expression<Func<CustomerFilter, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerFilter SingleOrDefault(Expression<Func<CustomerFilter, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerFilter> SingleOrDefaultAsync(Expression<Func<CustomerFilter, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerFilter Update(CustomerFilter entity)
		{
			entity = context.CustomerFilters.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
