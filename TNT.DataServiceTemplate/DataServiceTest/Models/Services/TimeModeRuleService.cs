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
	public partial interface ITimeModeRuleService : IBaseService<TimeModeRule, TimeModeRuleViewModel, int>
	{
	}
	
	public partial class TimeModeRuleService : BaseService, ITimeModeRuleService
	{
		private ITimeModeRuleRepository repository;
		
		public TimeModeRuleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITimeModeRuleRepository>(uow);
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
		public TimeModeRule Add(TimeModeRule entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TimeModeRule> AddAsync(TimeModeRule entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TimeModeRule Update(TimeModeRule entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TimeModeRule> UpdateAsync(TimeModeRule entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TimeModeRule Delete(TimeModeRule entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TimeModeRule> DeleteAsync(TimeModeRule entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TimeModeRule Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TimeModeRule> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TimeModeRule FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TimeModeRule> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TimeModeRule Activate(TimeModeRule entity)
		{
			return repository.Activate(entity);
		}
		
		public TimeModeRule Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TimeModeRule Deactivate(TimeModeRule entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TimeModeRule Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TimeModeRule> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TimeModeRule> GetActive(Expression<Func<TimeModeRule, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TimeModeRule FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TimeModeRule FirstOrDefault(Expression<Func<TimeModeRule, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TimeModeRule> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TimeModeRule> FirstOrDefaultAsync(Expression<Func<TimeModeRule, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TimeModeRuleService()
		{
			repository = G.TContainer.Resolve<ITimeModeRuleRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TimeModeRuleService()
		{
			Dispose(false);
		}
		#endregion
	}
}
