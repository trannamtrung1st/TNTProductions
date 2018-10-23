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
	public partial interface ICustomerFeedbackRepository : IBaseRepository<CustomerFeedback, CustomerFeedbackPK>
	{
	}
	
	public partial class CustomerFeedbackRepository : BaseRepository<CustomerFeedback, CustomerFeedbackPK>, ICustomerFeedbackRepository
	{
		public CustomerFeedbackRepository() : base()
		{
		}
		
		public CustomerFeedbackRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CustomerFeedback Add(CustomerFeedback entity)
		{
			entity.Active = true;
			entity = context.CustomerFeedbacks.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerFeedback> AddAsync(CustomerFeedback entity)
		{
			entity.Active = true;
			entity = context.CustomerFeedbacks.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerFeedback Delete(CustomerFeedback entity)
		{
			context.CustomerFeedbacks.Attach(entity);
			entity = context.CustomerFeedbacks.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerFeedback> DeleteAsync(CustomerFeedback entity)
		{
			context.CustomerFeedbacks.Attach(entity);
			entity = context.CustomerFeedbacks.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerFeedback Delete(CustomerFeedbackPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerFeedbacks.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerFeedback> DeleteAsync(CustomerFeedbackPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CustomerFeedbacks.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CustomerFeedback FindById(CustomerFeedbackPK key)
		{
			var entity = context.CustomerFeedbacks.FirstOrDefault(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active);
			return entity;
		}
		
		public override CustomerFeedback FindActiveById(CustomerFeedbackPK key)
		{
			var entity = context.CustomerFeedbacks.FirstOrDefault(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active && e.Active);
			return entity;
		}
		
		public override async Task<CustomerFeedback> FindByIdAsync(CustomerFeedbackPK key)
		{
			var entity = await context.CustomerFeedbacks.FirstOrDefaultAsync(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active);
			return entity;
		}
		
		public override async Task<CustomerFeedback> FindActiveByIdAsync(CustomerFeedbackPK key)
		{
			var entity = await context.CustomerFeedbacks.FirstOrDefaultAsync(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active && e.Active);
			return entity;
		}
		
		public override CustomerFeedback FindByIdInclude<TProperty>(CustomerFeedbackPK key, params Expression<Func<CustomerFeedback, TProperty>>[] members)
		{
			IQueryable<CustomerFeedback> dbSet = context.CustomerFeedbacks;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active);
		}
		
		public override async Task<CustomerFeedback> FindByIdIncludeAsync<TProperty>(CustomerFeedbackPK key, params Expression<Func<CustomerFeedback, TProperty>>[] members)
		{
			IQueryable<CustomerFeedback> dbSet = context.CustomerFeedbacks;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key.Id && e.StoreId == key.StoreId && e.Active == key.Active);
		}
		
		public override CustomerFeedback Activate(CustomerFeedback entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override CustomerFeedback Activate(CustomerFeedbackPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override CustomerFeedback Deactivate(CustomerFeedback entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override CustomerFeedback Deactivate(CustomerFeedbackPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<CustomerFeedback> GetActive()
		{
			return context.CustomerFeedbacks.Where(e => e.Active);
		}
		
		public override IQueryable<CustomerFeedback> GetActive(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return context.CustomerFeedbacks.Where(e => e.Active).Where(expr);
		}
		
		public override CustomerFeedback FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CustomerFeedback FirstOrDefault(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CustomerFeedback> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CustomerFeedback> FirstOrDefaultAsync(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CustomerFeedback SingleOrDefault(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CustomerFeedback> SingleOrDefaultAsync(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CustomerFeedback Update(CustomerFeedback entity)
		{
			entity = context.CustomerFeedbacks.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CustomerFeedback> UpdateAsync(CustomerFeedback entity)
		{
			entity = context.CustomerFeedbacks.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
