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
	public partial interface IProductImageCollectionService : IBaseService<ProductImageCollection, ProductImageCollectionViewModel, int>
	{
	}
	
	public partial class ProductImageCollectionService : BaseService, IProductImageCollectionService
	{
		private IProductImageCollectionRepository repository;
		
		public ProductImageCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageCollectionRepository>(uow);
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
		public ProductImageCollection Add(ProductImageCollection entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductImageCollection> AddAsync(ProductImageCollection entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductImageCollection Update(ProductImageCollection entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductImageCollection> UpdateAsync(ProductImageCollection entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductImageCollection Delete(ProductImageCollection entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductImageCollection> DeleteAsync(ProductImageCollection entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductImageCollection Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductImageCollection> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductImageCollection FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductImageCollection> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductImageCollection Activate(ProductImageCollection entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductImageCollection Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductImageCollection Deactivate(ProductImageCollection entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductImageCollection Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductImageCollection> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductImageCollection> GetActive(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductImageCollection FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductImageCollection FirstOrDefault(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductImageCollection> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductImageCollection> FirstOrDefaultAsync(Expression<Func<ProductImageCollection, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductImageCollectionService()
		{
			repository = G.TContainer.Resolve<IProductImageCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductImageCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
