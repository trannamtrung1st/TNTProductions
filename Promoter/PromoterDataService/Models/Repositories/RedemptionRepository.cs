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
	public partial interface IRedemptionRepository : IBaseRepository<Redemption, int>
	{
	}
	
	public partial class RedemptionRepository : BaseRepository<Redemption, int>, IRedemptionRepository
	{
		public RedemptionRepository() : base()
		{
		}
		
		public RedemptionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Redemption Add(Redemption entity)
		{
			
			entity = context.Redemptions.Add(entity);
			return entity;
		}
		
		public override Redemption Remove(Redemption entity)
		{
			context.Redemptions.Attach(entity);
			entity = context.Redemptions.Remove(entity);
			return entity;
		}
		
		public override Redemption Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Redemptions.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Redemption> RemoveIf(Expression<Func<Redemption, bool>> expr)
		{
			return context.Redemptions.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Redemption> RemoveRange(IEnumerable<Redemption> list)
		{
			return context.Redemptions.RemoveRange(list);
		}
		
		public override Redemption FindById(int key)
		{
			var entity = context.Redemptions.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Redemption FindActiveById(int key)
		{
			var entity = context.Redemptions.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Redemption> FindByIdAsync(int key)
		{
			var entity = await context.Redemptions.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Redemption> FindActiveByIdAsync(int key)
		{
			var entity = await context.Redemptions.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Redemption FindByIdInclude<TProperty>(int key, params Expression<Func<Redemption, TProperty>>[] members)
		{
			IQueryable<Redemption> dbSet = context.Redemptions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Redemption> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Redemption, TProperty>>[] members)
		{
			IQueryable<Redemption> dbSet = context.Redemptions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Redemption Activate(Redemption entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Redemption Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Redemption Deactivate(Redemption entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Redemption Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Redemption> GetActive()
		{
			return context.Redemptions;
		}
		
		public override IQueryable<Redemption> GetActive(Expression<Func<Redemption, bool>> expr)
		{
			return context.Redemptions.Where(expr);
		}
		
		public override Redemption FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Redemption FirstOrDefault(Expression<Func<Redemption, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Redemption> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Redemption> FirstOrDefaultAsync(Expression<Func<Redemption, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Redemption SingleOrDefault(Expression<Func<Redemption, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Redemption> SingleOrDefaultAsync(Expression<Func<Redemption, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Redemption Update(Redemption entity)
		{
			entity = context.Redemptions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
