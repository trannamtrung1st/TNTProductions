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
	public partial interface IProductItemService : IBaseService<ProductItem, ProductItemViewModel, int>
	{
	}
	
	public partial class ProductItemService : BaseService, IProductItemService
	{
		private IProductItemRepository repository;
		
		public ProductItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductItemRepository>(uow);
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
		public ProductItem Add(ProductItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductItem> AddAsync(ProductItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductItem Update(ProductItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductItem> UpdateAsync(ProductItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductItem Delete(ProductItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductItem> DeleteAsync(ProductItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductItem Activate(ProductItem entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductItem Deactivate(ProductItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductItem> GetActive(Expression<Func<ProductItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductItem FirstOrDefault(Expression<Func<ProductItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductItem> FirstOrDefaultAsync(Expression<Func<ProductItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductItemService()
		{
			repository = G.TContainer.Resolve<IProductItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
