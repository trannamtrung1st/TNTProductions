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
	public partial interface ICouponProviderService : IBaseService<CouponProvider, CouponProviderViewModel, int>
	{
	}
	
	public partial class CouponProviderService : BaseService, ICouponProviderService
	{
		private ICouponProviderRepository repository;
		
		public CouponProviderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICouponProviderRepository>(uow);
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
		public CouponProvider Add(CouponProvider entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CouponProvider> AddAsync(CouponProvider entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CouponProvider Update(CouponProvider entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CouponProvider> UpdateAsync(CouponProvider entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CouponProvider Delete(CouponProvider entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CouponProvider> DeleteAsync(CouponProvider entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CouponProvider Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CouponProvider> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CouponProvider FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CouponProvider> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CouponProvider Activate(CouponProvider entity)
		{
			return repository.Activate(entity);
		}
		
		public CouponProvider Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CouponProvider Deactivate(CouponProvider entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CouponProvider Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CouponProvider> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CouponProvider> GetActive(Expression<Func<CouponProvider, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CouponProvider FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CouponProvider FirstOrDefault(Expression<Func<CouponProvider, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CouponProvider> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CouponProvider> FirstOrDefaultAsync(Expression<Func<CouponProvider, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CouponProviderService()
		{
			repository = G.TContainer.Resolve<ICouponProviderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CouponProviderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
