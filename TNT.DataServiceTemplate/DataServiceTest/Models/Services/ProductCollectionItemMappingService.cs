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
	public partial interface IProductCollectionItemMappingService : IBaseService<ProductCollectionItemMapping, ProductCollectionItemMappingViewModel, int>
	{
	}
	
	public partial class ProductCollectionItemMappingService : BaseService, IProductCollectionItemMappingService
	{
		private IProductCollectionItemMappingRepository repository;
		
		public ProductCollectionItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCollectionItemMappingRepository>(uow);
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
		public ProductCollectionItemMapping Add(ProductCollectionItemMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductCollectionItemMapping> AddAsync(ProductCollectionItemMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductCollectionItemMapping Update(ProductCollectionItemMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductCollectionItemMapping> UpdateAsync(ProductCollectionItemMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductCollectionItemMapping Delete(ProductCollectionItemMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductCollectionItemMapping> DeleteAsync(ProductCollectionItemMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductCollectionItemMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductCollectionItemMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductCollectionItemMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductCollectionItemMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductCollectionItemMapping Activate(ProductCollectionItemMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductCollectionItemMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductCollectionItemMapping Deactivate(ProductCollectionItemMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductCollectionItemMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductCollectionItemMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductCollectionItemMapping> GetActive(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductCollectionItemMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductCollectionItemMapping FirstOrDefault(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductCollectionItemMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductCollectionItemMapping> FirstOrDefaultAsync(Expression<Func<ProductCollectionItemMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductCollectionItemMappingService()
		{
			repository = G.TContainer.Resolve<IProductCollectionItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductCollectionItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
