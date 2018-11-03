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
	public partial interface IGiftDetailRepository : IBaseRepository<GiftDetail, GiftDetailPK>
	{
	}
	
	public partial class GiftDetailRepository : BaseRepository<GiftDetail, GiftDetailPK>, IGiftDetailRepository
	{
		public GiftDetailRepository() : base()
		{
		}
		
		public GiftDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override GiftDetail Add(GiftDetail entity)
		{
			
			entity = context.GiftDetails.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<GiftDetail> AddAsync(GiftDetail entity)
		{
			
			entity = context.GiftDetails.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override GiftDetail Delete(GiftDetail entity)
		{
			context.GiftDetails.Attach(entity);
			entity = context.GiftDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<GiftDetail> DeleteAsync(GiftDetail entity)
		{
			context.GiftDetails.Attach(entity);
			entity = context.GiftDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override GiftDetail Delete(GiftDetailPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.GiftDetails.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<GiftDetail> DeleteAsync(GiftDetailPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.GiftDetails.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override GiftDetail FindById(GiftDetailPK key)
		{
			var entity = context.GiftDetails.FirstOrDefault(
				e => e.ProductIID == key.ProductIID && e.PromotionDetailID == key.PromotionDetailID);
			return entity;
		}
		
		public override GiftDetail FindActiveById(GiftDetailPK key)
		{
			var entity = context.GiftDetails.FirstOrDefault(
				e => e.ProductIID == key.ProductIID && e.PromotionDetailID == key.PromotionDetailID);
			return entity;
		}
		
		public override async Task<GiftDetail> FindByIdAsync(GiftDetailPK key)
		{
			var entity = await context.GiftDetails.FirstOrDefaultAsync(
				e => e.ProductIID == key.ProductIID && e.PromotionDetailID == key.PromotionDetailID);
			return entity;
		}
		
		public override async Task<GiftDetail> FindActiveByIdAsync(GiftDetailPK key)
		{
			var entity = await context.GiftDetails.FirstOrDefaultAsync(
				e => e.ProductIID == key.ProductIID && e.PromotionDetailID == key.PromotionDetailID);
			return entity;
		}
		
		public override GiftDetail FindByIdInclude<TProperty>(GiftDetailPK key, params Expression<Func<GiftDetail, TProperty>>[] members)
		{
			IQueryable<GiftDetail> dbSet = context.GiftDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ProductIID == key.ProductIID && e.PromotionDetailID == key.PromotionDetailID);
		}
		
		public override async Task<GiftDetail> FindByIdIncludeAsync<TProperty>(GiftDetailPK key, params Expression<Func<GiftDetail, TProperty>>[] members)
		{
			IQueryable<GiftDetail> dbSet = context.GiftDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ProductIID == key.ProductIID && e.PromotionDetailID == key.PromotionDetailID);
		}
		
		public override GiftDetail Activate(GiftDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftDetail Activate(GiftDetailPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftDetail Deactivate(GiftDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftDetail Deactivate(GiftDetailPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<GiftDetail> GetActive()
		{
			return context.GiftDetails;
		}
		
		public override IQueryable<GiftDetail> GetActive(Expression<Func<GiftDetail, bool>> expr)
		{
			return context.GiftDetails.Where(expr);
		}
		
		public override GiftDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override GiftDetail FirstOrDefault(Expression<Func<GiftDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<GiftDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<GiftDetail> FirstOrDefaultAsync(Expression<Func<GiftDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override GiftDetail SingleOrDefault(Expression<Func<GiftDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<GiftDetail> SingleOrDefaultAsync(Expression<Func<GiftDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override GiftDetail Update(GiftDetail entity)
		{
			entity = context.GiftDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<GiftDetail> UpdateAsync(GiftDetail entity)
		{
			entity = context.GiftDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
