using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IWebCustomerFeedbackService : IBaseService<WebCustomerFeedback, WebCustomerFeedbackViewModel, int>
	{
	}
	
	public partial class WebCustomerFeedbackService : BaseService, IWebCustomerFeedbackService
	{
		private IWebCustomerFeedbackRepository repository;
		
		public WebCustomerFeedbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebCustomerFeedbackRepository>(uow);
		}
		
		public override bool AutoSave
		{
			get
			{
				return repository.AutoSave;
			}
			set
			{
				repository.AutoSave = value;
			}
		}
		
		#region CRUD Area
		public WebCustomerFeedback Add(WebCustomerFeedback entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<WebCustomerFeedback> AddAsync(WebCustomerFeedback entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public WebCustomerFeedback Update(WebCustomerFeedback entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<WebCustomerFeedback> UpdateAsync(WebCustomerFeedback entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public WebCustomerFeedback Delete(WebCustomerFeedback entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<WebCustomerFeedback> DeleteAsync(WebCustomerFeedback entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public WebCustomerFeedback Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<WebCustomerFeedback> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public WebCustomerFeedback FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<WebCustomerFeedback> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public WebCustomerFeedback Activate(WebCustomerFeedback entity)
		{
			return repository.Activate(entity);
		}
		
		public WebCustomerFeedback Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public WebCustomerFeedback Deactivate(WebCustomerFeedback entity)
		{
			return repository.Deactivate(entity);
		}
		
		public WebCustomerFeedback Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<WebCustomerFeedback> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<WebCustomerFeedback> GetActive(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public WebCustomerFeedback FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public WebCustomerFeedback FirstOrDefault(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<WebCustomerFeedback> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<WebCustomerFeedback> FirstOrDefaultAsync(Expression<Func<WebCustomerFeedback, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WebCustomerFeedbackService()
		{
			repository = G.TContainer.Resolve<IWebCustomerFeedbackRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebCustomerFeedbackService()
		{
			Dispose(false);
		}
		#endregion
	}
}
