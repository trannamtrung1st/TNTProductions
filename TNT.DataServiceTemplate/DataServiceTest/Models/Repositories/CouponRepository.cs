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
	public partial interface ICouponRepository : IBaseRepository<Coupon, int>
	{
	}
	
	public partial class CouponRepository : BaseRepository<Coupon, int>, ICouponRepository
	{
		public CouponRepository() : base()
		{
		}
		
		public CouponRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Coupon Add(Coupon entity)
		{
			
			entity = context.Coupons.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Coupon> AddAsync(Coupon entity)
		{
			
			entity = context.Coupons.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Coupon Delete(Coupon entity)
		{
			context.Coupons.Attach(entity);
			entity = context.Coupons.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Coupon> DeleteAsync(Coupon entity)
		{
			context.Coupons.Attach(entity);
			entity = context.Coupons.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Coupon Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Coupons.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Coupon> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Coupons.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Coupon FindById(int key)
		{
			var entity = context.Coupons.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Coupon FindActiveById(int key)
		{
			var entity = context.Coupons.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Coupon> FindByIdAsync(int key)
		{
			var entity = await context.Coupons.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Coupon> FindActiveByIdAsync(int key)
		{
			var entity = await context.Coupons.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Coupon FindByIdInclude<TProperty>(int key, params Expression<Func<Coupon, TProperty>>[] members)
		{
			IQueryable<Coupon> dbSet = context.Coupons;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Coupon> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Coupon, TProperty>>[] members)
		{
			IQueryable<Coupon> dbSet = context.Coupons;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Coupon Activate(Coupon entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Coupon Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Coupon Deactivate(Coupon entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Coupon Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Coupon> GetActive()
		{
			return context.Coupons;
		}
		
		public override IQueryable<Coupon> GetActive(Expression<Func<Coupon, bool>> expr)
		{
			return context.Coupons.Where(expr);
		}
		
		public override Coupon FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Coupon FirstOrDefault(Expression<Func<Coupon, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Coupon> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Coupon> FirstOrDefaultAsync(Expression<Func<Coupon, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Coupon SingleOrDefault(Expression<Func<Coupon, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Coupon> SingleOrDefaultAsync(Expression<Func<Coupon, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Coupon Update(Coupon entity)
		{
			entity = context.Coupons.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Coupon> UpdateAsync(Coupon entity)
		{
			entity = context.Coupons.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
