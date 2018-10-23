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
	public partial interface IOrderDetailService : IBaseService<OrderDetail, OrderDetailViewModel, int>
	{
	}
	
	public partial class OrderDetailService : BaseService, IOrderDetailService
	{
		private IOrderDetailRepository repository;
		
		public OrderDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderDetailRepository>(uow);
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
		public OrderDetail Add(OrderDetail entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<OrderDetail> AddAsync(OrderDetail entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public OrderDetail Update(OrderDetail entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<OrderDetail> UpdateAsync(OrderDetail entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public OrderDetail Delete(OrderDetail entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<OrderDetail> DeleteAsync(OrderDetail entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public OrderDetail Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<OrderDetail> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public OrderDetail FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<OrderDetail> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public OrderDetail Activate(OrderDetail entity)
		{
			return repository.Activate(entity);
		}
		
		public OrderDetail Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public OrderDetail Deactivate(OrderDetail entity)
		{
			return repository.Deactivate(entity);
		}
		
		public OrderDetail Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<OrderDetail> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<OrderDetail> GetActive(Expression<Func<OrderDetail, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public OrderDetail FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public OrderDetail FirstOrDefault(Expression<Func<OrderDetail, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<OrderDetail> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<OrderDetail> FirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public OrderDetailService()
		{
			repository = G.TContainer.Resolve<IOrderDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
