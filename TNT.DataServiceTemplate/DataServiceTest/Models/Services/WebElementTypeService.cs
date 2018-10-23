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
	public partial interface IWebElementTypeService : IBaseService<WebElementType, WebElementTypeViewModel, int>
	{
	}
	
	public partial class WebElementTypeService : BaseService, IWebElementTypeService
	{
		private IWebElementTypeRepository repository;
		
		public WebElementTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebElementTypeRepository>(uow);
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
		public WebElementType Add(WebElementType entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<WebElementType> AddAsync(WebElementType entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public WebElementType Update(WebElementType entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<WebElementType> UpdateAsync(WebElementType entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public WebElementType Delete(WebElementType entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<WebElementType> DeleteAsync(WebElementType entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public WebElementType Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<WebElementType> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public WebElementType FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<WebElementType> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public WebElementType Activate(WebElementType entity)
		{
			return repository.Activate(entity);
		}
		
		public WebElementType Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public WebElementType Deactivate(WebElementType entity)
		{
			return repository.Deactivate(entity);
		}
		
		public WebElementType Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<WebElementType> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<WebElementType> GetActive(Expression<Func<WebElementType, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public WebElementType FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public WebElementType FirstOrDefault(Expression<Func<WebElementType, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<WebElementType> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<WebElementType> FirstOrDefaultAsync(Expression<Func<WebElementType, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public WebElementTypeService()
		{
			repository = G.TContainer.Resolve<IWebElementTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~WebElementTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
