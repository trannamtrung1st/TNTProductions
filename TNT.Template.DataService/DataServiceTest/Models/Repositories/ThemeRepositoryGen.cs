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
	public partial interface IThemeRepository : IBaseRepository<Theme, int>
	{
	}
	
	public partial class ThemeRepository : BaseRepository<Theme, int>, IThemeRepository
	{
		public ThemeRepository(DbContext context) : base(context)
		{
		}
		
		public ThemeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Theme FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ThemeId == key);
			return entity;
		}
		
		public override Theme FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ThemeId == key && e.Active);
			return entity;
		}
		
		public override async Task<Theme> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ThemeId == key);
			return entity;
		}
		
		public override async Task<Theme> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ThemeId == key && e.Active);
			return entity;
		}
		
		public override Theme Activate(Theme entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Theme Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Theme Deactivate(Theme entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Theme Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Theme> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Theme> GetActive(Expression<Func<Theme, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
