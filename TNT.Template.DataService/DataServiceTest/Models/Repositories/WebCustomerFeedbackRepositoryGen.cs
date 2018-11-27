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
		public WebCustomerFeedbackRepository() : base()
		{
		}
		
		public WebCustomerFeedbackRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override WebCustomerFeedback Add(WebCustomerFeedback entity)
		{
			entity.Active = true;
			entity = context.WebCustomerFeedbacks.Add(entity);
			return entity;
		}
		
		public override WebCustomerFeedback Remove(WebCustomerFeedback entity)
		{
			context.WebCustomerFeedbacks.Attach(entity);
			entity = context.WebCustomerFeedbacks.Remove(entity);
			return entity;
		}
		
		public override WebCustomerFeedback Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.WebCustomerFeedbacks.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<WebCustomerFeedback> RemoveIf(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return context.WebCustomerFeedbacks.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<WebCustomerFeedback> RemoveRange(IEnumerable<WebCustomerFeedback> list)
		{
			return context.WebCustomerFeedbacks.RemoveRange(list);
		}
		
		public override WebCustomerFeedback FindById(int key)
		{
			var entity = context.WebCustomerFeedbacks.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override WebCustomerFeedback FindActiveById(int key)
		{
			var entity = context.WebCustomerFeedbacks.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<WebCustomerFeedback> FindByIdAsync(int key)
		{
			var entity = await context.WebCustomerFeedbacks.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<WebCustomerFeedback> FindActiveByIdAsync(int key)
		{
			var entity = await context.WebCustomerFeedbacks.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override WebCustomerFeedback FindByIdInclude<TProperty>(int key, params Expression<Func<WebCustomerFeedback, TProperty>>[] members)
		{
			IQueryable<WebCustomerFeedback> dbSet = context.WebCustomerFeedbacks;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<WebCustomerFeedback> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<WebCustomerFeedback, TProperty>>[] members)
		{
			IQueryable<WebCustomerFeedback> dbSet = context.WebCustomerFeedbacks;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
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
			return context.WebCustomerFeedbacks.Where(e => e.Active);
		}
		
		public override IQueryable<WebCustomerFeedback> GetActive(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return context.WebCustomerFeedbacks.Where(e => e.Active).Where(expr);
		}
		
		public override WebCustomerFeedback FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override WebCustomerFeedback FirstOrDefault(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<WebCustomerFeedback> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<WebCustomerFeedback> FirstOrDefaultAsync(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override WebCustomerFeedback SingleOrDefault(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<WebCustomerFeedback> SingleOrDefaultAsync(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override WebCustomerFeedback Update(WebCustomerFeedback entity)
		{
			entity = context.WebCustomerFeedbacks.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
