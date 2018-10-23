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
	public partial interface IPayrollCategoryRepository : IBaseRepository<PayrollCategory, int>
	{
	}
	
	public partial class PayrollCategoryRepository : BaseRepository<PayrollCategory, int>, IPayrollCategoryRepository
	{
		public PayrollCategoryRepository() : base()
		{
		}
		
		public PayrollCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayrollCategory Add(PayrollCategory entity)
		{
			entity.Active = true;
			entity = context.PayrollCategories.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollCategory> AddAsync(PayrollCategory entity)
		{
			entity.Active = true;
			entity = context.PayrollCategories.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayrollCategory Delete(PayrollCategory entity)
		{
			context.PayrollCategories.Attach(entity);
			entity = context.PayrollCategories.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollCategory> DeleteAsync(PayrollCategory entity)
		{
			context.PayrollCategories.Attach(entity);
			entity = context.PayrollCategories.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayrollCategory Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayrollCategories.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollCategory> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayrollCategories.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayrollCategory FindById(int key)
		{
			var entity = context.PayrollCategories.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollCategory FindActiveById(int key)
		{
			var entity = context.PayrollCategories.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayrollCategory> FindByIdAsync(int key)
		{
			var entity = await context.PayrollCategories.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.PayrollCategories.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayrollCategory FindByIdInclude<TProperty>(int key, params Expression<Func<PayrollCategory, TProperty>>[] members)
		{
			IQueryable<PayrollCategory> dbSet = context.PayrollCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PayrollCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PayrollCategory, TProperty>>[] members)
		{
			IQueryable<PayrollCategory> dbSet = context.PayrollCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PayrollCategory Activate(PayrollCategory entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayrollCategory Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayrollCategory Deactivate(PayrollCategory entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayrollCategory Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayrollCategory> GetActive()
		{
			return context.PayrollCategories.Where(e => e.Active);
		}
		
		public override IQueryable<PayrollCategory> GetActive(Expression<Func<PayrollCategory, bool>> expr)
		{
			return context.PayrollCategories.Where(e => e.Active).Where(expr);
		}
		
		public override PayrollCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PayrollCategory FirstOrDefault(Expression<Func<PayrollCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PayrollCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PayrollCategory> FirstOrDefaultAsync(Expression<Func<PayrollCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PayrollCategory SingleOrDefault(Expression<Func<PayrollCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PayrollCategory> SingleOrDefaultAsync(Expression<Func<PayrollCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PayrollCategory Update(PayrollCategory entity)
		{
			entity = context.PayrollCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollCategory> UpdateAsync(PayrollCategory entity)
		{
			entity = context.PayrollCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
