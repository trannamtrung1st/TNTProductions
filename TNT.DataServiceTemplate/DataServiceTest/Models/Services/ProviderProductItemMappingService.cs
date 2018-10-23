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
	public partial interface IProviderProductItemMappingService : IBaseService<ProviderProductItemMapping, ProviderProductItemMappingViewModel, int>
	{
	}
	
	public partial class ProviderProductItemMappingService : BaseService, IProviderProductItemMappingService
	{
		private IProviderProductItemMappingRepository repository;
		
		public ProviderProductItemMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProviderProductItemMappingRepository>(uow);
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
		public ProviderProductItemMapping Add(ProviderProductItemMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<ProviderProductItemMapping> AddAsync(ProviderProductItemMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public ProviderProductItemMapping Update(ProviderProductItemMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<ProviderProductItemMapping> UpdateAsync(ProviderProductItemMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public ProviderProductItemMapping Delete(ProviderProductItemMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<ProviderProductItemMapping> DeleteAsync(ProviderProductItemMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public ProviderProductItemMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<ProviderProductItemMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public ProviderProductItemMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<ProviderProductItemMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public ProviderProductItemMapping Activate(ProviderProductItemMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public ProviderProductItemMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public ProviderProductItemMapping Deactivate(ProviderProductItemMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public ProviderProductItemMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<ProviderProductItemMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<ProviderProductItemMapping> GetActive(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public ProviderProductItemMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public ProviderProductItemMapping FirstOrDefault(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<ProviderProductItemMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<ProviderProductItemMapping> FirstOrDefaultAsync(Expression<Func<ProviderProductItemMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public ProviderProductItemMappingService()
		{
			repository = G.TContainer.Resolve<IProviderProductItemMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProviderProductItemMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
