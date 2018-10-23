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
	public partial interface IProductService : IBaseService<Product, ProductViewModel, int>
	{
	}
	
	public partial class ProductService : BaseService, IProductService
	{
		private IProductRepository repository;
		
		public ProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductRepository>(uow);
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
		public Product Add(Product entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Product> AddAsync(Product entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Product Update(Product entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Product> UpdateAsync(Product entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Product Delete(Product entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Product> DeleteAsync(Product entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Product Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Product> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Product FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Product> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Product Activate(Product entity)
		{
			return repository.Activate(entity);
		}
		
		public Product Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Product Deactivate(Product entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Product Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Product> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Product> GetActive(Expression<Func<Product, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Product FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Product FirstOrDefault(Expression<Func<Product, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Product> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductService()
		{
			repository = G.TContainer.Resolve<IProductRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductService()
		{
			Dispose(false);
		}
		#endregion
	}
}
