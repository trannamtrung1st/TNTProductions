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
	public partial interface ICategoryExtraMappingService : IBaseService<CategoryExtraMapping, CategoryExtraMappingViewModel, int>
	{
	}
	
	public partial class CategoryExtraMappingService : BaseService, ICategoryExtraMappingService
	{
		private ICategoryExtraMappingRepository repository;
		
		public CategoryExtraMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICategoryExtraMappingRepository>(uow);
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
		public CategoryExtraMapping Add(CategoryExtraMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CategoryExtraMapping> AddAsync(CategoryExtraMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CategoryExtraMapping Update(CategoryExtraMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CategoryExtraMapping> UpdateAsync(CategoryExtraMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CategoryExtraMapping Delete(CategoryExtraMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CategoryExtraMapping> DeleteAsync(CategoryExtraMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CategoryExtraMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CategoryExtraMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CategoryExtraMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CategoryExtraMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CategoryExtraMapping Activate(CategoryExtraMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public CategoryExtraMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CategoryExtraMapping Deactivate(CategoryExtraMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CategoryExtraMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CategoryExtraMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CategoryExtraMapping> GetActive(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CategoryExtraMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CategoryExtraMapping FirstOrDefault(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CategoryExtraMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CategoryExtraMapping> FirstOrDefaultAsync(Expression<Func<CategoryExtraMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CategoryExtraMappingService()
		{
			repository = G.TContainer.Resolve<ICategoryExtraMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CategoryExtraMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
