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
	public partial interface ISalaryRuleService : IBaseService<SalaryRule, SalaryRuleViewModel, int>
	{
	}
	
	public partial class SalaryRuleService : BaseService, ISalaryRuleService
	{
		private ISalaryRuleRepository repository;
		
		public SalaryRuleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISalaryRuleRepository>(uow);
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
		public SalaryRule Add(SalaryRule entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<SalaryRule> AddAsync(SalaryRule entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public SalaryRule Update(SalaryRule entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<SalaryRule> UpdateAsync(SalaryRule entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public SalaryRule Delete(SalaryRule entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<SalaryRule> DeleteAsync(SalaryRule entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public SalaryRule Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<SalaryRule> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public SalaryRule FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<SalaryRule> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public SalaryRule Activate(SalaryRule entity)
		{
			return repository.Activate(entity);
		}
		
		public SalaryRule Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public SalaryRule Deactivate(SalaryRule entity)
		{
			return repository.Deactivate(entity);
		}
		
		public SalaryRule Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<SalaryRule> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<SalaryRule> GetActive(Expression<Func<SalaryRule, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public SalaryRule FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public SalaryRule FirstOrDefault(Expression<Func<SalaryRule, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<SalaryRule> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<SalaryRule> FirstOrDefaultAsync(Expression<Func<SalaryRule, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public SalaryRuleService()
		{
			repository = G.TContainer.Resolve<ISalaryRuleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SalaryRuleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
