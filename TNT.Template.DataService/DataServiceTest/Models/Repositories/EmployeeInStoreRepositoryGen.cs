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
	public partial interface IEmployeeInStoreRepository : IBaseRepository<EmployeeInStore, int>
	{
	}
	
	public partial class EmployeeInStoreRepository : BaseRepository<EmployeeInStore, int>, IEmployeeInStoreRepository
	{
		public EmployeeInStoreRepository() : base()
		{
		}
		
		public EmployeeInStoreRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override EmployeeInStore Add(EmployeeInStore entity)
		{
			entity.Active = true;
			entity = context.EmployeeInStores.Add(entity);
			return entity;
		}
		
		public override EmployeeInStore Remove(EmployeeInStore entity)
		{
			context.EmployeeInStores.Attach(entity);
			entity = context.EmployeeInStores.Remove(entity);
			return entity;
		}
		
		public override EmployeeInStore Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.EmployeeInStores.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<EmployeeInStore> RemoveIf(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return context.EmployeeInStores.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<EmployeeInStore> RemoveRange(IEnumerable<EmployeeInStore> list)
		{
			return context.EmployeeInStores.RemoveRange(list);
		}
		
		public override EmployeeInStore FindById(int key)
		{
			var entity = context.EmployeeInStores.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override EmployeeInStore FindActiveById(int key)
		{
			var entity = context.EmployeeInStores.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<EmployeeInStore> FindByIdAsync(int key)
		{
			var entity = await context.EmployeeInStores.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<EmployeeInStore> FindActiveByIdAsync(int key)
		{
			var entity = await context.EmployeeInStores.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override EmployeeInStore FindByIdInclude<TProperty>(int key, params Expression<Func<EmployeeInStore, TProperty>>[] members)
		{
			IQueryable<EmployeeInStore> dbSet = context.EmployeeInStores;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<EmployeeInStore> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<EmployeeInStore, TProperty>>[] members)
		{
			IQueryable<EmployeeInStore> dbSet = context.EmployeeInStores;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override EmployeeInStore Activate(EmployeeInStore entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override EmployeeInStore Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override EmployeeInStore Deactivate(EmployeeInStore entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override EmployeeInStore Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<EmployeeInStore> GetActive()
		{
			return context.EmployeeInStores.Where(e => e.Active);
		}
		
		public override IQueryable<EmployeeInStore> GetActive(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return context.EmployeeInStores.Where(e => e.Active).Where(expr);
		}
		
		public override EmployeeInStore FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override EmployeeInStore FirstOrDefault(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<EmployeeInStore> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<EmployeeInStore> FirstOrDefaultAsync(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override EmployeeInStore SingleOrDefault(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<EmployeeInStore> SingleOrDefaultAsync(Expression<Func<EmployeeInStore, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override EmployeeInStore Update(EmployeeInStore entity)
		{
			entity = context.EmployeeInStores.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
