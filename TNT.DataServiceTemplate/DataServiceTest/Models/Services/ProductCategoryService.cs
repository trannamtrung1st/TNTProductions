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
	public partial interface IProductCategoryService : IBaseService<ProductCategory, ProductCategoryViewModel, int>
	{
	}
	
	public partial class ProductCategoryService : BaseService, IProductCategoryService
	{
		private IProductCategoryRepository repository;
		
		public ProductCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCategoryRepository>(uow);
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
		public ProductCategory Add(ProductCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductCategory> AddAsync(ProductCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductCategory Update(ProductCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductCategory> UpdateAsync(ProductCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductCategory Delete(ProductCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductCategory> DeleteAsync(ProductCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductCategory Activate(ProductCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductCategory Deactivate(ProductCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductCategory> GetActive(Expression<Func<ProductCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductCategory FirstOrDefault(Expression<Func<ProductCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductCategory> FirstOrDefaultAsync(Expression<Func<ProductCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductCategoryService()
		{
			repository = G.TContainer.Resolve<IProductCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
