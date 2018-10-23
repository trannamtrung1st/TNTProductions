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
	public partial interface IInventoryTemplateReportRepository : IBaseRepository<InventoryTemplateReport, int>
	{
	}
	
	public partial class InventoryTemplateReportRepository : BaseRepository<InventoryTemplateReport, int>, IInventoryTemplateReportRepository
	{
		public InventoryTemplateReportRepository() : base()
		{
		}
		
		public InventoryTemplateReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryTemplateReport Add(InventoryTemplateReport entity)
		{
			entity.Active = true;
			entity = context.InventoryTemplateReports.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> AddAsync(InventoryTemplateReport entity)
		{
			entity.Active = true;
			entity = context.InventoryTemplateReports.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryTemplateReport Delete(InventoryTemplateReport entity)
		{
			context.InventoryTemplateReports.Attach(entity);
			entity = context.InventoryTemplateReports.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> DeleteAsync(InventoryTemplateReport entity)
		{
			context.InventoryTemplateReports.Attach(entity);
			entity = context.InventoryTemplateReports.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryTemplateReport Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryTemplateReports.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryTemplateReports.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryTemplateReport FindById(int key)
		{
			var entity = context.InventoryTemplateReports.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override InventoryTemplateReport FindActiveById(int key)
		{
			var entity = context.InventoryTemplateReports.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> FindByIdAsync(int key)
		{
			var entity = await context.InventoryTemplateReports.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> FindActiveByIdAsync(int key)
		{
			var entity = await context.InventoryTemplateReports.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override InventoryTemplateReport FindByIdInclude<TProperty>(int key, params Expression<Func<InventoryTemplateReport, TProperty>>[] members)
		{
			IQueryable<InventoryTemplateReport> dbSet = context.InventoryTemplateReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<InventoryTemplateReport> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<InventoryTemplateReport, TProperty>>[] members)
		{
			IQueryable<InventoryTemplateReport> dbSet = context.InventoryTemplateReports;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override InventoryTemplateReport Activate(InventoryTemplateReport entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override InventoryTemplateReport Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override InventoryTemplateReport Deactivate(InventoryTemplateReport entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override InventoryTemplateReport Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<InventoryTemplateReport> GetActive()
		{
			return context.InventoryTemplateReports.Where(e => e.Active);
		}
		
		public override IQueryable<InventoryTemplateReport> GetActive(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return context.InventoryTemplateReports.Where(e => e.Active).Where(expr);
		}
		
		public override InventoryTemplateReport FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryTemplateReport FirstOrDefault(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryTemplateReport> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryTemplateReport> FirstOrDefaultAsync(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryTemplateReport SingleOrDefault(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryTemplateReport> SingleOrDefaultAsync(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryTemplateReport Update(InventoryTemplateReport entity)
		{
			entity = context.InventoryTemplateReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> UpdateAsync(InventoryTemplateReport entity)
		{
			entity = context.InventoryTemplateReports.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
