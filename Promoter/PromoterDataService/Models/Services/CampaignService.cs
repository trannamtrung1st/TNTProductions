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
	public partial interface ICampaignService : IBaseService<Campaign, CampaignViewModel, int>
	{
	}
	
	public partial class CampaignService : BaseService, ICampaignService
	{
		private ICampaignRepository repository;
		
		public CampaignService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICampaignRepository>(uow);
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
		public Campaign Add(Campaign entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Campaign> AddAsync(Campaign entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Campaign Update(Campaign entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Campaign> UpdateAsync(Campaign entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Campaign Delete(Campaign entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Campaign> DeleteAsync(Campaign entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Campaign Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Campaign> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Campaign FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Campaign> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Campaign Activate(Campaign entity)
		{
			return repository.Activate(entity);
		}
		
		public Campaign Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Campaign Deactivate(Campaign entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Campaign Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Campaign> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Campaign> GetActive(Expression<Func<Campaign, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Campaign FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Campaign FirstOrDefault(Expression<Func<Campaign, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Campaign> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Campaign> FirstOrDefaultAsync(Expression<Func<Campaign, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
