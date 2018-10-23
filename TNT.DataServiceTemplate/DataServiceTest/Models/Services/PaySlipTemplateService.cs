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
	public partial interface IPaySlipTemplateService : IBaseService<PaySlipTemplate, PaySlipTemplateViewModel, int>
	{
	}
	
	public partial class PaySlipTemplateService : BaseService, IPaySlipTemplateService
	{
		private IPaySlipTemplateRepository repository;
		
		public PaySlipTemplateService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPaySlipTemplateRepository>(uow);
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
		public PaySlipTemplate Add(PaySlipTemplate entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PaySlipTemplate> AddAsync(PaySlipTemplate entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PaySlipTemplate Update(PaySlipTemplate entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PaySlipTemplate> UpdateAsync(PaySlipTemplate entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PaySlipTemplate Delete(PaySlipTemplate entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PaySlipTemplate> DeleteAsync(PaySlipTemplate entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PaySlipTemplate Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PaySlipTemplate> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PaySlipTemplate FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PaySlipTemplate> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PaySlipTemplate Activate(PaySlipTemplate entity)
		{
			return repository.Activate(entity);
		}
		
		public PaySlipTemplate Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PaySlipTemplate Deactivate(PaySlipTemplate entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PaySlipTemplate Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PaySlipTemplate> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PaySlipTemplate> GetActive(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PaySlipTemplate FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PaySlipTemplate FirstOrDefault(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PaySlipTemplate> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PaySlipTemplate> FirstOrDefaultAsync(Expression<Func<PaySlipTemplate, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PaySlipTemplateService()
		{
			repository = G.TContainer.Resolve<IPaySlipTemplateRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PaySlipTemplateService()
		{
			Dispose(false);
		}
		#endregion
	}
}
