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
	public partial interface IDateHotelReportRepository : IBaseRepository<DateHotelReport, int>
	{
	}
	
	public partial class DateHotelReportRepository : BaseRepository<DateHotelReport, int>, IDateHotelReportRepository
	{
		public DateHotelReportRepository() : base()
		{
		}
		
		public DateHotelReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DateHotelReport Add(DateHotelReport entity)
		{
			
			entity = context.DateHotelReports.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateHotelReport> AddAsync(DateHotelReport entity)
		{
			
			entity = context.DateHotelReports.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateHotelReport Delete(DateHotelReport entity)
		{
			context.DateHotelReports.Attach(entity);
			entity = context.DateHotelReports.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateHotelReport> DeleteAsync(DateHotelReport entity)
		{
			context.DateHotelReports.Attach(entity);
			entity = context.DateHotelReports.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateHotelReport Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateHotelReports.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateHotelReport> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DateHotelReports.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override DateHotelReport FindById(int key)
		{
			var entity = context.DateHotelReports.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override DateHotelReport FindActiveById(int key)
		{
			var entity = context.DateHotelReports.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DateHotelReport> FindByIdAsync(int key)
		{
			var entity = await context.DateHotelReports.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DateHotelReport> FindActiveByIdAsync(int key)
		{
			var entity = await context.DateHotelReports.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override DateHotelReport FindByIdInclude<TProperty>(int key, params Expression<Func<DateHotelReport, TProperty>>[] members)
		{
			IQueryable<DateHotelReport> dbSet = context.DateHotelReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<DateHotelReport> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DateHotelReport, TProperty>>[] members)
		{
			IQueryable<DateHotelReport> dbSet = context.DateHotelReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override DateHotelReport Activate(DateHotelReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateHotelReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateHotelReport Deactivate(DateHotelReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateHotelReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DateHotelReport> GetActive()
		{
			return context.DateHotelReports;
		}
		
		public override IQueryable<DateHotelReport> GetActive(Expression<Func<DateHotelReport, bool>> expr)
		{
			return context.DateHotelReports.Where(expr);
		}
		
		public override DateHotelReport FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DateHotelReport FirstOrDefault(Expression<Func<DateHotelReport, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DateHotelReport> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DateHotelReport> FirstOrDefaultAsync(Expression<Func<DateHotelReport, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DateHotelReport SingleOrDefault(Expression<Func<DateHotelReport, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DateHotelReport> SingleOrDefaultAsync(Expression<Func<DateHotelReport, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DateHotelReport Update(DateHotelReport entity)
		{
			entity = context.DateHotelReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<DateHotelReport> UpdateAsync(DateHotelReport entity)
		{
			entity = context.DateHotelReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
