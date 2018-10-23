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
	public partial interface IProductCollectionService : IBaseService<ProductCollection, ProductCollectionViewModel, int>
	{
	}
	
	public partial class ProductCollectionService : BaseService, IProductCollectionService
	{
		private IProductCollectionRepository repository;
		
		public ProductCollectionService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductCollectionRepository>(uow);
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
		public ProductCollection Add(ProductCollection entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductCollection> AddAsync(ProductCollection entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductCollection Update(ProductCollection entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductCollection> UpdateAsync(ProductCollection entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductCollection Delete(ProductCollection entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductCollection> DeleteAsync(ProductCollection entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductCollection Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductCollection> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductCollection FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductCollection> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductCollection Activate(ProductCollection entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductCollection Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductCollection Deactivate(ProductCollection entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductCollection Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductCollection> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductCollection> GetActive(Expression<Func<ProductCollection, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductCollection FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductCollection FirstOrDefault(Expression<Func<ProductCollection, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductCollection> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductCollection> FirstOrDefaultAsync(Expression<Func<ProductCollection, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductCollectionService()
		{
			repository = G.TContainer.Resolve<IProductCollectionRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductCollectionService()
		{
			Dispose(false);
		}
		#endregion
	}
}
