﻿using System;
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
	public partial interface IPromotionRepository : IBaseRepository<Promotion, int>
	{
	}
	
	public partial class PromotionRepository : BaseRepository<Promotion, int>, IPromotionRepository
	{
		public PromotionRepository() : base()
		{
		}
		
		public PromotionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Promotion Add(Promotion entity)
		{
			
			entity = context.Promotions.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Promotion> AddAsync(Promotion entity)
		{
			
			entity = context.Promotions.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Promotion Delete(Promotion entity)
		{
			context.Promotions.Attach(entity);
			entity = context.Promotions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Promotion> DeleteAsync(Promotion entity)
		{
			context.Promotions.Attach(entity);
			entity = context.Promotions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Promotion Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Promotions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Promotion> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Promotions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Promotion FindById(int key)
		{
			var entity = context.Promotions.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Promotion FindActiveById(int key)
		{
			var entity = context.Promotions.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Promotion> FindByIdAsync(int key)
		{
			var entity = await context.Promotions.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Promotion> FindActiveByIdAsync(int key)
		{
			var entity = await context.Promotions.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Promotion FindByIdInclude<TProperty>(int key, params Expression<Func<Promotion, TProperty>>[] members)
		{
			IQueryable<Promotion> dbSet = context.Promotions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Promotion> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Promotion, TProperty>>[] members)
		{
			IQueryable<Promotion> dbSet = context.Promotions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Promotion Activate(Promotion entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Promotion Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Promotion Deactivate(Promotion entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Promotion Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Promotion> GetActive()
		{
			return context.Promotions;
		}
		
		public override IQueryable<Promotion> GetActive(Expression<Func<Promotion, bool>> expr)
		{
			return context.Promotions.Where(expr);
		}
		
		public override Promotion FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Promotion FirstOrDefault(Expression<Func<Promotion, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Promotion> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Promotion> FirstOrDefaultAsync(Expression<Func<Promotion, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Promotion SingleOrDefault(Expression<Func<Promotion, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Promotion> SingleOrDefaultAsync(Expression<Func<Promotion, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Promotion Update(Promotion entity)
		{
			entity = context.Promotions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Promotion> UpdateAsync(Promotion entity)
		{
			entity = context.Promotions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
