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
	public partial interface IPayslipAttributeService : IBaseService<PayslipAttribute, PayslipAttributeViewModel, int>
	{
	}
	
	public partial class PayslipAttributeService : BaseService, IPayslipAttributeService
	{
		private IPayslipAttributeRepository repository;
		
		public PayslipAttributeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayslipAttributeRepository>(uow);
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
		public PayslipAttribute Add(PayslipAttribute entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PayslipAttribute> AddAsync(PayslipAttribute entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PayslipAttribute Update(PayslipAttribute entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PayslipAttribute> UpdateAsync(PayslipAttribute entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PayslipAttribute Delete(PayslipAttribute entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PayslipAttribute> DeleteAsync(PayslipAttribute entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PayslipAttribute Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PayslipAttribute> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PayslipAttribute FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PayslipAttribute> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PayslipAttribute Activate(PayslipAttribute entity)
		{
			return repository.Activate(entity);
		}
		
		public PayslipAttribute Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PayslipAttribute Deactivate(PayslipAttribute entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PayslipAttribute Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PayslipAttribute> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PayslipAttribute> GetActive(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PayslipAttribute FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PayslipAttribute FirstOrDefault(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PayslipAttribute> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PayslipAttribute> FirstOrDefaultAsync(Expression<Func<PayslipAttribute, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PayslipAttributeService()
		{
			repository = G.TContainer.Resolve<IPayslipAttributeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayslipAttributeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
