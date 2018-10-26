using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using PromoterDataService.Utilities;
using PromoterDataService.Managers;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Repositories;
using PromoterDataService.Global;
using TNT.IoContainer.Wrapper;

namespace PromoterDataService.Models.Services
{
	public partial interface IOrderItemService : IBaseService<OrderItem, OrderItemViewModel, int>
	{
	}
	
	public partial class OrderItemService : BaseService, IOrderItemService
	{
		private IOrderItemRepository repository;
		
		public OrderItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderItemRepository>(uow);
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
		public OrderItem Add(OrderItem entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<OrderItem> AddAsync(OrderItem entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public OrderItem Update(OrderItem entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<OrderItem> UpdateAsync(OrderItem entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public OrderItem Delete(OrderItem entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<OrderItem> DeleteAsync(OrderItem entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public OrderItem Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<OrderItem> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public OrderItem FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<OrderItem> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public OrderItem Activate(OrderItem entity)
		{
			return repository.Activate(entity);
		}
		
		public OrderItem Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public OrderItem Deactivate(OrderItem entity)
		{
			return repository.Deactivate(entity);
		}
		
		public OrderItem Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<OrderItem> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<OrderItem> GetActive(Expression<Func<OrderItem, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public OrderItem FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public OrderItem FirstOrDefault(Expression<Func<OrderItem, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<OrderItem> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<OrderItem> FirstOrDefaultAsync(Expression<Func<OrderItem, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
	}
}
