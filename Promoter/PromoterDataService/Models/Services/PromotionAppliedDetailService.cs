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
	public partial interface IPromotionAppliedDetailService : IBaseService<PromotionAppliedDetail, PromotionAppliedDetailViewModel, int>
	{
	}
	
	public partial class PromotionAppliedDetailService : BaseService, IPromotionAppliedDetailService
	{
		private IPromotionAppliedDetailRepository repository;
		
		public PromotionAppliedDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionAppliedDetailRepository>(uow);
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
		public PromotionAppliedDetail Add(PromotionAppliedDetail entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PromotionAppliedDetail> AddAsync(PromotionAppliedDetail entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PromotionAppliedDetail Update(PromotionAppliedDetail entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PromotionAppliedDetail> UpdateAsync(PromotionAppliedDetail entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PromotionAppliedDetail Delete(PromotionAppliedDetail entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PromotionAppliedDetail> DeleteAsync(PromotionAppliedDetail entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PromotionAppliedDetail Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PromotionAppliedDetail> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PromotionAppliedDetail FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PromotionAppliedDetail> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PromotionAppliedDetail Activate(PromotionAppliedDetail entity)
		{
			return repository.Activate(entity);
		}
		
		public PromotionAppliedDetail Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PromotionAppliedDetail Deactivate(PromotionAppliedDetail entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PromotionAppliedDetail Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PromotionAppliedDetail> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PromotionAppliedDetail> GetActive(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PromotionAppliedDetail FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PromotionAppliedDetail FirstOrDefault(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PromotionAppliedDetail> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PromotionAppliedDetail> FirstOrDefaultAsync(Expression<Func<PromotionAppliedDetail, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
