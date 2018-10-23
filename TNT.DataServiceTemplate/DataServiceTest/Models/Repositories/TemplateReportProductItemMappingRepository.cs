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
	public partial interface ITemplateReportProductItemMappingRepository : IBaseRepository<TemplateReportProductItemMapping, int>
	{
	}
	
	public partial class TemplateReportProductItemMappingRepository : BaseRepository<TemplateReportProductItemMapping, int>, ITemplateReportProductItemMappingRepository
	{
		public TemplateReportProductItemMappingRepository() : base()
		{
		}
		
		public TemplateReportProductItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TemplateReportProductItemMapping Add(TemplateReportProductItemMapping entity)
		{
			
			entity = context.TemplateReportProductItemMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> AddAsync(TemplateReportProductItemMapping entity)
		{
			
			entity = context.TemplateReportProductItemMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TemplateReportProductItemMapping Delete(TemplateReportProductItemMapping entity)
		{
			context.TemplateReportProductItemMappings.Attach(entity);
			entity = context.TemplateReportProductItemMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> DeleteAsync(TemplateReportProductItemMapping entity)
		{
			context.TemplateReportProductItemMappings.Attach(entity);
			entity = context.TemplateReportProductItemMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TemplateReportProductItemMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TemplateReportProductItemMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TemplateReportProductItemMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TemplateReportProductItemMapping FindById(int key)
		{
			var entity = context.TemplateReportProductItemMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateReportProductItemMapping FindActiveById(int key)
		{
			var entity = context.TemplateReportProductItemMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> FindByIdAsync(int key)
		{
			var entity = await context.TemplateReportProductItemMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.TemplateReportProductItemMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateReportProductItemMapping FindByIdInclude<TProperty>(int key, params Expression<Func<TemplateReportProductItemMapping, TProperty>>[] members)
		{
			IQueryable<TemplateReportProductItemMapping> dbSet = context.TemplateReportProductItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TemplateReportProductItemMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TemplateReportProductItemMapping, TProperty>>[] members)
		{
			IQueryable<TemplateReportProductItemMapping> dbSet = context.TemplateReportProductItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TemplateReportProductItemMapping Activate(TemplateReportProductItemMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TemplateReportProductItemMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TemplateReportProductItemMapping Deactivate(TemplateReportProductItemMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TemplateReportProductItemMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<TemplateReportProductItemMapping> GetActive()
		{
			return context.TemplateReportProductItemMappings;
		}
		
		public override IQueryable<TemplateReportProductItemMapping> GetActive(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return context.TemplateReportProductItemMappings.Where(expr);
		}
		
		public override TemplateReportProductItemMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TemplateReportProductItemMapping FirstOrDefault(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TemplateReportProductItemMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TemplateReportProductItemMapping> FirstOrDefaultAsync(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TemplateReportProductItemMapping SingleOrDefault(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TemplateReportProductItemMapping> SingleOrDefaultAsync(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TemplateReportProductItemMapping Update(TemplateReportProductItemMapping entity)
		{
			entity = context.TemplateReportProductItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> UpdateAsync(TemplateReportProductItemMapping entity)
		{
			entity = context.TemplateReportProductItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
