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
	public partial interface IInventoryDateReportRepository : IBaseRepository<InventoryDateReport, int>
	{
	}
	
	public partial class InventoryDateReportRepository : BaseRepository<InventoryDateReport, int>, IInventoryDateReportRepository
	{
		public InventoryDateReportRepository() : base()
		{
		}
		
		public InventoryDateReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryDateReport Add(InventoryDateReport entity)
		{
			
			entity = context.InventoryDateReports.Add(entity);
			return entity;
		}
		
		public override InventoryDateReport Remove(InventoryDateReport entity)
		{
			context.InventoryDateReports.Attach(entity);
			entity = context.InventoryDateReports.Remove(entity);
			return entity;
		}
		
		public override InventoryDateReport Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryDateReports.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<InventoryDateReport> RemoveIf(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return context.InventoryDateReports.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<InventoryDateReport> RemoveRange(IEnumerable<InventoryDateReport> list)
		{
			return context.InventoryDateReports.RemoveRange(list);
		}
		
		public override InventoryDateReport FindById(int key)
		{
			var entity = context.InventoryDateReports.FirstOrDefault(
				e => e.ReportID == key);
			return entity;
		}
		
		public override InventoryDateReport FindActiveById(int key)
		{
			var entity = context.InventoryDateReports.FirstOrDefault(
				e => e.ReportID == key);
			return entity;
		}
		
		public override async Task<InventoryDateReport> FindByIdAsync(int key)
		{
			var entity = await context.InventoryDateReports.FirstOrDefaultAsync(
				e => e.ReportID == key);
			return entity;
		}
		
		public override async Task<InventoryDateReport> FindActiveByIdAsync(int key)
		{
			var entity = await context.InventoryDateReports.FirstOrDefaultAsync(
				e => e.ReportID == key);
			return entity;
		}
		
		public override InventoryDateReport FindByIdInclude<TProperty>(int key, params Expression<Func<InventoryDateReport, TProperty>>[] members)
		{
			IQueryable<InventoryDateReport> dbSet = context.InventoryDateReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ReportID == key);
		}
		
		public override async Task<InventoryDateReport> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<InventoryDateReport, TProperty>>[] members)
		{
			IQueryable<InventoryDateReport> dbSet = context.InventoryDateReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ReportID == key);
		}
		
		public override InventoryDateReport Activate(InventoryDateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReport Deactivate(InventoryDateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryDateReport> GetActive()
		{
			return context.InventoryDateReports;
		}
		
		public override IQueryable<InventoryDateReport> GetActive(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return context.InventoryDateReports.Where(expr);
		}
		
		public override InventoryDateReport FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryDateReport FirstOrDefault(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryDateReport> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryDateReport> FirstOrDefaultAsync(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryDateReport SingleOrDefault(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryDateReport> SingleOrDefaultAsync(Expression<Func<InventoryDateReport, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryDateReport Update(InventoryDateReport entity)
		{
			entity = context.InventoryDateReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
