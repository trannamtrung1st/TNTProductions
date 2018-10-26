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
	public partial interface IRedemptionService : IBaseService<Redemption, RedemptionViewModel, int>
	{
	}
	
	public partial class RedemptionService : BaseService, IRedemptionService
	{
		private IRedemptionRepository repository;
		
		public RedemptionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRedemptionRepository>(uow);
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
		public Redemption Add(Redemption entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Redemption> AddAsync(Redemption entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Redemption Update(Redemption entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Redemption> UpdateAsync(Redemption entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Redemption Delete(Redemption entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Redemption> DeleteAsync(Redemption entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Redemption Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Redemption> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Redemption FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Redemption> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Redemption Activate(Redemption entity)
		{
			return repository.Activate(entity);
		}
		
		public Redemption Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Redemption Deactivate(Redemption entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Redemption Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Redemption> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Redemption> GetActive(Expression<Func<Redemption, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Redemption FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Redemption FirstOrDefault(Expression<Func<Redemption, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Redemption> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Redemption> FirstOrDefaultAsync(Expression<Func<Redemption, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
