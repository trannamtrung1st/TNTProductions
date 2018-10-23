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
	public partial interface IWebMenuService : IBaseService<WebMenu, WebMenuViewModel, int>
	{
	}
	
	public partial class WebMenuService : BaseService, IWebMenuService
	{
		private IWebMenuRepository repository;
		
		public WebMenuService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebMenuRepository>(uow);
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
		public WebMenu Add(WebMenu entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<WebMenu> AddAsync(WebMenu entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public WebMenu Update(WebMenu entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<WebMenu> UpdateAsync(WebMenu entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public WebMenu Delete(WebMenu entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<WebMenu> DeleteAsync(WebMenu entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public WebMenu Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<WebMenu> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public WebMenu FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<WebMenu> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public WebMenu Activate(WebMenu entity)
		{
			return repository.Activate(entity);
		}
		
		public WebMenu Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public WebMenu Deactivate(WebMenu entity)
		{
			return repository.Deactivate(entity);
		}
		
		public WebMenu Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<WebMenu> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<WebMenu> GetActive(Expression<Func<WebMenu, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public WebMenu FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public WebMenu FirstOrDefault(Expression<Func<WebMenu, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<WebMenu> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<WebMenu> FirstOrDefaultAsync(Expression<Func<WebMenu, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WebMenuService()
		{
			repository = G.TContainer.Resolve<IWebMenuRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebMenuService()
		{
			Dispose(false);
		}
		#endregion
	}
}
