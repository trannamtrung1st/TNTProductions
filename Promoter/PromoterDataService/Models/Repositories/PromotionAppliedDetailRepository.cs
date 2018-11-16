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
	public partial interface IPromotionAppliedDetailRepository : IBaseRepository<PromotionAppliedDetail, int>
	{
	}
	
	public partial class PromotionAppliedDetailRepository : BaseRepository<PromotionAppliedDetail, int>, IPromotionAppliedDetailRepository
	{
		public PromotionAppliedDetailRepository() : base()
		{
		}
		
		public PromotionAppliedDetailRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionAppliedDetail Add(PromotionAppliedDetail entity)
		{
			
			entity = context.PromotionAppliedDetails.Add(entity);
			return entity;
		}
		
		public override PromotionAppliedDetail Remove(PromotionAppliedDetail entity)
		{
			context.PromotionAppliedDetails.Attach(entity);
			entity = context.PromotionAppliedDetails.Remove(entity);
			return entity;
		}
		
		public override PromotionAppliedDetail Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionAppliedDetails.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PromotionAppliedDetail> RemoveIf(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return context.PromotionAppliedDetails.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PromotionAppliedDetail> RemoveRange(IEnumerable<PromotionAppliedDetail> list)
		{
			return context.PromotionAppliedDetails.RemoveRange(list);
		}
		
		public override PromotionAppliedDetail FindById(int key)
		{
			var entity = context.PromotionAppliedDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override PromotionAppliedDetail FindActiveById(int key)
		{
			var entity = context.PromotionAppliedDetails.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<PromotionAppliedDetail> FindByIdAsync(int key)
		{
			var entity = await context.PromotionAppliedDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<PromotionAppliedDetail> FindActiveByIdAsync(int key)
		{
			var entity = await context.PromotionAppliedDetails.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override PromotionAppliedDetail FindByIdInclude<TProperty>(int key, params Expression<Func<PromotionAppliedDetail, TProperty>>[] members)
		{
			IQueryable<PromotionAppliedDetail> dbSet = context.PromotionAppliedDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<PromotionAppliedDetail> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PromotionAppliedDetail, TProperty>>[] members)
		{
			IQueryable<PromotionAppliedDetail> dbSet = context.PromotionAppliedDetails;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override PromotionAppliedDetail Activate(PromotionAppliedDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionAppliedDetail Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionAppliedDetail Deactivate(PromotionAppliedDetail entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionAppliedDetail Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PromotionAppliedDetail> GetActive()
		{
			return context.PromotionAppliedDetails;
		}
		
		public override IQueryable<PromotionAppliedDetail> GetActive(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return context.PromotionAppliedDetails.Where(expr);
		}
		
		public override PromotionAppliedDetail FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PromotionAppliedDetail FirstOrDefault(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PromotionAppliedDetail> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PromotionAppliedDetail> FirstOrDefaultAsync(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PromotionAppliedDetail SingleOrDefault(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PromotionAppliedDetail> SingleOrDefaultAsync(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PromotionAppliedDetail Update(PromotionAppliedDetail entity)
		{
			entity = context.PromotionAppliedDetails.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
