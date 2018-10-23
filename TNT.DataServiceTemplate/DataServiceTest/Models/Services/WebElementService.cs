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
	public partial interface IWebElementService : IBaseService<WebElement, WebElementViewModel, int>
	{
	}
	
	public partial class WebElementService : BaseService, IWebElementService
	{
		private IWebElementRepository repository;
		
		public WebElementService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebElementRepository>(uow);
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
		public WebElement Add(WebElement entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<WebElement> AddAsync(WebElement entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public WebElement Update(WebElement entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<WebElement> UpdateAsync(WebElement entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public WebElement Delete(WebElement entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<WebElement> DeleteAsync(WebElement entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public WebElement Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<WebElement> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public WebElement FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<WebElement> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public WebElement Activate(WebElement entity)
		{
			return repository.Activate(entity);
		}
		
		public WebElement Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public WebElement Deactivate(WebElement entity)
		{
			return repository.Deactivate(entity);
		}
		
		public WebElement Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<WebElement> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<WebElement> GetActive(Expression<Func<WebElement, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public WebElement FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public WebElement FirstOrDefault(Expression<Func<WebElement, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<WebElement> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<WebElement> FirstOrDefaultAsync(Expression<Func<WebElement, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WebElementService()
		{
			repository = G.TContainer.Resolve<IWebElementRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebElementService()
		{
			Dispose(false);
		}
		#endregion
	}
}
