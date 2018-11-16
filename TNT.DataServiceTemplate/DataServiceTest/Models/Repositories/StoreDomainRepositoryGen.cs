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
	public partial interface IStoreDomainRepository : IBaseRepository<StoreDomain, int>
	{
	}
	
	public partial class StoreDomainRepository : BaseRepository<StoreDomain, int>, IStoreDomainRepository
	{
		public StoreDomainRepository() : base()
		{
		}
		
		public StoreDomainRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreDomain Add(StoreDomain entity)
		{
			entity.Active = true;
			entity = context.StoreDomains.Add(entity);
			return entity;
		}
		
		public override StoreDomain Remove(StoreDomain entity)
		{
			context.StoreDomains.Attach(entity);
			entity = context.StoreDomains.Remove(entity);
			return entity;
		}
		
		public override StoreDomain Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreDomains.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<StoreDomain> RemoveIf(Expression<Func<StoreDomain, bool>> expr)
		{
			return context.StoreDomains.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<StoreDomain> RemoveRange(IEnumerable<StoreDomain> list)
		{
			return context.StoreDomains.RemoveRange(list);
		}
		
		public override StoreDomain FindById(int key)
		{
			var entity = context.StoreDomains.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override StoreDomain FindActiveById(int key)
		{
			var entity = context.StoreDomains.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreDomain> FindByIdAsync(int key)
		{
			var entity = await context.StoreDomains.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<StoreDomain> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreDomains.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override StoreDomain FindByIdInclude<TProperty>(int key, params Expression<Func<StoreDomain, TProperty>>[] members)
		{
			IQueryable<StoreDomain> dbSet = context.StoreDomains;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<StoreDomain> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreDomain, TProperty>>[] members)
		{
			IQueryable<StoreDomain> dbSet = context.StoreDomains;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override StoreDomain Activate(StoreDomain entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreDomain Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreDomain Deactivate(StoreDomain entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreDomain Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreDomain> GetActive()
		{
			return context.StoreDomains.Where(e => e.Active);
		}
		
		public override IQueryable<StoreDomain> GetActive(Expression<Func<StoreDomain, bool>> expr)
		{
			return context.StoreDomains.Where(e => e.Active).Where(expr);
		}
		
		public override StoreDomain FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreDomain FirstOrDefault(Expression<Func<StoreDomain, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreDomain> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreDomain> FirstOrDefaultAsync(Expression<Func<StoreDomain, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreDomain SingleOrDefault(Expression<Func<StoreDomain, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreDomain> SingleOrDefaultAsync(Expression<Func<StoreDomain, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreDomain Update(StoreDomain entity)
		{
			entity = context.StoreDomains.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
