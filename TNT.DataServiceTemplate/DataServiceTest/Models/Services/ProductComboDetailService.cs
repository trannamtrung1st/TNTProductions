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
	public partial interface IProductComboDetailService : IBaseService<ProductComboDetail, ProductComboDetailViewModel, ProductComboDetailPK>
	{
	}
	
	public partial class ProductComboDetailService : BaseService, IProductComboDetailService
	{
		private IProductComboDetailRepository repository;
		
		public ProductComboDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductComboDetailRepository>(uow);
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
		public ProductComboDetail Add(ProductComboDetail entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProductComboDetail> AddAsync(ProductComboDetail entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProductComboDetail Update(ProductComboDetail entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProductComboDetail> UpdateAsync(ProductComboDetail entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProductComboDetail Delete(ProductComboDetail entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProductComboDetail> DeleteAsync(ProductComboDetail entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProductComboDetail Delete(ProductComboDetailPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProductComboDetail> DeleteAsync(ProductComboDetailPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProductComboDetail FindById(ProductComboDetailPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProductComboDetail> FindByIdAsync(ProductComboDetailPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProductComboDetail Activate(ProductComboDetail entity)
		{
			return repository.Activate(entity);
		}
		
		public ProductComboDetail Activate(ProductComboDetailPK key)
		{
			return repository.Activate(key);
		}
		
		public ProductComboDetail Deactivate(ProductComboDetail entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProductComboDetail Deactivate(ProductComboDetailPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProductComboDetail> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProductComboDetail> GetActive(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProductComboDetail FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProductComboDetail FirstOrDefault(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProductComboDetail> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProductComboDetail> FirstOrDefaultAsync(Expression<Func<ProductComboDetail, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProductComboDetailService()
		{
			repository = G.TContainer.Resolve<IProductComboDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductComboDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
