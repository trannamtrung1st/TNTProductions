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
	public partial interface IProductItemCompositionMappingService : IBaseService<ProductItemCompositionMapping, ProductItemCompositionMappingViewModel, ProductItemCompositionMappingPK>
	{
	}
	
	public partial class ProductItemCompositionMappingService : BaseService, IProductItemCompositionMappingService
	{
		private IProductItemCompositionMappingRepository repository;
		
		public ProductItemCompositionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemCompositionMappingRepository>(uow);
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
		public ProductItemCompositionMapping Add(ProductItemCompositionMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductItemCompositionMapping> AddAsync(ProductItemCompositionMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductItemCompositionMapping Update(ProductItemCompositionMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductItemCompositionMapping> UpdateAsync(ProductItemCompositionMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductItemCompositionMapping Delete(ProductItemCompositionMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductItemCompositionMapping> DeleteAsync(ProductItemCompositionMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductItemCompositionMapping Delete(ProductItemCompositionMappingPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductItemCompositionMapping> DeleteAsync(ProductItemCompositionMappingPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductItemCompositionMapping FindById(ProductItemCompositionMappingPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductItemCompositionMapping> FindByIdAsync(ProductItemCompositionMappingPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductItemCompositionMapping Activate(ProductItemCompositionMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductItemCompositionMapping Activate(ProductItemCompositionMappingPK key)
		{
			return repository.Activate(key);
		}
		
		public ProductItemCompositionMapping Deactivate(ProductItemCompositionMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductItemCompositionMapping Deactivate(ProductItemCompositionMappingPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductItemCompositionMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductItemCompositionMapping> GetActive(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductItemCompositionMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductItemCompositionMapping FirstOrDefault(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductItemCompositionMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductItemCompositionMapping> FirstOrDefaultAsync(Expression<Func<ProductItemCompositionMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductItemCompositionMappingService()
		{
			repository = G.TContainer.Resolve<IProductItemCompositionMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductItemCompositionMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
