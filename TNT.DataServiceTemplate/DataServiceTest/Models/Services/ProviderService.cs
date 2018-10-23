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
	public partial interface IProviderService : IBaseService<Provider, ProviderViewModel, int>
	{
	}
	
	public partial class ProviderService : BaseService, IProviderService
	{
		private IProviderRepository repository;
		
		public ProviderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProviderRepository>(uow);
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
		public Provider Add(Provider entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Provider> AddAsync(Provider entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Provider Update(Provider entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Provider> UpdateAsync(Provider entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Provider Delete(Provider entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Provider> DeleteAsync(Provider entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Provider Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Provider> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Provider FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Provider> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Provider Activate(Provider entity)
		{
			return repository.Activate(entity);
		}
		
		public Provider Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Provider Deactivate(Provider entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Provider Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Provider> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Provider> GetActive(Expression<Func<Provider, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Provider FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Provider FirstOrDefault(Expression<Func<Provider, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Provider> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Provider> FirstOrDefaultAsync(Expression<Func<Provider, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProviderService()
		{
			repository = G.TContainer.Resolve<IProviderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProviderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
