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
	public partial interface IGiftAppliedDetailRepository : IBaseRepository<GiftAppliedDetail, GiftAppliedDetailPK>
	{
	}
	
	public partial class GiftAppliedDetailRepository : BaseRepository<GiftAppliedDetail, GiftAppliedDetailPK>, IGiftAppliedDetailRepository
	{
		public GiftAppliedDetailRepository() : base()
		{
		}
		
		public GiftAppliedDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override GiftAppliedDetail Add(GiftAppliedDetail entity)
		{
			
			entity = context.GiftAppliedDetails.Add(entity);
			return entity;
		}
		
		public override GiftAppliedDetail Remove(GiftAppliedDetail entity)
		{
			context.GiftAppliedDetails.Attach(entity);
			entity = context.GiftAppliedDetails.Remove(entity);
			return entity;
		}
		
		public override GiftAppliedDetail Remove(GiftAppliedDetailPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.GiftAppliedDetails.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<GiftAppliedDetail> RemoveIf(Expression<Func<GiftAppliedDetail, bool>> expr)
		{
			return context.GiftAppliedDetails.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<GiftAppliedDetail> RemoveRange(IEnumerable<GiftAppliedDetail> list)
		{
			return context.GiftAppliedDetails.RemoveRange(list);
		}
		
		public override GiftAppliedDetail FindById(GiftAppliedDetailPK key)
		{
			var entity = context.GiftAppliedDetails.FirstOrDefault(
				e => e.PromotionAppliedDetailID == key.PromotionAppliedDetailID && e.ProductIID == key.ProductIID);
			return entity;
		}
		
		public override GiftAppliedDetail FindActiveById(GiftAppliedDetailPK key)
		{
			var entity = context.GiftAppliedDetails.FirstOrDefault(
				e => e.PromotionAppliedDetailID == key.PromotionAppliedDetailID && e.ProductIID == key.ProductIID);
			return entity;
		}
		
		public override async Task<GiftAppliedDetail> FindByIdAsync(GiftAppliedDetailPK key)
		{
			var entity = await context.GiftAppliedDetails.FirstOrDefaultAsync(
				e => e.PromotionAppliedDetailID == key.PromotionAppliedDetailID && e.ProductIID == key.ProductIID);
			return entity;
		}
		
		public override async Task<GiftAppliedDetail> FindActiveByIdAsync(GiftAppliedDetailPK key)
		{
			var entity = await context.GiftAppliedDetails.FirstOrDefaultAsync(
				e => e.PromotionAppliedDetailID == key.PromotionAppliedDetailID && e.ProductIID == key.ProductIID);
			return entity;
		}
		
		public override GiftAppliedDetail FindByIdInclude<TProperty>(GiftAppliedDetailPK key, params Expression<Func<GiftAppliedDetail, TProperty>>[] members)
		{
			IQueryable<GiftAppliedDetail> dbSet = context.GiftAppliedDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PromotionAppliedDetailID == key.PromotionAppliedDetailID && e.ProductIID == key.ProductIID);
		}
		
		public override async Task<GiftAppliedDetail> FindByIdIncludeAsync<TProperty>(GiftAppliedDetailPK key, params Expression<Func<GiftAppliedDetail, TProperty>>[] members)
		{
			IQueryable<GiftAppliedDetail> dbSet = context.GiftAppliedDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PromotionAppliedDetailID == key.PromotionAppliedDetailID && e.ProductIID == key.ProductIID);
		}
		
		public override GiftAppliedDetail Activate(GiftAppliedDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftAppliedDetail Activate(GiftAppliedDetailPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftAppliedDetail Deactivate(GiftAppliedDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override GiftAppliedDetail Deactivate(GiftAppliedDetailPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<GiftAppliedDetail> GetActive()
		{
			return context.GiftAppliedDetails;
		}
		
		public override IQueryable<GiftAppliedDetail> GetActive(Expression<Func<GiftAppliedDetail, bool>> expr)
		{
			return context.GiftAppliedDetails.Where(expr);
		}
		
		public override GiftAppliedDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override GiftAppliedDetail FirstOrDefault(Expression<Func<GiftAppliedDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<GiftAppliedDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<GiftAppliedDetail> FirstOrDefaultAsync(Expression<Func<GiftAppliedDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override GiftAppliedDetail SingleOrDefault(Expression<Func<GiftAppliedDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<GiftAppliedDetail> SingleOrDefaultAsync(Expression<Func<GiftAppliedDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override GiftAppliedDetail Update(GiftAppliedDetail entity)
		{
			entity = context.GiftAppliedDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
