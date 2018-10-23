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
	public partial interface IInventoryDateReportItemService : IBaseService<InventoryDateReportItem, InventoryDateReportItemViewModel, InventoryDateReportItemPK>
	{
	}
	
	public partial class InventoryDateReportItemService : BaseService, IInventoryDateReportItemService
	{
		private IInventoryDateReportItemRepository repository;
		
		public InventoryDateReportItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IInventoryDateReportItemRepository>(uow);
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
		public InventoryDateReportItem Add(InventoryDateReportItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<InventoryDateReportItem> AddAsync(InventoryDateReportItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public InventoryDateReportItem Update(InventoryDateReportItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<InventoryDateReportItem> UpdateAsync(InventoryDateReportItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public InventoryDateReportItem Delete(InventoryDateReportItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<InventoryDateReportItem> DeleteAsync(InventoryDateReportItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public InventoryDateReportItem Delete(InventoryDateReportItemPK key)
		{
			return repository.Delete(key);
		}
		
		public async Task<InventoryDateReportItem> DeleteAsync(InventoryDateReportItemPK key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public InventoryDateReportItem FindById(InventoryDateReportItemPK key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<InventoryDateReportItem> FindByIdAsync(InventoryDateReportItemPK key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public InventoryDateReportItem Activate(InventoryDateReportItem entity)
		{
			return repository.Activate(entity);
		}
		
		public InventoryDateReportItem Activate(InventoryDateReportItemPK key)
		{
			return repository.Activate(key);
		}
		
		public InventoryDateReportItem Deactivate(InventoryDateReportItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public InventoryDateReportItem Deactivate(InventoryDateReportItemPK key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<InventoryDateReportItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<InventoryDateReportItem> GetActive(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public InventoryDateReportItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public InventoryDateReportItem FirstOrDefault(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<InventoryDateReportItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<InventoryDateReportItem> FirstOrDefaultAsync(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public InventoryDateReportItemService()
		{
			repository = G.TContainer.Resolve<IInventoryDateReportItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~InventoryDateReportItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
