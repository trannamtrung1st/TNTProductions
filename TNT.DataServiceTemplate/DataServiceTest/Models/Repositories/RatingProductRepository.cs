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
	public partial interface IRatingProductRepository : IBaseRepository<RatingProduct, int>
	{
	}
	
	public partial class RatingProductRepository : BaseRepository<RatingProduct, int>, IRatingProductRepository
	{
		public RatingProductRepository() : base()
		{
		}
		
		public RatingProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RatingProduct Add(RatingProduct entity)
		{
			entity.Active = true;
			entity = context.RatingProducts.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RatingProduct> AddAsync(RatingProduct entity)
		{
			entity.Active = true;
			entity = context.RatingProducts.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override RatingProduct Delete(RatingProduct entity)
		{
			context.RatingProducts.Attach(entity);
			entity = context.RatingProducts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RatingProduct> DeleteAsync(RatingProduct entity)
		{
			context.RatingProducts.Attach(entity);
			entity = context.RatingProducts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override RatingProduct Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RatingProducts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RatingProduct> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RatingProducts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override RatingProduct FindById(int key)
		{
			var entity = context.RatingProducts.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override RatingProduct FindActiveById(int key)
		{
			var entity = context.RatingProducts.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<RatingProduct> FindByIdAsync(int key)
		{
			var entity = await context.RatingProducts.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<RatingProduct> FindActiveByIdAsync(int key)
		{
			var entity = await context.RatingProducts.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override RatingProduct FindByIdInclude<TProperty>(int key, params Expression<Func<RatingProduct, TProperty>>[] members)
		{
			IQueryable<RatingProduct> dbSet = context.RatingProducts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<RatingProduct> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<RatingProduct, TProperty>>[] members)
		{
			IQueryable<RatingProduct> dbSet = context.RatingProducts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override RatingProduct Activate(RatingProduct entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override RatingProduct Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override RatingProduct Deactivate(RatingProduct entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override RatingProduct Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<RatingProduct> GetActive()
		{
			return context.RatingProducts.Where(e => e.Active);
		}
		
		public override IQueryable<RatingProduct> GetActive(Expression<Func<RatingProduct, bool>> expr)
		{
			return context.RatingProducts.Where(e => e.Active).Where(expr);
		}
		
		public override RatingProduct FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override RatingProduct FirstOrDefault(Expression<Func<RatingProduct, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<RatingProduct> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<RatingProduct> FirstOrDefaultAsync(Expression<Func<RatingProduct, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override RatingProduct SingleOrDefault(Expression<Func<RatingProduct, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<RatingProduct> SingleOrDefaultAsync(Expression<Func<RatingProduct, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override RatingProduct Update(RatingProduct entity)
		{
			entity = context.RatingProducts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RatingProduct> UpdateAsync(RatingProduct entity)
		{
			entity = context.RatingProducts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
