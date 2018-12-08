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
	public partial interface IWebMenuCategoryRepository : IBaseRepository<WebMenuCategory, int>
	{
	}
	
	public partial class WebMenuCategoryRepository : BaseRepository<WebMenuCategory, int>, IWebMenuCategoryRepository
	{
		public WebMenuCategoryRepository(DbContext context) : base(context)
		{
		}
		
		public WebMenuCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebMenuCategory FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebMenuCategory FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebMenuCategory> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebMenuCategory> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override WebMenuCategory Activate(WebMenuCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebMenuCategory Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebMenuCategory Deactivate(WebMenuCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override WebMenuCategory Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<WebMenuCategory> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<WebMenuCategory> GetActive(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
