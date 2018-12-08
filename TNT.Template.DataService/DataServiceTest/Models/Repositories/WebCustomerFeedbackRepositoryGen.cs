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
	public partial interface IWebCustomerFeedbackRepository : IBaseRepository<WebCustomerFeedback, int>
	{
	}
	
	public partial class WebCustomerFeedbackRepository : BaseRepository<WebCustomerFeedback, int>, IWebCustomerFeedbackRepository
	{
		public WebCustomerFeedbackRepository(DbContext context) : base(context)
		{
		}
		
		public WebCustomerFeedbackRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebCustomerFeedback FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebCustomerFeedback FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebCustomerFeedback> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebCustomerFeedback> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebCustomerFeedback Activate(WebCustomerFeedback entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override WebCustomerFeedback Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override WebCustomerFeedback Deactivate(WebCustomerFeedback entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override WebCustomerFeedback Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<WebCustomerFeedback> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<WebCustomerFeedback> GetActive(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
