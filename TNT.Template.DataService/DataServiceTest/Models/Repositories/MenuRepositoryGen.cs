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
	public partial interface IMenuRepository : IBaseRepository<Menu, int>
	{
	}
	
	public partial class MenuRepository : BaseRepository<Menu, int>, IMenuRepository
	{
		public MenuRepository(DbContext context) : base(context)
		{
		}
		
		public MenuRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Menu FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Menu FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Menu> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Menu> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Menu Activate(Menu entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Menu Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Menu Deactivate(Menu entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Menu Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Menu> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Menu> GetActive(Expression<Func<Menu, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
