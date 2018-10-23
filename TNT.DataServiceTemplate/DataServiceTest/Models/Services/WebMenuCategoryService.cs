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
	public partial interface IWebMenuCategoryService : IBaseService<WebMenuCategory, WebMenuCategoryViewModel, int>
	{
	}
	
	public partial class WebMenuCategoryService : BaseService, IWebMenuCategoryService
	{
		private IWebMenuCategoryRepository repository;
		
		public WebMenuCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebMenuCategoryRepository>(uow);
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
		public WebMenuCategory Add(WebMenuCategory entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<WebMenuCategory> AddAsync(WebMenuCategory entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public WebMenuCategory Update(WebMenuCategory entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<WebMenuCategory> UpdateAsync(WebMenuCategory entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public WebMenuCategory Delete(WebMenuCategory entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<WebMenuCategory> DeleteAsync(WebMenuCategory entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public WebMenuCategory Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<WebMenuCategory> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public WebMenuCategory FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<WebMenuCategory> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public WebMenuCategory Activate(WebMenuCategory entity)
		{
			return repository.Activate(entity);
		}
		
		public WebMenuCategory Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public WebMenuCategory Deactivate(WebMenuCategory entity)
		{
			return repository.Deactivate(entity);
		}
		
		public WebMenuCategory Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<WebMenuCategory> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<WebMenuCategory> GetActive(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public WebMenuCategory FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public WebMenuCategory FirstOrDefault(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<WebMenuCategory> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<WebMenuCategory> FirstOrDefaultAsync(Expression<Func<WebMenuCategory, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WebMenuCategoryService()
		{
			repository = G.TContainer.Resolve<IWebMenuCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebMenuCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
