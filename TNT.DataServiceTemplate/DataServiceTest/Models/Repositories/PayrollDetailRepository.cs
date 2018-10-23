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
	public partial interface IPayrollDetailRepository : IBaseRepository<PayrollDetail, int>
	{
	}
	
	public partial class PayrollDetailRepository : BaseRepository<PayrollDetail, int>, IPayrollDetailRepository
	{
		public PayrollDetailRepository() : base()
		{
		}
		
		public PayrollDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayrollDetail Add(PayrollDetail entity)
		{
			entity.Active = true;
			entity = context.PayrollDetails.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollDetail> AddAsync(PayrollDetail entity)
		{
			entity.Active = true;
			entity = context.PayrollDetails.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayrollDetail Delete(PayrollDetail entity)
		{
			context.PayrollDetails.Attach(entity);
			entity = context.PayrollDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollDetail> DeleteAsync(PayrollDetail entity)
		{
			context.PayrollDetails.Attach(entity);
			entity = context.PayrollDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayrollDetail Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayrollDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollDetail> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayrollDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PayrollDetail FindById(int key)
		{
			var entity = context.PayrollDetails.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollDetail FindActiveById(int key)
		{
			var entity = context.PayrollDetails.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PayrollDetail> FindByIdAsync(int key)
		{
			var entity = await context.PayrollDetails.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.PayrollDetails.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PayrollDetail FindByIdInclude<TProperty>(int key, params Expression<Func<PayrollDetail, TProperty>>[] members)
		{
			IQueryable<PayrollDetail> dbSet = context.PayrollDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PayrollDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PayrollDetail, TProperty>>[] members)
		{
			IQueryable<PayrollDetail> dbSet = context.PayrollDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PayrollDetail Activate(PayrollDetail entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PayrollDetail Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PayrollDetail Deactivate(PayrollDetail entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PayrollDetail Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PayrollDetail> GetActive()
		{
			return context.PayrollDetails.Where(e => e.Active);
		}
		
		public override IQueryable<PayrollDetail> GetActive(Expression<Func<PayrollDetail, bool>> expr)
		{
			return context.PayrollDetails.Where(e => e.Active).Where(expr);
		}
		
		public override PayrollDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PayrollDetail FirstOrDefault(Expression<Func<PayrollDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PayrollDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PayrollDetail> FirstOrDefaultAsync(Expression<Func<PayrollDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PayrollDetail SingleOrDefault(Expression<Func<PayrollDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PayrollDetail> SingleOrDefaultAsync(Expression<Func<PayrollDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PayrollDetail Update(PayrollDetail entity)
		{
			entity = context.PayrollDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PayrollDetail> UpdateAsync(PayrollDetail entity)
		{
			entity = context.PayrollDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
