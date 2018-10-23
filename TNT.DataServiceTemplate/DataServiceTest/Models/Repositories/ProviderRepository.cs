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
	public partial interface IProviderRepository : IBaseRepository<Provider, int>
	{
	}
	
	public partial class ProviderRepository : BaseRepository<Provider, int>, IProviderRepository
	{
		public ProviderRepository() : base()
		{
		}
		
		public ProviderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Provider Add(Provider entity)
		{
			
			entity = context.Providers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Provider> AddAsync(Provider entity)
		{
			
			entity = context.Providers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Provider Delete(Provider entity)
		{
			context.Providers.Attach(entity);
			entity = context.Providers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Provider> DeleteAsync(Provider entity)
		{
			context.Providers.Attach(entity);
			entity = context.Providers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Provider Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Providers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Provider> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Providers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Provider FindById(int key)
		{
			var entity = context.Providers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Provider FindActiveById(int key)
		{
			var entity = context.Providers.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Provider> FindByIdAsync(int key)
		{
			var entity = await context.Providers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Provider> FindActiveByIdAsync(int key)
		{
			var entity = await context.Providers.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Provider FindByIdInclude<TProperty>(int key, params Expression<Func<Provider, TProperty>>[] members)
		{
			IQueryable<Provider> dbSet = context.Providers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Provider> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Provider, TProperty>>[] members)
		{
			IQueryable<Provider> dbSet = context.Providers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Provider Activate(Provider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Provider Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Provider Deactivate(Provider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Provider Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Provider> GetActive()
		{
			return context.Providers;
		}
		
		public override IQueryable<Provider> GetActive(Expression<Func<Provider, bool>> expr)
		{
			return context.Providers.Where(expr);
		}
		
		public override Provider FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Provider FirstOrDefault(Expression<Func<Provider, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Provider> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Provider> FirstOrDefaultAsync(Expression<Func<Provider, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Provider SingleOrDefault(Expression<Func<Provider, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Provider> SingleOrDefaultAsync(Expression<Func<Provider, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Provider Update(Provider entity)
		{
			entity = context.Providers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Provider> UpdateAsync(Provider entity)
		{
			entity = context.Providers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
