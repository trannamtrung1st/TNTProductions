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
	public partial interface ICouponCampaignService : IBaseService<CouponCampaign, CouponCampaignViewModel, int>
	{
	}
	
	public partial class CouponCampaignService : BaseService, ICouponCampaignService
	{
		private ICouponCampaignRepository repository;
		
		public CouponCampaignService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponCampaignRepository>(uow);
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
		public CouponCampaign Add(CouponCampaign entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CouponCampaign> AddAsync(CouponCampaign entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CouponCampaign Update(CouponCampaign entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CouponCampaign> UpdateAsync(CouponCampaign entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CouponCampaign Delete(CouponCampaign entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CouponCampaign> DeleteAsync(CouponCampaign entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CouponCampaign Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CouponCampaign> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CouponCampaign FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CouponCampaign> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CouponCampaign Activate(CouponCampaign entity)
		{
			return repository.Activate(entity);
		}
		
		public CouponCampaign Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CouponCampaign Deactivate(CouponCampaign entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CouponCampaign Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CouponCampaign> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CouponCampaign> GetActive(Expression<Func<CouponCampaign, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CouponCampaign FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CouponCampaign FirstOrDefault(Expression<Func<CouponCampaign, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CouponCampaign> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CouponCampaign> FirstOrDefaultAsync(Expression<Func<CouponCampaign, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CouponCampaignService()
		{
			repository = G.TContainer.Resolve<ICouponCampaignRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CouponCampaignService()
		{
			Dispose(false);
		}
		#endregion
	}
}
