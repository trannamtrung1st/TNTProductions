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
	public partial interface IPayrollPeriodRepository : IBaseRepository<PayrollPeriod, int>
	{
	}
	
	public partial class PayrollPeriodRepository : BaseRepository<PayrollPeriod, int>, IPayrollPeriodRepository
	{
		public PayrollPeriodRepository() : base()
		{
		}
		
		public PayrollPeriodRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PayrollPeriod Add(PayrollPeriod entity)
		{
			
			entity = context.PayrollPeriods.Add(entity);
			return entity;
		}
		
		public override PayrollPeriod Remove(PayrollPeriod entity)
		{
			context.PayrollPeriods.Attach(entity);
			entity = context.PayrollPeriods.Remove(entity);
			return entity;
		}
		
		public override PayrollPeriod Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PayrollPeriods.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PayrollPeriod> RemoveIf(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return context.PayrollPeriods.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PayrollPeriod> RemoveRange(IEnumerable<PayrollPeriod> list)
		{
			return context.PayrollPeriods.RemoveRange(list);
		}
		
		public override PayrollPeriod FindById(int key)
		{
			var entity = context.PayrollPeriods.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollPeriod FindActiveById(int key)
		{
			var entity = context.PayrollPeriods.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollPeriod> FindByIdAsync(int key)
		{
			var entity = await context.PayrollPeriods.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PayrollPeriod> FindActiveByIdAsync(int key)
		{
			var entity = await context.PayrollPeriods.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PayrollPeriod FindByIdInclude<TProperty>(int key, params Expression<Func<PayrollPeriod, TProperty>>[] members)
		{
			IQueryable<PayrollPeriod> dbSet = context.PayrollPeriods;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PayrollPeriod> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PayrollPeriod, TProperty>>[] members)
		{
			IQueryable<PayrollPeriod> dbSet = context.PayrollPeriods;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PayrollPeriod Activate(PayrollPeriod entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PayrollPeriod Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PayrollPeriod Deactivate(PayrollPeriod entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PayrollPeriod Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PayrollPeriod> GetActive()
		{
			return context.PayrollPeriods;
		}
		
		public override IQueryable<PayrollPeriod> GetActive(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return context.PayrollPeriods.Where(expr);
		}
		
		public override PayrollPeriod FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PayrollPeriod FirstOrDefault(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PayrollPeriod> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PayrollPeriod> FirstOrDefaultAsync(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PayrollPeriod SingleOrDefault(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PayrollPeriod> SingleOrDefaultAsync(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PayrollPeriod Update(PayrollPeriod entity)
		{
			entity = context.PayrollPeriods.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
