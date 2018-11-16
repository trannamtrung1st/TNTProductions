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
	public partial interface IPaymentReportRepository : IBaseRepository<PaymentReport, int>
	{
	}
	
	public partial class PaymentReportRepository : BaseRepository<PaymentReport, int>, IPaymentReportRepository
	{
		public PaymentReportRepository() : base()
		{
		}
		
		public PaymentReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PaymentReport Add(PaymentReport entity)
		{
			
			entity = context.PaymentReports.Add(entity);
			return entity;
		}
		
		public override PaymentReport Remove(PaymentReport entity)
		{
			context.PaymentReports.Attach(entity);
			entity = context.PaymentReports.Remove(entity);
			return entity;
		}
		
		public override PaymentReport Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PaymentReports.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PaymentReport> RemoveIf(Expression<Func<PaymentReport, bool>> expr)
		{
			return context.PaymentReports.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PaymentReport> RemoveRange(IEnumerable<PaymentReport> list)
		{
			return context.PaymentReports.RemoveRange(list);
		}
		
		public override PaymentReport FindById(int key)
		{
			var entity = context.PaymentReports.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override PaymentReport FindActiveById(int key)
		{
			var entity = context.PaymentReports.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<PaymentReport> FindByIdAsync(int key)
		{
			var entity = await context.PaymentReports.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<PaymentReport> FindActiveByIdAsync(int key)
		{
			var entity = await context.PaymentReports.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override PaymentReport FindByIdInclude<TProperty>(int key, params Expression<Func<PaymentReport, TProperty>>[] members)
		{
			IQueryable<PaymentReport> dbSet = context.PaymentReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<PaymentReport> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PaymentReport, TProperty>>[] members)
		{
			IQueryable<PaymentReport> dbSet = context.PaymentReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override PaymentReport Activate(PaymentReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PaymentReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PaymentReport Deactivate(PaymentReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PaymentReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PaymentReport> GetActive()
		{
			return context.PaymentReports;
		}
		
		public override IQueryable<PaymentReport> GetActive(Expression<Func<PaymentReport, bool>> expr)
		{
			return context.PaymentReports.Where(expr);
		}
		
		public override PaymentReport FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PaymentReport FirstOrDefault(Expression<Func<PaymentReport, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PaymentReport> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PaymentReport> FirstOrDefaultAsync(Expression<Func<PaymentReport, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PaymentReport SingleOrDefault(Expression<Func<PaymentReport, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PaymentReport> SingleOrDefaultAsync(Expression<Func<PaymentReport, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PaymentReport Update(PaymentReport entity)
		{
			entity = context.PaymentReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
