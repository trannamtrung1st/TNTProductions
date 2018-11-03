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
	public partial interface IPromotionStoreRuleRepository : IBaseRepository<PromotionStoreRule, PromotionStoreRulePK>
	{
	}
	
	public partial class PromotionStoreRuleRepository : BaseRepository<PromotionStoreRule, PromotionStoreRulePK>, IPromotionStoreRuleRepository
	{
		public PromotionStoreRuleRepository() : base()
		{
		}
		
		public PromotionStoreRuleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionStoreRule Add(PromotionStoreRule entity)
		{
			
			entity = context.PromotionStoreRules.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionStoreRule> AddAsync(PromotionStoreRule entity)
		{
			
			entity = context.PromotionStoreRules.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PromotionStoreRule Delete(PromotionStoreRule entity)
		{
			context.PromotionStoreRules.Attach(entity);
			entity = context.PromotionStoreRules.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionStoreRule> DeleteAsync(PromotionStoreRule entity)
		{
			context.PromotionStoreRules.Attach(entity);
			entity = context.PromotionStoreRules.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PromotionStoreRule Delete(PromotionStoreRulePK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionStoreRules.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionStoreRule> DeleteAsync(PromotionStoreRulePK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionStoreRules.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override PromotionStoreRule FindById(PromotionStoreRulePK key)
		{
			var entity = context.PromotionStoreRules.FirstOrDefault(
				e => e.ValidationRuleID == key.ValidationRuleID && e.StoreIID == key.StoreIID);
			return entity;
		}
		
		public override PromotionStoreRule FindActiveById(PromotionStoreRulePK key)
		{
			var entity = context.PromotionStoreRules.FirstOrDefault(
				e => e.ValidationRuleID == key.ValidationRuleID && e.StoreIID == key.StoreIID);
			return entity;
		}
		
		public override async Task<PromotionStoreRule> FindByIdAsync(PromotionStoreRulePK key)
		{
			var entity = await context.PromotionStoreRules.FirstOrDefaultAsync(
				e => e.ValidationRuleID == key.ValidationRuleID && e.StoreIID == key.StoreIID);
			return entity;
		}
		
		public override async Task<PromotionStoreRule> FindActiveByIdAsync(PromotionStoreRulePK key)
		{
			var entity = await context.PromotionStoreRules.FirstOrDefaultAsync(
				e => e.ValidationRuleID == key.ValidationRuleID && e.StoreIID == key.StoreIID);
			return entity;
		}
		
		public override PromotionStoreRule FindByIdInclude<TProperty>(PromotionStoreRulePK key, params Expression<Func<PromotionStoreRule, TProperty>>[] members)
		{
			IQueryable<PromotionStoreRule> dbSet = context.PromotionStoreRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ValidationRuleID == key.ValidationRuleID && e.StoreIID == key.StoreIID);
		}
		
		public override async Task<PromotionStoreRule> FindByIdIncludeAsync<TProperty>(PromotionStoreRulePK key, params Expression<Func<PromotionStoreRule, TProperty>>[] members)
		{
			IQueryable<PromotionStoreRule> dbSet = context.PromotionStoreRules;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ValidationRuleID == key.ValidationRuleID && e.StoreIID == key.StoreIID);
		}
		
		public override PromotionStoreRule Activate(PromotionStoreRule entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionStoreRule Activate(PromotionStoreRulePK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionStoreRule Deactivate(PromotionStoreRule entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionStoreRule Deactivate(PromotionStoreRulePK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PromotionStoreRule> GetActive()
		{
			return context.PromotionStoreRules;
		}
		
		public override IQueryable<PromotionStoreRule> GetActive(Expression<Func<PromotionStoreRule, bool>> expr)
		{
			return context.PromotionStoreRules.Where(expr);
		}
		
		public override PromotionStoreRule FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PromotionStoreRule FirstOrDefault(Expression<Func<PromotionStoreRule, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PromotionStoreRule> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PromotionStoreRule> FirstOrDefaultAsync(Expression<Func<PromotionStoreRule, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PromotionStoreRule SingleOrDefault(Expression<Func<PromotionStoreRule, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PromotionStoreRule> SingleOrDefaultAsync(Expression<Func<PromotionStoreRule, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PromotionStoreRule Update(PromotionStoreRule entity)
		{
			entity = context.PromotionStoreRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<PromotionStoreRule> UpdateAsync(PromotionStoreRule entity)
		{
			entity = context.PromotionStoreRules.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
