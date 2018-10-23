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
	public partial interface IPayrollPeriodService : IBaseService<PayrollPeriod, PayrollPeriodViewModel, int>
	{
	}
	
	public partial class PayrollPeriodService : BaseService, IPayrollPeriodService
	{
		private IPayrollPeriodRepository repository;
		
		public PayrollPeriodService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollPeriodRepository>(uow);
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
		public PayrollPeriod Add(PayrollPeriod entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PayrollPeriod> AddAsync(PayrollPeriod entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PayrollPeriod Update(PayrollPeriod entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PayrollPeriod> UpdateAsync(PayrollPeriod entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PayrollPeriod Delete(PayrollPeriod entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PayrollPeriod> DeleteAsync(PayrollPeriod entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PayrollPeriod Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PayrollPeriod> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PayrollPeriod FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PayrollPeriod> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PayrollPeriod Activate(PayrollPeriod entity)
		{
			return repository.Activate(entity);
		}
		
		public PayrollPeriod Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PayrollPeriod Deactivate(PayrollPeriod entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PayrollPeriod Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PayrollPeriod> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PayrollPeriod> GetActive(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PayrollPeriod FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PayrollPeriod FirstOrDefault(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PayrollPeriod> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PayrollPeriod> FirstOrDefaultAsync(Expression<Func<PayrollPeriod, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PayrollPeriodService()
		{
			repository = G.TContainer.Resolve<IPayrollPeriodRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayrollPeriodService()
		{
			Dispose(false);
		}
		#endregion
	}
}
