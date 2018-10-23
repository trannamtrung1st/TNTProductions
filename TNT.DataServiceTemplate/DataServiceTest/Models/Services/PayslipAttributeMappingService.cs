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
	public partial interface IPayslipAttributeMappingService : IBaseService<PayslipAttributeMapping, PayslipAttributeMappingViewModel, int>
	{
	}
	
	public partial class PayslipAttributeMappingService : BaseService, IPayslipAttributeMappingService
	{
		private IPayslipAttributeMappingRepository repository;
		
		public PayslipAttributeMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayslipAttributeMappingRepository>(uow);
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
		public PayslipAttributeMapping Add(PayslipAttributeMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PayslipAttributeMapping> AddAsync(PayslipAttributeMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PayslipAttributeMapping Update(PayslipAttributeMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PayslipAttributeMapping> UpdateAsync(PayslipAttributeMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PayslipAttributeMapping Delete(PayslipAttributeMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PayslipAttributeMapping> DeleteAsync(PayslipAttributeMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PayslipAttributeMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PayslipAttributeMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PayslipAttributeMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PayslipAttributeMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PayslipAttributeMapping Activate(PayslipAttributeMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public PayslipAttributeMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PayslipAttributeMapping Deactivate(PayslipAttributeMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PayslipAttributeMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PayslipAttributeMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PayslipAttributeMapping> GetActive(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PayslipAttributeMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PayslipAttributeMapping FirstOrDefault(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PayslipAttributeMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PayslipAttributeMapping> FirstOrDefaultAsync(Expression<Func<PayslipAttributeMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PayslipAttributeMappingService()
		{
			repository = G.TContainer.Resolve<IPayslipAttributeMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayslipAttributeMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
