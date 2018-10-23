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
	public partial interface IOrderService : IBaseService<Order, OrderViewModel, int>
	{
	}
	
	public partial class OrderService : BaseService, IOrderService
	{
		private IOrderRepository repository;
		
		public OrderService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderRepository>(uow);
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
		public Order Add(Order entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Order> AddAsync(Order entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Order Update(Order entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Order> UpdateAsync(Order entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Order Delete(Order entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Order> DeleteAsync(Order entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Order Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Order> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Order FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Order> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Order Activate(Order entity)
		{
			return repository.Activate(entity);
		}
		
		public Order Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Order Deactivate(Order entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Order Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Order> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Order> GetActive(Expression<Func<Order, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Order FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Order FirstOrDefault(Expression<Func<Order, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Order> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public OrderService()
		{
			repository = G.TContainer.Resolve<IOrderRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderService()
		{
			Dispose(false);
		}
		#endregion
	}
}
