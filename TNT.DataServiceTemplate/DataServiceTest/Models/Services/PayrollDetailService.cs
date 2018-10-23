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
	public partial interface IPayrollDetailService : IBaseService<PayrollDetail, PayrollDetailViewModel, int>
	{
	}
	
	public partial class PayrollDetailService : BaseService, IPayrollDetailService
	{
		private IPayrollDetailRepository repository;
		
		public PayrollDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPayrollDetailRepository>(uow);
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
		public PayrollDetail Add(PayrollDetail entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PayrollDetail> AddAsync(PayrollDetail entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PayrollDetail Update(PayrollDetail entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PayrollDetail> UpdateAsync(PayrollDetail entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PayrollDetail Delete(PayrollDetail entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PayrollDetail> DeleteAsync(PayrollDetail entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PayrollDetail Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PayrollDetail> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PayrollDetail FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PayrollDetail> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PayrollDetail Activate(PayrollDetail entity)
		{
			return repository.Activate(entity);
		}
		
		public PayrollDetail Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PayrollDetail Deactivate(PayrollDetail entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PayrollDetail Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PayrollDetail> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PayrollDetail> GetActive(Expression<Func<PayrollDetail, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PayrollDetail FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PayrollDetail FirstOrDefault(Expression<Func<PayrollDetail, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PayrollDetail> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PayrollDetail> FirstOrDefaultAsync(Expression<Func<PayrollDetail, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PayrollDetailService()
		{
			repository = G.TContainer.Resolve<IPayrollDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PayrollDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
