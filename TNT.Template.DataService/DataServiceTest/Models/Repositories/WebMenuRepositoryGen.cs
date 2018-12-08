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
	public partial interface IWebMenuRepository : IBaseRepository<WebMenu, int>
	{
	}
	
	public partial class WebMenuRepository : BaseRepository<WebMenu, int>, IWebMenuRepository
	{
		public WebMenuRepository(DbContext context) : base(context)
		{
		}
		
		public WebMenuRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebMenu FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebMenu FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebMenu> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebMenu> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebMenu Activate(WebMenu entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override WebMenu Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override WebMenu Deactivate(WebMenu entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override WebMenu Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<WebMenu> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<WebMenu> GetActive(Expression<Func<WebMenu, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
