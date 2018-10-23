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
	public partial interface IStoreThemeService : IBaseService<StoreTheme, StoreThemeViewModel, int>
	{
	}
	
	public partial class StoreThemeService : BaseService, IStoreThemeService
	{
		private IStoreThemeRepository repository;
		
		public StoreThemeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreThemeRepository>(uow);
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
		public StoreTheme Add(StoreTheme entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreTheme> AddAsync(StoreTheme entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreTheme Update(StoreTheme entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreTheme> UpdateAsync(StoreTheme entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreTheme Delete(StoreTheme entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreTheme> DeleteAsync(StoreTheme entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreTheme Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreTheme> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreTheme FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreTheme> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreTheme Activate(StoreTheme entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreTheme Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreTheme Deactivate(StoreTheme entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreTheme Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreTheme> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreTheme> GetActive(Expression<Func<StoreTheme, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreTheme FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreTheme FirstOrDefault(Expression<Func<StoreTheme, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreTheme> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreTheme> FirstOrDefaultAsync(Expression<Func<StoreTheme, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreThemeService()
		{
			repository = G.TContainer.Resolve<IStoreThemeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreThemeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
