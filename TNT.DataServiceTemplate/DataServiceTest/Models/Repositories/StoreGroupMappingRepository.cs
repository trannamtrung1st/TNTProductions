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
	public partial interface IStoreGroupMappingRepository : IBaseRepository<StoreGroupMapping, int>
	{
	}
	
	public partial class StoreGroupMappingRepository : BaseRepository<StoreGroupMapping, int>, IStoreGroupMappingRepository
	{
		public StoreGroupMappingRepository() : base()
		{
		}
		
		public StoreGroupMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreGroupMapping Add(StoreGroupMapping entity)
		{
			
			entity = context.StoreGroupMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreGroupMapping> AddAsync(StoreGroupMapping entity)
		{
			
			entity = context.StoreGroupMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreGroupMapping Delete(StoreGroupMapping entity)
		{
			context.StoreGroupMappings.Attach(entity);
			entity = context.StoreGroupMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreGroupMapping> DeleteAsync(StoreGroupMapping entity)
		{
			context.StoreGroupMappings.Attach(entity);
			entity = context.StoreGroupMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreGroupMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreGroupMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreGroupMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreGroupMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreGroupMapping FindById(int key)
		{
			var entity = context.StoreGroupMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override StoreGroupMapping FindActiveById(int key)
		{
			var entity = context.StoreGroupMappings.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<StoreGroupMapping> FindByIdAsync(int key)
		{
			var entity = await context.StoreGroupMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<StoreGroupMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreGroupMappings.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override StoreGroupMapping FindByIdInclude<TProperty>(int key, params Expression<Func<StoreGroupMapping, TProperty>>[] members)
		{
			IQueryable<StoreGroupMapping> dbSet = context.StoreGroupMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<StoreGroupMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreGroupMapping, TProperty>>[] members)
		{
			IQueryable<StoreGroupMapping> dbSet = context.StoreGroupMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override StoreGroupMapping Activate(StoreGroupMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreGroupMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreGroupMapping Deactivate(StoreGroupMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreGroupMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<StoreGroupMapping> GetActive()
		{
			return context.StoreGroupMappings;
		}
		
		public override IQueryable<StoreGroupMapping> GetActive(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return context.StoreGroupMappings.Where(expr);
		}
		
		public override StoreGroupMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreGroupMapping FirstOrDefault(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreGroupMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreGroupMapping> FirstOrDefaultAsync(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreGroupMapping SingleOrDefault(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreGroupMapping> SingleOrDefaultAsync(Expression<Func<StoreGroupMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreGroupMapping Update(StoreGroupMapping entity)
		{
			entity = context.StoreGroupMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreGroupMapping> UpdateAsync(StoreGroupMapping entity)
		{
			entity = context.StoreGroupMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
