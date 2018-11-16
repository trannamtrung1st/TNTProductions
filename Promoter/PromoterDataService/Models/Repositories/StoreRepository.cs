using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Models;
using PromoterDataService.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PromoterDataService.Models.Repositories
{
	public partial interface IStoreRepository : IBaseRepository<Store, int>
	{
	}
	
	public partial class StoreRepository : BaseRepository<Store, int>, IStoreRepository
	{
		public StoreRepository() : base()
		{
		}
		
		public StoreRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Store Add(Store entity)
		{
			
			entity = context.Stores.Add(entity);
			return entity;
		}
		
		public override Store Remove(Store entity)
		{
			context.Stores.Attach(entity);
			entity = context.Stores.Remove(entity);
			return entity;
		}
		
		public override Store Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Stores.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Store> RemoveIf(Expression<Func<Store, bool>> expr)
		{
			return context.Stores.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Store> RemoveRange(IEnumerable<Store> list)
		{
			return context.Stores.RemoveRange(list);
		}
		
		public override Store FindById(int key)
		{
			var entity = context.Stores.FirstOrDefault(
				e => e.IID == key);
			return entity;
		}
		
		public override Store FindActiveById(int key)
		{
			var entity = context.Stores.FirstOrDefault(
				e => e.IID == key);
			return entity;
		}
		
		public override async Task<Store> FindByIdAsync(int key)
		{
			var entity = await context.Stores.FirstOrDefaultAsync(
				e => e.IID == key);
			return entity;
		}
		
		public override async Task<Store> FindActiveByIdAsync(int key)
		{
			var entity = await context.Stores.FirstOrDefaultAsync(
				e => e.IID == key);
			return entity;
		}
		
		public override Store FindByIdInclude<TProperty>(int key, params Expression<Func<Store, TProperty>>[] members)
		{
			IQueryable<Store> dbSet = context.Stores;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.IID == key);
		}
		
		public override async Task<Store> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Store, TProperty>>[] members)
		{
			IQueryable<Store> dbSet = context.Stores;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.IID == key);
		}
		
		public override Store Activate(Store entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Store Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Store Deactivate(Store entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Store Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Store> GetActive()
		{
			return context.Stores;
		}
		
		public override IQueryable<Store> GetActive(Expression<Func<Store, bool>> expr)
		{
			return context.Stores.Where(expr);
		}
		
		public override Store FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Store FirstOrDefault(Expression<Func<Store, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Store> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Store> FirstOrDefaultAsync(Expression<Func<Store, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Store SingleOrDefault(Expression<Func<Store, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Store> SingleOrDefaultAsync(Expression<Func<Store, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Store Update(Store entity)
		{
			entity = context.Stores.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
