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
	public partial interface IPromotionStoreMappingService : IBaseService<PromotionStoreMapping, PromotionStoreMappingViewModel, int>
	{
	}
	
	public partial class PromotionStoreMappingService : BaseService, IPromotionStoreMappingService
	{
		private IPromotionStoreMappingRepository repository;
		
		public PromotionStoreMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPromotionStoreMappingRepository>(uow);
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
		public PromotionStoreMapping Add(PromotionStoreMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<PromotionStoreMapping> AddAsync(PromotionStoreMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public PromotionStoreMapping Update(PromotionStoreMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<PromotionStoreMapping> UpdateAsync(PromotionStoreMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public PromotionStoreMapping Delete(PromotionStoreMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<PromotionStoreMapping> DeleteAsync(PromotionStoreMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public PromotionStoreMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<PromotionStoreMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public PromotionStoreMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<PromotionStoreMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public PromotionStoreMapping Activate(PromotionStoreMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public PromotionStoreMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public PromotionStoreMapping Deactivate(PromotionStoreMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public PromotionStoreMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<PromotionStoreMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<PromotionStoreMapping> GetActive(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public PromotionStoreMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public PromotionStoreMapping FirstOrDefault(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<PromotionStoreMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<PromotionStoreMapping> FirstOrDefaultAsync(Expression<Func<PromotionStoreMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public PromotionStoreMappingService()
		{
			repository = G.TContainer.Resolve<IPromotionStoreMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PromotionStoreMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
