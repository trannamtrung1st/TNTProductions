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
	public partial interface IDateReportRepository : IBaseRepository<DateReport, int>
	{
	}
	
	public partial class DateReportRepository : BaseRepository<DateReport, int>, IDateReportRepository
	{
		public DateReportRepository() : base()
		{
		}
		
		public DateReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DateReport Add(DateReport entity)
		{
			
			entity = context.DateReports.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateReport> AddAsync(DateReport entity)
		{
			
			entity = context.DateReports.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateReport Delete(DateReport entity)
		{
			context.DateReports.Attach(entity);
			entity = context.DateReports.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateReport> DeleteAsync(DateReport entity)
		{
			context.DateReports.Attach(entity);
			entity = context.DateReports.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateReport Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateReports.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateReport> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateReports.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateReport FindById(int key)
		{
			var entity = context.DateReports.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override DateReport FindActiveById(int key)
		{
			var entity = context.DateReports.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateReport> FindByIdAsync(int key)
		{
			var entity = await context.DateReports.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateReport> FindActiveByIdAsync(int key)
		{
			var entity = await context.DateReports.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override DateReport FindByIdInclude<TProperty>(int key, params Expression<Func<DateReport, TProperty>>[] members)
		{
			IQueryable<DateReport> dbSet = context.DateReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<DateReport> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DateReport, TProperty>>[] members)
		{
			IQueryable<DateReport> dbSet = context.DateReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override DateReport Activate(DateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateReport Deactivate(DateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DateReport> GetActive()
		{
			return context.DateReports;
		}
		
		public override IQueryable<DateReport> GetActive(Expression<Func<DateReport, bool>> expr)
		{
			return context.DateReports.Where(expr);
		}
		
		public override DateReport FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DateReport FirstOrDefault(Expression<Func<DateReport, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DateReport> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DateReport> FirstOrDefaultAsync(Expression<Func<DateReport, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DateReport SingleOrDefault(Expression<Func<DateReport, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DateReport> SingleOrDefaultAsync(Expression<Func<DateReport, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DateReport Update(DateReport entity)
		{
			entity = context.DateReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateReport> UpdateAsync(DateReport entity)
		{
			entity = context.DateReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
