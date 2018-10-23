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
	public partial interface IPaySlipRepository : IBaseRepository<PaySlip, int>
	{
	}
	
	public partial class PaySlipRepository : BaseRepository<PaySlip, int>, IPaySlipRepository
	{
		public PaySlipRepository() : base()
		{
		}
		
		public PaySlipRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaySlip Add(PaySlip entity)
		{
			entity.Active = true;
			entity = context.PaySlips.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PaySlip> AddAsync(PaySlip entity)
		{
			entity.Active = true;
			entity = context.PaySlips.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PaySlip Delete(PaySlip entity)
		{
			context.PaySlips.Attach(entity);
			entity = context.PaySlips.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PaySlip> DeleteAsync(PaySlip entity)
		{
			context.PaySlips.Attach(entity);
			entity = context.PaySlips.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PaySlip Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PaySlips.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PaySlip> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PaySlips.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PaySlip FindById(int key)
		{
			var entity = context.PaySlips.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PaySlip FindActiveById(int key)
		{
			var entity = context.PaySlips.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PaySlip> FindByIdAsync(int key)
		{
			var entity = await context.PaySlips.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PaySlip> FindActiveByIdAsync(int key)
		{
			var entity = await context.PaySlips.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PaySlip FindByIdInclude<TProperty>(int key, params Expression<Func<PaySlip, TProperty>>[] members)
		{
			IQueryable<PaySlip> dbSet = context.PaySlips;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PaySlip> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PaySlip, TProperty>>[] members)
		{
			IQueryable<PaySlip> dbSet = context.PaySlips;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PaySlip Activate(PaySlip entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PaySlip Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PaySlip Deactivate(PaySlip entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PaySlip Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PaySlip> GetActive()
		{
			return context.PaySlips.Where(e => e.Active);
		}
		
		public override IQueryable<PaySlip> GetActive(Expression<Func<PaySlip, bool>> expr)
		{
			return context.PaySlips.Where(e => e.Active).Where(expr);
		}
		
		public override PaySlip FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PaySlip FirstOrDefault(Expression<Func<PaySlip, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PaySlip> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PaySlip> FirstOrDefaultAsync(Expression<Func<PaySlip, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PaySlip SingleOrDefault(Expression<Func<PaySlip, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PaySlip> SingleOrDefaultAsync(Expression<Func<PaySlip, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PaySlip Update(PaySlip entity)
		{
			entity = context.PaySlips.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PaySlip> UpdateAsync(PaySlip entity)
		{
			entity = context.PaySlips.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
