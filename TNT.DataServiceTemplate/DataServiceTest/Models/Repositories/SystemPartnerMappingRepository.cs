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
	public partial interface ISystemPartnerMappingRepository : IBaseRepository<SystemPartnerMapping, int>
	{
	}
	
	public partial class SystemPartnerMappingRepository : BaseRepository<SystemPartnerMapping, int>, ISystemPartnerMappingRepository
	{
		public SystemPartnerMappingRepository() : base()
		{
		}
		
		public SystemPartnerMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override SystemPartnerMapping Add(SystemPartnerMapping entity)
		{
			
			entity = context.SystemPartnerMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> AddAsync(SystemPartnerMapping entity)
		{
			
			entity = context.SystemPartnerMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override SystemPartnerMapping Delete(SystemPartnerMapping entity)
		{
			context.SystemPartnerMappings.Attach(entity);
			entity = context.SystemPartnerMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> DeleteAsync(SystemPartnerMapping entity)
		{
			context.SystemPartnerMappings.Attach(entity);
			entity = context.SystemPartnerMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override SystemPartnerMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.SystemPartnerMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.SystemPartnerMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override SystemPartnerMapping FindById(int key)
		{
			var entity = context.SystemPartnerMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override SystemPartnerMapping FindActiveById(int key)
		{
			var entity = context.SystemPartnerMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> FindByIdAsync(int key)
		{
			var entity = await context.SystemPartnerMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.SystemPartnerMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override SystemPartnerMapping FindByIdInclude<TProperty>(int key, params Expression<Func<SystemPartnerMapping, TProperty>>[] members)
		{
			IQueryable<SystemPartnerMapping> dbSet = context.SystemPartnerMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<SystemPartnerMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<SystemPartnerMapping, TProperty>>[] members)
		{
			IQueryable<SystemPartnerMapping> dbSet = context.SystemPartnerMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override SystemPartnerMapping Activate(SystemPartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SystemPartnerMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SystemPartnerMapping Deactivate(SystemPartnerMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override SystemPartnerMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<SystemPartnerMapping> GetActive()
		{
			return context.SystemPartnerMappings;
		}
		
		public override IQueryable<SystemPartnerMapping> GetActive(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return context.SystemPartnerMappings.Where(expr);
		}
		
		public override SystemPartnerMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override SystemPartnerMapping FirstOrDefault(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<SystemPartnerMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<SystemPartnerMapping> FirstOrDefaultAsync(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override SystemPartnerMapping SingleOrDefault(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<SystemPartnerMapping> SingleOrDefaultAsync(Expression<Func<SystemPartnerMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override SystemPartnerMapping Update(SystemPartnerMapping entity)
		{
			entity = context.SystemPartnerMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<SystemPartnerMapping> UpdateAsync(SystemPartnerMapping entity)
		{
			entity = context.SystemPartnerMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
