using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IValidationRuleService : IBaseService<ValidationRule, ValidationRuleViewModel, int>
	{
	}
	
	public partial class ValidationRuleService : BaseService, IValidationRuleService
	{
		private IValidationRuleRepository repository;
		
		public ValidationRuleService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IValidationRuleRepository>(uow);
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
		public ValidationRule Add(ValidationRule entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ValidationRule> AddAsync(ValidationRule entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ValidationRule Update(ValidationRule entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ValidationRule> UpdateAsync(ValidationRule entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ValidationRule Delete(ValidationRule entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ValidationRule> DeleteAsync(ValidationRule entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ValidationRule Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ValidationRule> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ValidationRule FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ValidationRule> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ValidationRule Activate(ValidationRule entity)
		{
			return repository.Activate(entity);
		}
		
		public ValidationRule Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ValidationRule Deactivate(ValidationRule entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ValidationRule Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ValidationRule> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ValidationRule> GetActive(Expression<Func<ValidationRule, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ValidationRule FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ValidationRule FirstOrDefault(Expression<Func<ValidationRule, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ValidationRule> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ValidationRule> FirstOrDefaultAsync(Expression<Func<ValidationRule, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
