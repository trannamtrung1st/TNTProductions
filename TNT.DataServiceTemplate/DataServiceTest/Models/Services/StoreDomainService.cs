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
	public partial interface IStoreDomainService : IBaseService<StoreDomain, StoreDomainViewModel, int>
	{
	}
	
	public partial class StoreDomainService : BaseService, IStoreDomainService
	{
		private IStoreDomainRepository repository;
		
		public StoreDomainService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IStoreDomainRepository>(uow);
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
		public StoreDomain Add(StoreDomain entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<StoreDomain> AddAsync(StoreDomain entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public StoreDomain Update(StoreDomain entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<StoreDomain> UpdateAsync(StoreDomain entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public StoreDomain Delete(StoreDomain entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<StoreDomain> DeleteAsync(StoreDomain entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public StoreDomain Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<StoreDomain> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public StoreDomain FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<StoreDomain> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public StoreDomain Activate(StoreDomain entity)
		{
			return repository.Activate(entity);
		}
		
		public StoreDomain Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public StoreDomain Deactivate(StoreDomain entity)
		{
			return repository.Deactivate(entity);
		}
		
		public StoreDomain Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<StoreDomain> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<StoreDomain> GetActive(Expression<Func<StoreDomain, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public StoreDomain FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public StoreDomain FirstOrDefault(Expression<Func<StoreDomain, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<StoreDomain> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<StoreDomain> FirstOrDefaultAsync(Expression<Func<StoreDomain, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public StoreDomainService()
		{
			repository = G.TContainer.Resolve<IStoreDomainRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~StoreDomainService()
		{
			Dispose(false);
		}
		#endregion
	}
}
