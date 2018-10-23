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
	public partial interface IPaySlipService : IBaseService<PaySlip, PaySlipViewModel, int>
	{
	}
	
	public partial class PaySlipService : BaseService, IPaySlipService
	{
		private IPaySlipRepository repository;
		
		public PaySlipService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipRepository>(uow);
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
		public PaySlip Add(PaySlip entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PaySlip> AddAsync(PaySlip entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PaySlip Update(PaySlip entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PaySlip> UpdateAsync(PaySlip entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PaySlip Delete(PaySlip entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PaySlip> DeleteAsync(PaySlip entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PaySlip Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PaySlip> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PaySlip FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PaySlip> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PaySlip Activate(PaySlip entity)
		{
			return repository.Activate(entity);
		}
		
		public PaySlip Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PaySlip Deactivate(PaySlip entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PaySlip Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PaySlip> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PaySlip> GetActive(Expression<Func<PaySlip, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PaySlip FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PaySlip FirstOrDefault(Expression<Func<PaySlip, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PaySlip> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PaySlip> FirstOrDefaultAsync(Expression<Func<PaySlip, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PaySlipService()
		{
			repository = G.TContainer.Resolve<IPaySlipRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaySlipService()
		{
			Dispose(false);
		}
		#endregion
	}
}
