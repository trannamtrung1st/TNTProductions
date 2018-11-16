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
	public partial interface IPromotionStoreMappingRepository : IBaseRepository<PromotionStoreMapping, int>
	{
	}
	
	public partial class PromotionStoreMappingRepository : BaseRepository<PromotionStoreMapping, int>, IPromotionStoreMappingRepository
	{
		public PromotionStoreMappingRepository() : base()
		{
		}
		
		public PromotionStoreMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionStoreMapping Add(PromotionStoreMapping entity)
		{
			entity.Active = true;
			entity = context.PromotionStoreMappings.Add(entity);
			return entity;
		}
		
		public override PromotionStoreMapping Remove(PromotionStoreMapping entity)
		{
			context.PromotionStoreMappings.Attach(entity);
			entity = context.PromotionStoreMappings.Remove(entity);
			return entity;
		}
		
		public override PromotionStoreMapping Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionStoreMappings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PromotionStoreMapping> RemoveIf(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return context.PromotionStoreMappings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PromotionStoreMapping> RemoveRange(IEnumerable<PromotionStoreMapping> list)
		{
			return context.PromotionStoreMappings.RemoveRange(list);
		}
		
		public override PromotionStoreMapping FindById(int key)
		{
			var entity = context.PromotionStoreMappings.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PromotionStoreMapping FindActiveById(int key)
		{
			var entity = context.PromotionStoreMappings.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<PromotionStoreMapping> FindByIdAsync(int key)
		{
			var entity = await context.PromotionStoreMappings.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PromotionStoreMapping> FindActiveByIdAsync(int key)
		{
			var entity = await context.PromotionStoreMappings.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override PromotionStoreMapping FindByIdInclude<TProperty>(int key, params Expression<Func<PromotionStoreMapping, TProperty>>[] members)
		{
			IQueryable<PromotionStoreMapping> dbSet = context.PromotionStoreMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<PromotionStoreMapping> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PromotionStoreMapping, TProperty>>[] members)
		{
			IQueryable<PromotionStoreMapping> dbSet = context.PromotionStoreMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override PromotionStoreMapping Activate(PromotionStoreMapping entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override PromotionStoreMapping Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override PromotionStoreMapping Deactivate(PromotionStoreMapping entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override PromotionStoreMapping Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<PromotionStoreMapping> GetActive()
		{
			return context.PromotionStoreMappings.Where(e => e.Active);
		}
		
		public override IQueryable<PromotionStoreMapping> GetActive(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return context.PromotionStoreMappings.Where(e => e.Active).Where(expr);
		}
		
		public override PromotionStoreMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PromotionStoreMapping FirstOrDefault(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PromotionStoreMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PromotionStoreMapping> FirstOrDefaultAsync(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PromotionStoreMapping SingleOrDefault(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PromotionStoreMapping> SingleOrDefaultAsync(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PromotionStoreMapping Update(PromotionStoreMapping entity)
		{
			entity = context.PromotionStoreMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
