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
	public partial interface IPromotionTypeRepository : IBaseRepository<PromotionType, PromotionTypePK>
	{
	}
	
	public partial class PromotionTypeRepository : BaseRepository<PromotionType, PromotionTypePK>, IPromotionTypeRepository
	{
		public PromotionTypeRepository() : base()
		{
		}
		
		public PromotionTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PromotionType Add(PromotionType entity)
		{
			
			entity = context.PromotionTypes.Add(entity);
			return entity;
		}
		
		public override PromotionType Remove(PromotionType entity)
		{
			context.PromotionTypes.Attach(entity);
			entity = context.PromotionTypes.Remove(entity);
			return entity;
		}
		
		public override PromotionType Remove(PromotionTypePK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PromotionTypes.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PromotionType> RemoveIf(Expression<Func<PromotionType, bool>> expr)
		{
			return context.PromotionTypes.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PromotionType> RemoveRange(IEnumerable<PromotionType> list)
		{
			return context.PromotionTypes.RemoveRange(list);
		}
		
		public override PromotionType FindById(PromotionTypePK key)
		{
			var entity = context.PromotionTypes.FirstOrDefault(
				e => e.PromotionDetailID == key.PromotionDetailID && e.Type == key.Type);
			return entity;
		}
		
		public override PromotionType FindActiveById(PromotionTypePK key)
		{
			var entity = context.PromotionTypes.FirstOrDefault(
				e => e.PromotionDetailID == key.PromotionDetailID && e.Type == key.Type);
			return entity;
		}
		
		public override async Task<PromotionType> FindByIdAsync(PromotionTypePK key)
		{
			var entity = await context.PromotionTypes.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key.PromotionDetailID && e.Type == key.Type);
			return entity;
		}
		
		public override async Task<PromotionType> FindActiveByIdAsync(PromotionTypePK key)
		{
			var entity = await context.PromotionTypes.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key.PromotionDetailID && e.Type == key.Type);
			return entity;
		}
		
		public override PromotionType FindByIdInclude<TProperty>(PromotionTypePK key, params Expression<Func<PromotionType, TProperty>>[] members)
		{
			IQueryable<PromotionType> dbSet = context.PromotionTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PromotionDetailID == key.PromotionDetailID && e.Type == key.Type);
		}
		
		public override async Task<PromotionType> FindByIdIncludeAsync<TProperty>(PromotionTypePK key, params Expression<Func<PromotionType, TProperty>>[] members)
		{
			IQueryable<PromotionType> dbSet = context.PromotionTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PromotionDetailID == key.PromotionDetailID && e.Type == key.Type);
		}
		
		public override PromotionType Activate(PromotionType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionType Activate(PromotionTypePK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionType Deactivate(PromotionType entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PromotionType Deactivate(PromotionTypePK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PromotionType> GetActive()
		{
			return context.PromotionTypes;
		}
		
		public override IQueryable<PromotionType> GetActive(Expression<Func<PromotionType, bool>> expr)
		{
			return context.PromotionTypes.Where(expr);
		}
		
		public override PromotionType FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PromotionType FirstOrDefault(Expression<Func<PromotionType, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PromotionType> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PromotionType> FirstOrDefaultAsync(Expression<Func<PromotionType, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PromotionType SingleOrDefault(Expression<Func<PromotionType, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PromotionType> SingleOrDefaultAsync(Expression<Func<PromotionType, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PromotionType Update(PromotionType entity)
		{
			entity = context.PromotionTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
