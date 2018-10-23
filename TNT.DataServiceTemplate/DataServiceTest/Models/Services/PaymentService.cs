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
	public partial interface IPaymentService : IBaseService<Payment, PaymentViewModel, int>
	{
	}
	
	public partial class PaymentService : BaseService, IPaymentService
	{
		private IPaymentRepository repository;
		
		public PaymentService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaymentRepository>(uow);
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
		public Payment Add(Payment entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Payment> AddAsync(Payment entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Payment Update(Payment entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Payment> UpdateAsync(Payment entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Payment Delete(Payment entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Payment> DeleteAsync(Payment entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Payment Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Payment> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Payment FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Payment> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Payment Activate(Payment entity)
		{
			return repository.Activate(entity);
		}
		
		public Payment Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Payment Deactivate(Payment entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Payment Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Payment> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Payment> GetActive(Expression<Func<Payment, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Payment FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Payment FirstOrDefault(Expression<Func<Payment, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Payment> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Payment> FirstOrDefaultAsync(Expression<Func<Payment, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PaymentService()
		{
			repository = G.TContainer.Resolve<IPaymentRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaymentService()
		{
			Dispose(false);
		}
		#endregion
	}
}
