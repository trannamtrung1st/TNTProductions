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
	public partial interface IApplicationRepository : IBaseRepository<Application, System.Guid>
	{
	}
	
	public partial class ApplicationRepository : BaseRepository<Application, System.Guid>, IApplicationRepository
	{
		public ApplicationRepository() : base()
		{
		}
		
		public ApplicationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Application Add(Application entity)
		{
			
			entity = context.Applications.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Application> AddAsync(Application entity)
		{
			
			entity = context.Applications.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Application Delete(Application entity)
		{
			context.Applications.Attach(entity);
			entity = context.Applications.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Application> DeleteAsync(Application entity)
		{
			context.Applications.Attach(entity);
			entity = context.Applications.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Application Delete(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Applications.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Application> DeleteAsync(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Applications.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Application FindById(System.Guid key)
		{
			var entity = context.Applications.FirstOrDefault(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override Application FindActiveById(System.Guid key)
		{
			var entity = context.Applications.FirstOrDefault(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override async Task<Application> FindByIdAsync(System.Guid key)
		{
			var entity = await context.Applications.FirstOrDefaultAsync(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override async Task<Application> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await context.Applications.FirstOrDefaultAsync(
				e => e.ApplicationId == key);
			return entity;
		}
		
		public override Application FindByIdInclude<TProperty>(System.Guid key, params Expression<Func<Application, TProperty>>[] members)
		{
			IQueryable<Application> dbSet = context.Applications;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ApplicationId == key);
		}
		
		public override async Task<Application> FindByIdIncludeAsync<TProperty>(System.Guid key, params Expression<Func<Application, TProperty>>[] members)
		{
			IQueryable<Application> dbSet = context.Applications;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ApplicationId == key);
		}
		
		public override Application Activate(Application entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Application Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Application Deactivate(Application entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Application Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Application> GetActive()
		{
			return context.Applications;
		}
		
		public override IQueryable<Application> GetActive(Expression<Func<Application, bool>> expr)
		{
			return context.Applications.Where(expr);
		}
		
		public override Application FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Application FirstOrDefault(Expression<Func<Application, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Application> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Application> FirstOrDefaultAsync(Expression<Func<Application, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Application SingleOrDefault(Expression<Func<Application, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Application> SingleOrDefaultAsync(Expression<Func<Application, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Application Update(Application entity)
		{
			entity = context.Applications.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Application> UpdateAsync(Application entity)
		{
			entity = context.Applications.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
