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
	public partial interface ICategoryExtraService : IBaseService<CategoryExtra, CategoryExtraViewModel, int>
	{
	}
	
	public partial class CategoryExtraService : BaseService, ICategoryExtraService
	{
		private ICategoryExtraRepository repository;
		
		public CategoryExtraService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICategoryExtraRepository>(uow);
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
		public CategoryExtra Add(CategoryExtra entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<CategoryExtra> AddAsync(CategoryExtra entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public CategoryExtra Update(CategoryExtra entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<CategoryExtra> UpdateAsync(CategoryExtra entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public CategoryExtra Delete(CategoryExtra entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<CategoryExtra> DeleteAsync(CategoryExtra entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public CategoryExtra Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<CategoryExtra> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public CategoryExtra FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<CategoryExtra> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public CategoryExtra Activate(CategoryExtra entity)
		{
			return repository.Activate(entity);
		}
		
		public CategoryExtra Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public CategoryExtra Deactivate(CategoryExtra entity)
		{
			return repository.Deactivate(entity);
		}
		
		public CategoryExtra Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<CategoryExtra> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<CategoryExtra> GetActive(Expression<Func<CategoryExtra, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public CategoryExtra FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public CategoryExtra FirstOrDefault(Expression<Func<CategoryExtra, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<CategoryExtra> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<CategoryExtra> FirstOrDefaultAsync(Expression<Func<CategoryExtra, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public CategoryExtraService()
		{
			repository = G.TContainer.Resolve<ICategoryExtraRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CategoryExtraService()
		{
			Dispose(false);
		}
		#endregion
	}
}
