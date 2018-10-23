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
	public partial interface IInventoryReceiptItemService : IBaseService<InventoryReceiptItem, InventoryReceiptItemViewModel, InventoryReceiptItemPK>
	{
	}
	
	public partial class InventoryReceiptItemService : BaseService, IInventoryReceiptItemService
	{
		private IInventoryReceiptItemRepository repository;
		
		public InventoryReceiptItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryReceiptItemRepository>(uow);
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
		public InventoryReceiptItem Add(InventoryReceiptItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryReceiptItem> AddAsync(InventoryReceiptItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryReceiptItem Update(InventoryReceiptItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryReceiptItem> UpdateAsync(InventoryReceiptItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryReceiptItem Delete(InventoryReceiptItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryReceiptItem> DeleteAsync(InventoryReceiptItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryReceiptItem Delete(InventoryReceiptItemPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryReceiptItem> DeleteAsync(InventoryReceiptItemPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryReceiptItem FindById(InventoryReceiptItemPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryReceiptItem> FindByIdAsync(InventoryReceiptItemPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryReceiptItem Activate(InventoryReceiptItem entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryReceiptItem Activate(InventoryReceiptItemPK key)
		{
			return repository.Activate(key);
		}
		
		public InventoryReceiptItem Deactivate(InventoryReceiptItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryReceiptItem Deactivate(InventoryReceiptItemPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryReceiptItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryReceiptItem> GetActive(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryReceiptItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryReceiptItem FirstOrDefault(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryReceiptItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryReceiptItem> FirstOrDefaultAsync(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryReceiptItemService()
		{
			repository = G.TContainer.Resolve<IInventoryReceiptItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryReceiptItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
