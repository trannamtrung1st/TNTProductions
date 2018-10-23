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
	public partial interface ICouponProviderRepository : IBaseRepository<CouponProvider, int>
	{
	}
	
	public partial class CouponProviderRepository : BaseRepository<CouponProvider, int>, ICouponProviderRepository
	{
		public CouponProviderRepository() : base()
		{
		}
		
		public CouponProviderRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CouponProvider Add(CouponProvider entity)
		{
			
			entity = context.CouponProviders.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponProvider> AddAsync(CouponProvider entity)
		{
			
			entity = context.CouponProviders.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CouponProvider Delete(CouponProvider entity)
		{
			context.CouponProviders.Attach(entity);
			entity = context.CouponProviders.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponProvider> DeleteAsync(CouponProvider entity)
		{
			context.CouponProviders.Attach(entity);
			entity = context.CouponProviders.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CouponProvider Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CouponProviders.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponProvider> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CouponProviders.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CouponProvider FindById(int key)
		{
			var entity = context.CouponProviders.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponProvider FindActiveById(int key)
		{
			var entity = context.CouponProviders.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponProvider> FindByIdAsync(int key)
		{
			var entity = await context.CouponProviders.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<CouponProvider> FindActiveByIdAsync(int key)
		{
			var entity = await context.CouponProviders.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override CouponProvider FindByIdInclude<TProperty>(int key, params Expression<Func<CouponProvider, TProperty>>[] members)
		{
			IQueryable<CouponProvider> dbSet = context.CouponProviders;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<CouponProvider> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<CouponProvider, TProperty>>[] members)
		{
			IQueryable<CouponProvider> dbSet = context.CouponProviders;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override CouponProvider Activate(CouponProvider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponProvider Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponProvider Deactivate(CouponProvider entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CouponProvider Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CouponProvider> GetActive()
		{
			return context.CouponProviders;
		}
		
		public override IQueryable<CouponProvider> GetActive(Expression<Func<CouponProvider, bool>> expr)
		{
			return context.CouponProviders.Where(expr);
		}
		
		public override CouponProvider FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CouponProvider FirstOrDefault(Expression<Func<CouponProvider, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CouponProvider> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CouponProvider> FirstOrDefaultAsync(Expression<Func<CouponProvider, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CouponProvider SingleOrDefault(Expression<Func<CouponProvider, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CouponProvider> SingleOrDefaultAsync(Expression<Func<CouponProvider, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CouponProvider Update(CouponProvider entity)
		{
			entity = context.CouponProviders.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CouponProvider> UpdateAsync(CouponProvider entity)
		{
			entity = context.CouponProviders.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
