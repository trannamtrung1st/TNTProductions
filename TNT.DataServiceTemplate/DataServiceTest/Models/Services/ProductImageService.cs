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
	public partial interface IProductImageService : IBaseService<ProductImage, ProductImageViewModel, int>
	{
	}
	
	public partial class ProductImageService : BaseService, IProductImageService
	{
		private IProductImageRepository repository;
		
		public ProductImageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductImageRepository>(uow);
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
		public ProductImage Add(ProductImage entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductImage> AddAsync(ProductImage entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductImage Update(ProductImage entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductImage> UpdateAsync(ProductImage entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductImage Delete(ProductImage entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductImage> DeleteAsync(ProductImage entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductImage Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductImage> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductImage FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductImage> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductImage Activate(ProductImage entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductImage Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductImage Deactivate(ProductImage entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductImage Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductImage> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductImage> GetActive(Expression<Func<ProductImage, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductImage FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductImage FirstOrDefault(Expression<Func<ProductImage, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductImage> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductImage> FirstOrDefaultAsync(Expression<Func<ProductImage, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductImageService()
		{
			repository = G.TContainer.Resolve<IProductImageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductImageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
