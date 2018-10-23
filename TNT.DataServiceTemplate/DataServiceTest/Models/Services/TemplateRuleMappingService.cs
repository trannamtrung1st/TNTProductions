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
	public partial interface ITemplateRuleMappingService : IBaseService<TemplateRuleMapping, TemplateRuleMappingViewModel, int>
	{
	}
	
	public partial class TemplateRuleMappingService : BaseService, ITemplateRuleMappingService
	{
		private ITemplateRuleMappingRepository repository;
		
		public TemplateRuleMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITemplateRuleMappingRepository>(uow);
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
		public TemplateRuleMapping Add(TemplateRuleMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<TemplateRuleMapping> AddAsync(TemplateRuleMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public TemplateRuleMapping Update(TemplateRuleMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<TemplateRuleMapping> UpdateAsync(TemplateRuleMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public TemplateRuleMapping Delete(TemplateRuleMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<TemplateRuleMapping> DeleteAsync(TemplateRuleMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public TemplateRuleMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<TemplateRuleMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public TemplateRuleMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<TemplateRuleMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public TemplateRuleMapping Activate(TemplateRuleMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public TemplateRuleMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public TemplateRuleMapping Deactivate(TemplateRuleMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public TemplateRuleMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<TemplateRuleMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<TemplateRuleMapping> GetActive(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public TemplateRuleMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public TemplateRuleMapping FirstOrDefault(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<TemplateRuleMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<TemplateRuleMapping> FirstOrDefaultAsync(Expression<Func<TemplateRuleMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public TemplateRuleMappingService()
		{
			repository = G.TContainer.Resolve<ITemplateRuleMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TemplateRuleMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
