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
	public partial interface IOrderFeeItemService : IBaseService<OrderFeeItem, OrderFeeItemViewModel, int>
	{
	}
	
	public partial class OrderFeeItemService : BaseService, IOrderFeeItemService
	{
		private IOrderFeeItemRepository repository;
		
		public OrderFeeItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderFeeItemRepository>(uow);
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
		public OrderFeeItem Add(OrderFeeItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<OrderFeeItem> AddAsync(OrderFeeItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public OrderFeeItem Update(OrderFeeItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<OrderFeeItem> UpdateAsync(OrderFeeItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public OrderFeeItem Delete(OrderFeeItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<OrderFeeItem> DeleteAsync(OrderFeeItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public OrderFeeItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<OrderFeeItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public OrderFeeItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<OrderFeeItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public OrderFeeItem Activate(OrderFeeItem entity)
		{
			return repository.Activate(entity);
		}
		
		public OrderFeeItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public OrderFeeItem Deactivate(OrderFeeItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public OrderFeeItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<OrderFeeItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<OrderFeeItem> GetActive(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public OrderFeeItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public OrderFeeItem FirstOrDefault(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<OrderFeeItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<OrderFeeItem> FirstOrDefaultAsync(Expression<Func<OrderFeeItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public OrderFeeItemService()
		{
			repository = G.TContainer.Resolve<IOrderFeeItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderFeeItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
