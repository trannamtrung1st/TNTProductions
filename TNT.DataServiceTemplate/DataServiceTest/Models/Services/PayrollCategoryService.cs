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
	public partial interface IPayrollCategoryService : IBaseService<PayrollCategory, PayrollCategoryViewModel, int>
	{
	}
	
	public partial class PayrollCategoryService : BaseService, IPayrollCategoryService
	{
		private IPayrollCategoryRepository repository;
		
		public PayrollCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollCategoryRepository>(uow);
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
		public PayrollCategory Add(PayrollCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PayrollCategory> AddAsync(PayrollCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PayrollCategory Update(PayrollCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PayrollCategory> UpdateAsync(PayrollCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PayrollCategory Delete(PayrollCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PayrollCategory> DeleteAsync(PayrollCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PayrollCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PayrollCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PayrollCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PayrollCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PayrollCategory Activate(PayrollCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public PayrollCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PayrollCategory Deactivate(PayrollCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PayrollCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PayrollCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PayrollCategory> GetActive(Expression<Func<PayrollCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PayrollCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PayrollCategory FirstOrDefault(Expression<Func<PayrollCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PayrollCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PayrollCategory> FirstOrDefaultAsync(Expression<Func<PayrollCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PayrollCategoryService()
		{
			repository = G.TContainer.Resolve<IPayrollCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayrollCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
