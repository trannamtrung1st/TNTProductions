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
	public partial interface IPromotionApplySituationRepository : IBaseRepository<PromotionApplySituation, PromotionApplySituationPK>
	{
	}
	
	public partial class PromotionApplySituationRepository : BaseRepository<PromotionApplySituation, PromotionApplySituationPK>, IPromotionApplySituationRepository
	{
		public PromotionApplySituationRepository() : base()
		{
		}
		
		public PromotionApplySituationRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionApplySituation Add(PromotionApplySituation entity)
		{
			
			entity = context.PromotionApplySituations.Add(entity);
			return entity;
		}
		
		public override PromotionApplySituation Remove(PromotionApplySituation entity)
		{
			context.PromotionApplySituations.Attach(entity);
			entity = context.PromotionApplySituations.Remove(entity);
			return entity;
		}
		
		public override PromotionApplySituation Remove(PromotionApplySituationPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionApplySituations.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PromotionApplySituation> RemoveIf(Expression<Func<PromotionApplySituation, bool>> expr)
		{
			return context.PromotionApplySituations.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PromotionApplySituation> RemoveRange(IEnumerable<PromotionApplySituation> list)
		{
			return context.PromotionApplySituations.RemoveRange(list);
		}
		
		public override PromotionApplySituation FindById(PromotionApplySituationPK key)
		{
			var entity = context.PromotionApplySituations.FirstOrDefault(
				e => e.PromotionDetailID == key.PromotionDetailID && e.ApplySituation == key.ApplySituation);
			return entity;
		}
		
		public override PromotionApplySituation FindActiveById(PromotionApplySituationPK key)
		{
			var entity = context.PromotionApplySituations.FirstOrDefault(
				e => e.PromotionDetailID == key.PromotionDetailID && e.ApplySituation == key.ApplySituation);
			return entity;
		}
		
		public override async Task<PromotionApplySituation> FindByIdAsync(PromotionApplySituationPK key)
		{
			var entity = await context.PromotionApplySituations.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key.PromotionDetailID && e.ApplySituation == key.ApplySituation);
			return entity;
		}
		
		public override async Task<PromotionApplySituation> FindActiveByIdAsync(PromotionApplySituationPK key)
		{
			var entity = await context.PromotionApplySituations.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key.PromotionDetailID && e.ApplySituation == key.ApplySituation);
			return entity;
		}
		
		public override PromotionApplySituation FindByIdInclude<TProperty>(PromotionApplySituationPK key, params Expression<Func<PromotionApplySituation, TProperty>>[] members)
		{
			IQueryable<PromotionApplySituation> dbSet = context.PromotionApplySituations;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PromotionDetailID == key.PromotionDetailID && e.ApplySituation == key.ApplySituation);
		}
		
		public override async Task<PromotionApplySituation> FindByIdIncludeAsync<TProperty>(PromotionApplySituationPK key, params Expression<Func<PromotionApplySituation, TProperty>>[] members)
		{
			IQueryable<PromotionApplySituation> dbSet = context.PromotionApplySituations;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key.PromotionDetailID && e.ApplySituation == key.ApplySituation);
		}
		
		public override PromotionApplySituation Activate(PromotionApplySituation entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionApplySituation Activate(PromotionApplySituationPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionApplySituation Deactivate(PromotionApplySituation entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionApplySituation Deactivate(PromotionApplySituationPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PromotionApplySituation> GetActive()
		{
			return context.PromotionApplySituations;
		}
		
		public override IQueryable<PromotionApplySituation> GetActive(Expression<Func<PromotionApplySituation, bool>> expr)
		{
			return context.PromotionApplySituations.Where(expr);
		}
		
		public override PromotionApplySituation FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PromotionApplySituation FirstOrDefault(Expression<Func<PromotionApplySituation, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PromotionApplySituation> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PromotionApplySituation> FirstOrDefaultAsync(Expression<Func<PromotionApplySituation, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PromotionApplySituation SingleOrDefault(Expression<Func<PromotionApplySituation, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PromotionApplySituation> SingleOrDefaultAsync(Expression<Func<PromotionApplySituation, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PromotionApplySituation Update(PromotionApplySituation entity)
		{
			entity = context.PromotionApplySituations.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
