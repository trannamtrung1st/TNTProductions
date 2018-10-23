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
	public partial interface IWebPageService : IBaseService<WebPage, WebPageViewModel, int>
	{
	}
	
	public partial class WebPageService : BaseService, IWebPageService
	{
		private IWebPageRepository repository;
		
		public WebPageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebPageRepository>(uow);
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
		public WebPage Add(WebPage entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<WebPage> AddAsync(WebPage entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public WebPage Update(WebPage entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<WebPage> UpdateAsync(WebPage entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public WebPage Delete(WebPage entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<WebPage> DeleteAsync(WebPage entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public WebPage Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<WebPage> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public WebPage FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<WebPage> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public WebPage Activate(WebPage entity)
		{
			return repository.Activate(entity);
		}
		
		public WebPage Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public WebPage Deactivate(WebPage entity)
		{
			return repository.Deactivate(entity);
		}
		
		public WebPage Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<WebPage> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<WebPage> GetActive(Expression<Func<WebPage, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public WebPage FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public WebPage FirstOrDefault(Expression<Func<WebPage, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<WebPage> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<WebPage> FirstOrDefaultAsync(Expression<Func<WebPage, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WebPageService()
		{
			repository = G.TContainer.Resolve<IWebPageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebPageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
