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
	public partial interface IProductItemCategoryService : IBaseService<ProductItemCategory, ProductItemCategoryViewModel, int>
	{
	}
	
	public partial class ProductItemCategoryService : BaseService, IProductItemCategoryService
	{
		private IProductItemCategoryRepository repository;
		
		public ProductItemCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemCategoryRepository>(uow);
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
		public ProductItemCategory Add(ProductItemCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductItemCategory> AddAsync(ProductItemCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductItemCategory Update(ProductItemCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductItemCategory> UpdateAsync(ProductItemCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductItemCategory Delete(ProductItemCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductItemCategory> DeleteAsync(ProductItemCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductItemCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductItemCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductItemCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductItemCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductItemCategory Activate(ProductItemCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductItemCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductItemCategory Deactivate(ProductItemCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductItemCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductItemCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductItemCategory> GetActive(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductItemCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductItemCategory FirstOrDefault(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductItemCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductItemCategory> FirstOrDefaultAsync(Expression<Func<ProductItemCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductItemCategoryService()
		{
			repository = G.TContainer.Resolve<IProductItemCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductItemCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
