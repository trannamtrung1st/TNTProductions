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
	public partial interface IProductSpecificationService : IBaseService<ProductSpecification, ProductSpecificationViewModel, int>
	{
	}
	
	public partial class ProductSpecificationService : BaseService, IProductSpecificationService
	{
		private IProductSpecificationRepository repository;
		
		public ProductSpecificationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductSpecificationRepository>(uow);
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
		public ProductSpecification Add(ProductSpecification entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductSpecification> AddAsync(ProductSpecification entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductSpecification Update(ProductSpecification entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductSpecification> UpdateAsync(ProductSpecification entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductSpecification Delete(ProductSpecification entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductSpecification> DeleteAsync(ProductSpecification entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductSpecification Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductSpecification> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductSpecification FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductSpecification> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductSpecification Activate(ProductSpecification entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductSpecification Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProductSpecification Deactivate(ProductSpecification entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductSpecification Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductSpecification> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductSpecification> GetActive(Expression<Func<ProductSpecification, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductSpecification FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductSpecification FirstOrDefault(Expression<Func<ProductSpecification, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductSpecification> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductSpecification> FirstOrDefaultAsync(Expression<Func<ProductSpecification, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductSpecificationService()
		{
			repository = G.TContainer.Resolve<IProductSpecificationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductSpecificationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
