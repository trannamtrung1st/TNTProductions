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
	public partial interface IPaymentPartnerService : IBaseService<PaymentPartner, PaymentPartnerViewModel, int>
	{
	}
	
	public partial class PaymentPartnerService : BaseService, IPaymentPartnerService
	{
		private IPaymentPartnerRepository repository;
		
		public PaymentPartnerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaymentPartnerRepository>(uow);
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
		public PaymentPartner Add(PaymentPartner entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PaymentPartner> AddAsync(PaymentPartner entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PaymentPartner Update(PaymentPartner entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PaymentPartner> UpdateAsync(PaymentPartner entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PaymentPartner Delete(PaymentPartner entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PaymentPartner> DeleteAsync(PaymentPartner entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PaymentPartner Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PaymentPartner> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PaymentPartner FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PaymentPartner> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PaymentPartner Activate(PaymentPartner entity)
		{
			return repository.Activate(entity);
		}
		
		public PaymentPartner Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PaymentPartner Deactivate(PaymentPartner entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PaymentPartner Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PaymentPartner> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PaymentPartner> GetActive(Expression<Func<PaymentPartner, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PaymentPartner FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PaymentPartner FirstOrDefault(Expression<Func<PaymentPartner, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PaymentPartner> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PaymentPartner> FirstOrDefaultAsync(Expression<Func<PaymentPartner, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PaymentPartnerService()
		{
			repository = G.TContainer.Resolve<IPaymentPartnerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaymentPartnerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
