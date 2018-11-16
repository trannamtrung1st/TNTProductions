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
	public partial interface IAppActionRepository : IBaseRepository<AppAction, int>
	{
	}
	
	public partial class AppActionRepository : BaseRepository<AppAction, int>, IAppActionRepository
	{
		public AppActionRepository() : base()
		{
		}
		
		public AppActionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AppAction Add(AppAction entity)
		{
			
			entity = context.AppActions.Add(entity);
			return entity;
		}
		
		public override AppAction Remove(AppAction entity)
		{
			context.AppActions.Attach(entity);
			entity = context.AppActions.Remove(entity);
			return entity;
		}
		
		public override AppAction Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AppActions.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<AppAction> RemoveIf(Expression<Func<AppAction, bool>> expr)
		{
			return context.AppActions.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<AppAction> RemoveRange(IEnumerable<AppAction> list)
		{
			return context.AppActions.RemoveRange(list);
		}
		
		public override AppAction FindById(int key)
		{
			var entity = context.AppActions.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override AppAction FindActiveById(int key)
		{
			var entity = context.AppActions.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<AppAction> FindByIdAsync(int key)
		{
			var entity = await context.AppActions.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<AppAction> FindActiveByIdAsync(int key)
		{
			var entity = await context.AppActions.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override AppAction FindByIdInclude<TProperty>(int key, params Expression<Func<AppAction, TProperty>>[] members)
		{
			IQueryable<AppAction> dbSet = context.AppActions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ID == key);
		}
		
		public override async Task<AppAction> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<AppAction, TProperty>>[] members)
		{
			IQueryable<AppAction> dbSet = context.AppActions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
		}
		
		public override AppAction Activate(AppAction entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AppAction Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AppAction Deactivate(AppAction entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AppAction Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AppAction> GetActive()
		{
			return context.AppActions;
		}
		
		public override IQueryable<AppAction> GetActive(Expression<Func<AppAction, bool>> expr)
		{
			return context.AppActions.Where(expr);
		}
		
		public override AppAction FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AppAction FirstOrDefault(Expression<Func<AppAction, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AppAction> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AppAction> FirstOrDefaultAsync(Expression<Func<AppAction, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AppAction SingleOrDefault(Expression<Func<AppAction, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AppAction> SingleOrDefaultAsync(Expression<Func<AppAction, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AppAction Update(AppAction entity)
		{
			entity = context.AppActions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
