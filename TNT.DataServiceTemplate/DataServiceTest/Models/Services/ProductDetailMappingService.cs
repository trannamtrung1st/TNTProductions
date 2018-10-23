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
	public partial interface IProductDetailMappingService : IBaseService<ProductDetailMapping, ProductDetailMappingViewModel, int>
	{
	}
	
	public partial class ProductDetailMappingService : BaseService, IProductDetailMappingService
	{
		private IProductDetailMappingRepository repository;
		
		public ProductDetailMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductDetailMappingRepository>(uow);
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
		public ProductDetailMapping Add(ProductDetailMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductDetailMapping> AddAsync(ProductDetailMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductDetailMapping Update(ProductDetailMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductDetailMapping> UpdateAsync(ProductDetailMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductDetailMapping Delete(ProductDetailMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductDetailMapping> DeleteAsync(ProductDetailMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductDetailMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductDetailMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductDetailMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductDetailMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductDetailMapping Activate(ProductDetailMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductDetailMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductDetailMapping Deactivate(ProductDetailMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductDetailMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductDetailMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductDetailMapping> GetActive(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductDetailMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductDetailMapping FirstOrDefault(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductDetailMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductDetailMapping> FirstOrDefaultAsync(Expression<Func<ProductDetailMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductDetailMappingService()
		{
			repository = G.TContainer.Resolve<IProductDetailMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductDetailMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
