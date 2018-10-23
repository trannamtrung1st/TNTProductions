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
	public partial interface IPromotionDetailRepository : IBaseRepository<PromotionDetail, int>
	{
	}
	
	public partial class PromotionDetailRepository : BaseRepository<PromotionDetail, int>, IPromotionDetailRepository
	{
		public PromotionDetailRepository() : base()
		{
		}
		
		public PromotionDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionDetail Add(PromotionDetail entity)
		{
			
			entity = context.PromotionDetails.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionDetail> AddAsync(PromotionDetail entity)
		{
			
			entity = context.PromotionDetails.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PromotionDetail Delete(PromotionDetail entity)
		{
			context.PromotionDetails.Attach(entity);
			entity = context.PromotionDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionDetail> DeleteAsync(PromotionDetail entity)
		{
			context.PromotionDetails.Attach(entity);
			entity = context.PromotionDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PromotionDetail Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionDetail> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PromotionDetail FindById(int key)
		{
			var entity = context.PromotionDetails.FirstOrDefault(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override PromotionDetail FindActiveById(int key)
		{
			var entity = context.PromotionDetails.FirstOrDefault(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override async Task<PromotionDetail> FindByIdAsync(int key)
		{
			var entity = await context.PromotionDetails.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override async Task<PromotionDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.PromotionDetails.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key);
			return entity;
		}
		
		public override PromotionDetail FindByIdInclude<TProperty>(int key, params Expression<Func<PromotionDetail, TProperty>>[] members)
		{
			IQueryable<PromotionDetail> dbSet = context.PromotionDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PromotionDetailID == key);
		}
		
		public override async Task<PromotionDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PromotionDetail, TProperty>>[] members)
		{
			IQueryable<PromotionDetail> dbSet = context.PromotionDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key);
		}
		
		public override PromotionDetail Activate(PromotionDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionDetail Deactivate(PromotionDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PromotionDetail> GetActive()
		{
			return context.PromotionDetails;
		}
		
		public override IQueryable<PromotionDetail> GetActive(Expression<Func<PromotionDetail, bool>> expr)
		{
			return context.PromotionDetails.Where(expr);
		}
		
		public override PromotionDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PromotionDetail FirstOrDefault(Expression<Func<PromotionDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PromotionDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PromotionDetail> FirstOrDefaultAsync(Expression<Func<PromotionDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PromotionDetail SingleOrDefault(Expression<Func<PromotionDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PromotionDetail> SingleOrDefaultAsync(Expression<Func<PromotionDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PromotionDetail Update(PromotionDetail entity)
		{
			entity = context.PromotionDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionDetail> UpdateAsync(PromotionDetail entity)
		{
			entity = context.PromotionDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
