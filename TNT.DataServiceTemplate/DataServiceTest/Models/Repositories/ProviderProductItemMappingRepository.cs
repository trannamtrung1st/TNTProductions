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
	public partial interface IProviderProductItemMappingRepository : IBaseRepository<ProviderProductItemMapping, int>
	{
	}
	
	public partial class ProviderProductItemMappingRepository : BaseRepository<ProviderProductItemMapping, int>, IProviderProductItemMappingRepository
	{
		public ProviderProductItemMappingRepository() : base()
		{
		}
		
		public ProviderProductItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ProviderProductItemMapping Add(ProviderProductItemMapping entity)
		{
			entity.Active = true;
			entity = context.ProviderProductItemMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> AddAsync(ProviderProductItemMapping entity)
		{
			entity.Active = true;
			entity = context.ProviderProductItemMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProviderProductItemMapping Delete(ProviderProductItemMapping entity)
		{
			context.ProviderProductItemMappings.Attach(entity);
			entity = context.ProviderProductItemMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> DeleteAsync(ProviderProductItemMapping entity)
		{
			context.ProviderProductItemMappings.Attach(entity);
			entity = context.ProviderProductItemMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProviderProductItemMapping Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProviderProductItemMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.ProviderProductItemMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override ProviderProductItemMapping FindById(int key)
		{
			var entity = context.ProviderProductItemMappings.FirstOrDefault(
				e => e.ProviderProductItemId == key);
			return entity;
		}
		
		public override ProviderProductItemMapping FindActiveById(int key)
		{
			var entity = context.ProviderProductItemMappings.FirstOrDefault(
				e => e.ProviderProductItemId == key && e.Active);
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> FindByIdAsync(int key)
		{
			var entity = await context.ProviderProductItemMappings.FirstOrDefaultAsync(
				e => e.ProviderProductItemId == key);
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.ProviderProductItemMappings.FirstOrDefaultAsync(
				e => e.ProviderProductItemId == key && e.Active);
			return entity;
		}
		
		public override ProviderProductItemMapping FindByIdInclude<TProperty>(int key, params Expression<Func<ProviderProductItemMapping, TProperty>>[] members)
		{
			IQueryable<ProviderProductItemMapping> dbSet = context.ProviderProductItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ProviderProductItemId == key);
		}
		
		public override async Task<ProviderProductItemMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<ProviderProductItemMapping, TProperty>>[] members)
		{
			IQueryable<ProviderProductItemMapping> dbSet = context.ProviderProductItemMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ProviderProductItemId == key);
		}
		
		public override ProviderProductItemMapping Activate(ProviderProductItemMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override ProviderProductItemMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override ProviderProductItemMapping Deactivate(ProviderProductItemMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override ProviderProductItemMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<ProviderProductItemMapping> GetActive()
		{
			return context.ProviderProductItemMappings.Where(e => e.Active);
		}
		
		public override IQueryable<ProviderProductItemMapping> GetActive(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return context.ProviderProductItemMappings.Where(e => e.Active).Where(expr);
		}
		
		public override ProviderProductItemMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override ProviderProductItemMapping FirstOrDefault(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<ProviderProductItemMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<ProviderProductItemMapping> FirstOrDefaultAsync(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override ProviderProductItemMapping SingleOrDefault(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<ProviderProductItemMapping> SingleOrDefaultAsync(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override ProviderProductItemMapping Update(ProviderProductItemMapping entity)
		{
			entity = context.ProviderProductItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<ProviderProductItemMapping> UpdateAsync(ProviderProductItemMapping entity)
		{
			entity = context.ProviderProductItemMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
