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
	public partial interface IPaymentReportService : IBaseService<PaymentReport, PaymentReportViewModel, int>
	{
	}
	
	public partial class PaymentReportService : BaseService, IPaymentReportService
	{
		private IPaymentReportRepository repository;
		
		public PaymentReportService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaymentReportRepository>(uow);
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
		public PaymentReport Add(PaymentReport entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PaymentReport> AddAsync(PaymentReport entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PaymentReport Update(PaymentReport entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PaymentReport> UpdateAsync(PaymentReport entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PaymentReport Delete(PaymentReport entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PaymentReport> DeleteAsync(PaymentReport entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PaymentReport Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PaymentReport> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PaymentReport FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PaymentReport> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PaymentReport Activate(PaymentReport entity)
		{
			return repository.Activate(entity);
		}
		
		public PaymentReport Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PaymentReport Deactivate(PaymentReport entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PaymentReport Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PaymentReport> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PaymentReport> GetActive(Expression<Func<PaymentReport, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PaymentReport FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PaymentReport FirstOrDefault(Expression<Func<PaymentReport, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PaymentReport> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PaymentReport> FirstOrDefaultAsync(Expression<Func<PaymentReport, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PaymentReportService()
		{
			repository = G.TContainer.Resolve<IPaymentReportRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaymentReportService()
		{
			Dispose(false);
		}
		#endregion
	}
}
