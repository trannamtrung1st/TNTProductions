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
	public partial interface ICustomerFeedbackService : IBaseService<CustomerFeedback, CustomerFeedbackViewModel, CustomerFeedbackPK>
	{
	}
	
	public partial class CustomerFeedbackService : BaseService, ICustomerFeedbackService
	{
		private ICustomerFeedbackRepository repository;
		
		public CustomerFeedbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerFeedbackRepository>(uow);
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
		public CustomerFeedback Add(CustomerFeedback entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CustomerFeedback> AddAsync(CustomerFeedback entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CustomerFeedback Update(CustomerFeedback entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CustomerFeedback> UpdateAsync(CustomerFeedback entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CustomerFeedback Delete(CustomerFeedback entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CustomerFeedback> DeleteAsync(CustomerFeedback entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CustomerFeedback Delete(CustomerFeedbackPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CustomerFeedback> DeleteAsync(CustomerFeedbackPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CustomerFeedback FindById(CustomerFeedbackPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CustomerFeedback> FindByIdAsync(CustomerFeedbackPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CustomerFeedback Activate(CustomerFeedback entity)
		{
			return repository.Activate(entity);
		}
		
		public CustomerFeedback Activate(CustomerFeedbackPK key)
		{
			return repository.Activate(key);
		}
		
		public CustomerFeedback Deactivate(CustomerFeedback entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CustomerFeedback Deactivate(CustomerFeedbackPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CustomerFeedback> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CustomerFeedback> GetActive(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CustomerFeedback FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CustomerFeedback FirstOrDefault(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CustomerFeedback> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CustomerFeedback> FirstOrDefaultAsync(Expression<Func<CustomerFeedback, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CustomerFeedbackService()
		{
			repository = G.TContainer.Resolve<ICustomerFeedbackRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerFeedbackService()
		{
			Dispose(false);
		}
		#endregion
	}
}
