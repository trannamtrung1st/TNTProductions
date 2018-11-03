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
	public partial interface IAffliatorCashbackDetailRepository : IBaseRepository<AffliatorCashbackDetail, int>
	{
	}
	
	public partial class AffliatorCashbackDetailRepository : BaseRepository<AffliatorCashbackDetail, int>, IAffliatorCashbackDetailRepository
	{
		public AffliatorCashbackDetailRepository() : base()
		{
		}
		
		public AffliatorCashbackDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AffliatorCashbackDetail Add(AffliatorCashbackDetail entity)
		{
			
			entity = context.AffliatorCashbackDetails.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AffliatorCashbackDetail> AddAsync(AffliatorCashbackDetail entity)
		{
			
			entity = context.AffliatorCashbackDetails.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AffliatorCashbackDetail Delete(AffliatorCashbackDetail entity)
		{
			context.AffliatorCashbackDetails.Attach(entity);
			entity = context.AffliatorCashbackDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AffliatorCashbackDetail> DeleteAsync(AffliatorCashbackDetail entity)
		{
			context.AffliatorCashbackDetails.Attach(entity);
			entity = context.AffliatorCashbackDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AffliatorCashbackDetail Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AffliatorCashbackDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AffliatorCashbackDetail> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AffliatorCashbackDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AffliatorCashbackDetail FindById(int key)
		{
			var entity = context.AffliatorCashbackDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override AffliatorCashbackDetail FindActiveById(int key)
		{
			var entity = context.AffliatorCashbackDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<AffliatorCashbackDetail> FindByIdAsync(int key)
		{
			var entity = await context.AffliatorCashbackDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<AffliatorCashbackDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.AffliatorCashbackDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override AffliatorCashbackDetail FindByIdInclude<TProperty>(int key, params Expression<Func<AffliatorCashbackDetail, TProperty>>[] members)
		{
			IQueryable<AffliatorCashbackDetail> dbSet = context.AffliatorCashbackDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<AffliatorCashbackDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<AffliatorCashbackDetail, TProperty>>[] members)
		{
			IQueryable<AffliatorCashbackDetail> dbSet = context.AffliatorCashbackDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override AffliatorCashbackDetail Activate(AffliatorCashbackDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AffliatorCashbackDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AffliatorCashbackDetail Deactivate(AffliatorCashbackDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AffliatorCashbackDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AffliatorCashbackDetail> GetActive()
		{
			return context.AffliatorCashbackDetails;
		}
		
		public override IQueryable<AffliatorCashbackDetail> GetActive(Expression<Func<AffliatorCashbackDetail, bool>> expr)
		{
			return context.AffliatorCashbackDetails.Where(expr);
		}
		
		public override AffliatorCashbackDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AffliatorCashbackDetail FirstOrDefault(Expression<Func<AffliatorCashbackDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AffliatorCashbackDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AffliatorCashbackDetail> FirstOrDefaultAsync(Expression<Func<AffliatorCashbackDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AffliatorCashbackDetail SingleOrDefault(Expression<Func<AffliatorCashbackDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AffliatorCashbackDetail> SingleOrDefaultAsync(Expression<Func<AffliatorCashbackDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AffliatorCashbackDetail Update(AffliatorCashbackDetail entity)
		{
			entity = context.AffliatorCashbackDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AffliatorCashbackDetail> UpdateAsync(AffliatorCashbackDetail entity)
		{
			entity = context.AffliatorCashbackDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
