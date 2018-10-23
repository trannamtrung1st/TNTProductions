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
	public partial interface IPaySlipItemService : IBaseService<PaySlipItem, PaySlipItemViewModel, int>
	{
	}
	
	public partial class PaySlipItemService : BaseService, IPaySlipItemService
	{
		private IPaySlipItemRepository repository;
		
		public PaySlipItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipItemRepository>(uow);
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
		public PaySlipItem Add(PaySlipItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PaySlipItem> AddAsync(PaySlipItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PaySlipItem Update(PaySlipItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PaySlipItem> UpdateAsync(PaySlipItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PaySlipItem Delete(PaySlipItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PaySlipItem> DeleteAsync(PaySlipItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PaySlipItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PaySlipItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PaySlipItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PaySlipItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PaySlipItem Activate(PaySlipItem entity)
		{
			return repository.Activate(entity);
		}
		
		public PaySlipItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PaySlipItem Deactivate(PaySlipItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PaySlipItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PaySlipItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PaySlipItem> GetActive(Expression<Func<PaySlipItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PaySlipItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PaySlipItem FirstOrDefault(Expression<Func<PaySlipItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PaySlipItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PaySlipItem> FirstOrDefaultAsync(Expression<Func<PaySlipItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PaySlipItemService()
		{
			repository = G.TContainer.Resolve<IPaySlipItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaySlipItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
