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
	public partial interface IInventoryReceiptService : IBaseService<InventoryReceipt, InventoryReceiptViewModel, int>
	{
	}
	
	public partial class InventoryReceiptService : BaseService, IInventoryReceiptService
	{
		private IInventoryReceiptRepository repository;
		
		public InventoryReceiptService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryReceiptRepository>(uow);
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
		public InventoryReceipt Add(InventoryReceipt entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryReceipt> AddAsync(InventoryReceipt entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryReceipt Update(InventoryReceipt entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryReceipt> UpdateAsync(InventoryReceipt entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryReceipt Delete(InventoryReceipt entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryReceipt> DeleteAsync(InventoryReceipt entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryReceipt Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryReceipt> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryReceipt FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryReceipt> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryReceipt Activate(InventoryReceipt entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryReceipt Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public InventoryReceipt Deactivate(InventoryReceipt entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryReceipt Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryReceipt> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryReceipt> GetActive(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryReceipt FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryReceipt FirstOrDefault(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryReceipt> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryReceipt> FirstOrDefaultAsync(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryReceiptService()
		{
			repository = G.TContainer.Resolve<IInventoryReceiptRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryReceiptService()
		{
			Dispose(false);
		}
		#endregion
	}
}
