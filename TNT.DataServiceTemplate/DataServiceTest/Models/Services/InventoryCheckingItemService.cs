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
	public partial interface IInventoryCheckingItemService : IBaseService<InventoryCheckingItem, InventoryCheckingItemViewModel, int>
	{
	}
	
	public partial class InventoryCheckingItemService : BaseService, IInventoryCheckingItemService
	{
		private IInventoryCheckingItemRepository repository;
		
		public InventoryCheckingItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryCheckingItemRepository>(uow);
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
		public InventoryCheckingItem Add(InventoryCheckingItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryCheckingItem> AddAsync(InventoryCheckingItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryCheckingItem Update(InventoryCheckingItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryCheckingItem> UpdateAsync(InventoryCheckingItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryCheckingItem Delete(InventoryCheckingItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryCheckingItem> DeleteAsync(InventoryCheckingItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryCheckingItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryCheckingItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryCheckingItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryCheckingItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryCheckingItem Activate(InventoryCheckingItem entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryCheckingItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public InventoryCheckingItem Deactivate(InventoryCheckingItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryCheckingItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryCheckingItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryCheckingItem> GetActive(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryCheckingItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryCheckingItem FirstOrDefault(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryCheckingItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryCheckingItem> FirstOrDefaultAsync(Expression<Func<InventoryCheckingItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryCheckingItemService()
		{
			repository = G.TContainer.Resolve<IInventoryCheckingItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryCheckingItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
