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
	public partial interface IWebElementTypeRepository : IBaseRepository<WebElementType, int>
	{
	}
	
	public partial class WebElementTypeRepository : BaseRepository<WebElementType, int>, IWebElementTypeRepository
	{
		public WebElementTypeRepository(DbContext context) : base(context)
		{
		}
		
		public WebElementTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebElementType FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebElementType FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebElementType> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebElementType> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebElementType Activate(WebElementType entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override WebElementType Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override WebElementType Deactivate(WebElementType entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override WebElementType Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<WebElementType> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<WebElementType> GetActive(Expression<Func<WebElementType, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
