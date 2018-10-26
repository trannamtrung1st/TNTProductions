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
	public partial interface IRedemptionRollbackService : IBaseService<RedemptionRollback, RedemptionRollbackViewModel, int>
	{
	}
	
	public partial class RedemptionRollbackService : BaseService, IRedemptionRollbackService
	{
		private IRedemptionRollbackRepository repository;
		
		public RedemptionRollbackService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRedemptionRollbackRepository>(uow);
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
		public RedemptionRollback Add(RedemptionRollback entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<RedemptionRollback> AddAsync(RedemptionRollback entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public RedemptionRollback Update(RedemptionRollback entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<RedemptionRollback> UpdateAsync(RedemptionRollback entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public RedemptionRollback Delete(RedemptionRollback entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<RedemptionRollback> DeleteAsync(RedemptionRollback entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public RedemptionRollback Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<RedemptionRollback> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public RedemptionRollback FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<RedemptionRollback> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public RedemptionRollback Activate(RedemptionRollback entity)
		{
			return repository.Activate(entity);
		}
		
		public RedemptionRollback Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public RedemptionRollback Deactivate(RedemptionRollback entity)
		{
			return repository.Deactivate(entity);
		}
		
		public RedemptionRollback Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<RedemptionRollback> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<RedemptionRollback> GetActive(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public RedemptionRollback FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public RedemptionRollback FirstOrDefault(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<RedemptionRollback> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<RedemptionRollback> FirstOrDefaultAsync(Expression<Func<RedemptionRollback, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
