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
	public partial interface IInventoryCheckingService : IBaseService<InventoryChecking, InventoryCheckingViewModel, int>
	{
	}
	
	public partial class InventoryCheckingService : BaseService, IInventoryCheckingService
	{
		private IInventoryCheckingRepository repository;
		
		public InventoryCheckingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryCheckingRepository>(uow);
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
		public InventoryChecking Add(InventoryChecking entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryChecking> AddAsync(InventoryChecking entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryChecking Update(InventoryChecking entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryChecking> UpdateAsync(InventoryChecking entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryChecking Delete(InventoryChecking entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryChecking> DeleteAsync(InventoryChecking entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryChecking Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryChecking> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryChecking FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryChecking> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryChecking Activate(InventoryChecking entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryChecking Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public InventoryChecking Deactivate(InventoryChecking entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryChecking Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryChecking> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryChecking> GetActive(Expression<Func<InventoryChecking, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryChecking FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryChecking FirstOrDefault(Expression<Func<InventoryChecking, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryChecking> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryChecking> FirstOrDefaultAsync(Expression<Func<InventoryChecking, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryCheckingService()
		{
			repository = G.TContainer.Resolve<IInventoryCheckingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryCheckingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
