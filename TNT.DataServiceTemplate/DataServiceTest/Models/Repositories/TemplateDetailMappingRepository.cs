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
	public partial interface ITemplateDetailMappingRepository : IBaseRepository<TemplateDetailMapping, int>
	{
	}
	
	public partial class TemplateDetailMappingRepository : BaseRepository<TemplateDetailMapping, int>, ITemplateDetailMappingRepository
	{
		public TemplateDetailMappingRepository() : base()
		{
		}
		
		public TemplateDetailMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TemplateDetailMapping Add(TemplateDetailMapping entity)
		{
			entity.Active = true;
			entity = context.TemplateDetailMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> AddAsync(TemplateDetailMapping entity)
		{
			entity.Active = true;
			entity = context.TemplateDetailMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TemplateDetailMapping Delete(TemplateDetailMapping entity)
		{
			context.TemplateDetailMappings.Attach(entity);
			entity = context.TemplateDetailMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> DeleteAsync(TemplateDetailMapping entity)
		{
			context.TemplateDetailMappings.Attach(entity);
			entity = context.TemplateDetailMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TemplateDetailMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TemplateDetailMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TemplateDetailMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TemplateDetailMapping FindById(int key)
		{
			var entity = context.TemplateDetailMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateDetailMapping FindActiveById(int key)
		{
			var entity = context.TemplateDetailMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> FindByIdAsync(int key)
		{
			var entity = await context.TemplateDetailMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.TemplateDetailMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TemplateDetailMapping FindByIdInclude<TProperty>(int key, params Expression<Func<TemplateDetailMapping, TProperty>>[] members)
		{
			IQueryable<TemplateDetailMapping> dbSet = context.TemplateDetailMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TemplateDetailMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TemplateDetailMapping, TProperty>>[] members)
		{
			IQueryable<TemplateDetailMapping> dbSet = context.TemplateDetailMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TemplateDetailMapping Activate(TemplateDetailMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TemplateDetailMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TemplateDetailMapping Deactivate(TemplateDetailMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TemplateDetailMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TemplateDetailMapping> GetActive()
		{
			return context.TemplateDetailMappings.Where(e => e.Active);
		}
		
		public override IQueryable<TemplateDetailMapping> GetActive(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return context.TemplateDetailMappings.Where(e => e.Active).Where(expr);
		}
		
		public override TemplateDetailMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TemplateDetailMapping FirstOrDefault(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TemplateDetailMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TemplateDetailMapping> FirstOrDefaultAsync(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TemplateDetailMapping SingleOrDefault(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TemplateDetailMapping> SingleOrDefaultAsync(Expression<Func<TemplateDetailMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TemplateDetailMapping Update(TemplateDetailMapping entity)
		{
			entity = context.TemplateDetailMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TemplateDetailMapping> UpdateAsync(TemplateDetailMapping entity)
		{
			entity = context.TemplateDetailMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
