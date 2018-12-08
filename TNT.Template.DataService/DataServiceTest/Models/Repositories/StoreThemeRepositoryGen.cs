using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IStoreThemeRepository : IBaseRepository<StoreTheme, int>
	{
	}
	
	public partial class StoreThemeRepository : BaseRepository<StoreTheme, int>, IStoreThemeRepository
	{
		public StoreThemeRepository(DbContext context) : base(context)
		{
		}
		
		public StoreThemeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreTheme FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.StoreThemeId == key);
			return entity;
		}
		
		public override StoreTheme FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.StoreThemeId == key && e.Active);
			return entity;
		}
		
		public override async Task<StoreTheme> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.StoreThemeId == key);
			return entity;
		}
		
		public override async Task<StoreTheme> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.StoreThemeId == key && e.Active);
			return entity;
		}
		
		public override StoreTheme Activate(StoreTheme entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override StoreTheme Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override StoreTheme Deactivate(StoreTheme entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override StoreTheme Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<StoreTheme> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<StoreTheme> GetActive(Expression<Func<StoreTheme, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
