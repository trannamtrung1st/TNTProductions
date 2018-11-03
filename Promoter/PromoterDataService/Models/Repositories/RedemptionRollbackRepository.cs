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
	public partial interface IRedemptionRollbackRepository : IBaseRepository<RedemptionRollback, int>
	{
	}
	
	public partial class RedemptionRollbackRepository : BaseRepository<RedemptionRollback, int>, IRedemptionRollbackRepository
	{
		public RedemptionRollbackRepository() : base()
		{
		}
		
		public RedemptionRollbackRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RedemptionRollback Add(RedemptionRollback entity)
		{
			
			entity = context.RedemptionRollbacks.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RedemptionRollback> AddAsync(RedemptionRollback entity)
		{
			
			entity = context.RedemptionRollbacks.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override RedemptionRollback Delete(RedemptionRollback entity)
		{
			context.RedemptionRollbacks.Attach(entity);
			entity = context.RedemptionRollbacks.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RedemptionRollback> DeleteAsync(RedemptionRollback entity)
		{
			context.RedemptionRollbacks.Attach(entity);
			entity = context.RedemptionRollbacks.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override RedemptionRollback Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RedemptionRollbacks.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RedemptionRollback> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RedemptionRollbacks.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override RedemptionRollback FindById(int key)
		{
			var entity = context.RedemptionRollbacks.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override RedemptionRollback FindActiveById(int key)
		{
			var entity = context.RedemptionRollbacks.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<RedemptionRollback> FindByIdAsync(int key)
		{
			var entity = await context.RedemptionRollbacks.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<RedemptionRollback> FindActiveByIdAsync(int key)
		{
			var entity = await context.RedemptionRollbacks.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override RedemptionRollback FindByIdInclude<TProperty>(int key, params Expression<Func<RedemptionRollback, TProperty>>[] members)
		{
			IQueryable<RedemptionRollback> dbSet = context.RedemptionRollbacks;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<RedemptionRollback> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<RedemptionRollback, TProperty>>[] members)
		{
			IQueryable<RedemptionRollback> dbSet = context.RedemptionRollbacks;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override RedemptionRollback Activate(RedemptionRollback entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RedemptionRollback Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RedemptionRollback Deactivate(RedemptionRollback entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RedemptionRollback Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<RedemptionRollback> GetActive()
		{
			return context.RedemptionRollbacks;
		}
		
		public override IQueryable<RedemptionRollback> GetActive(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return context.RedemptionRollbacks.Where(expr);
		}
		
		public override RedemptionRollback FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override RedemptionRollback FirstOrDefault(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<RedemptionRollback> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<RedemptionRollback> FirstOrDefaultAsync(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override RedemptionRollback SingleOrDefault(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<RedemptionRollback> SingleOrDefaultAsync(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override RedemptionRollback Update(RedemptionRollback entity)
		{
			entity = context.RedemptionRollbacks.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<RedemptionRollback> UpdateAsync(RedemptionRollback entity)
		{
			entity = context.RedemptionRollbacks.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
