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
	public partial interface IProductImageCollectionItemMappingService : IBaseService<ProductImageCollectionItemMapping, ProductImageCollectionItemMappingViewModel, int>
	{
	}
	
	public partial class ProductImageCollectionItemMappingService : BaseService, IProductImageCollectionItemMappingService
	{
		private IProductImageCollectionItemMappingRepository repository;
		
		public ProductImageCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageCollectionItemMappingRepository>(uow);
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
		public ProductImageCollectionItemMapping Add(ProductImageCollectionItemMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductImageCollectionItemMapping> AddAsync(ProductImageCollectionItemMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductImageCollectionItemMapping Update(ProductImageCollectionItemMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductImageCollectionItemMapping> UpdateAsync(ProductImageCollectionItemMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductImageCollectionItemMapping Delete(ProductImageCollectionItemMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductImageCollectionItemMapping> DeleteAsync(ProductImageCollectionItemMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductImageCollectionItemMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductImageCollectionItemMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductImageCollectionItemMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductImageCollectionItemMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductImageCollectionItemMapping Activate(ProductImageCollectionItemMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductImageCollectionItemMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductImageCollectionItemMapping Deactivate(ProductImageCollectionItemMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductImageCollectionItemMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductImageCollectionItemMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductImageCollectionItemMapping> GetActive(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductImageCollectionItemMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductImageCollectionItemMapping FirstOrDefault(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductImageCollectionItemMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductImageCollectionItemMapping> FirstOrDefaultAsync(Expression<Func<ProductImageCollectionItemMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductImageCollectionItemMappingService()
		{
			repository = G.TContainer.Resolve<IProductImageCollectionItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductImageCollectionItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
