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
	public partial interface IOrderGroupService : IBaseService<OrderGroup, OrderGroupViewModel, int>
	{
	}
	
	public partial class OrderGroupService : BaseService, IOrderGroupService
	{
		private IOrderGroupRepository repository;
		
		public OrderGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderGroupRepository>(uow);
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
		public OrderGroup Add(OrderGroup entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<OrderGroup> AddAsync(OrderGroup entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public OrderGroup Update(OrderGroup entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<OrderGroup> UpdateAsync(OrderGroup entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public OrderGroup Delete(OrderGroup entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<OrderGroup> DeleteAsync(OrderGroup entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public OrderGroup Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<OrderGroup> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public OrderGroup FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<OrderGroup> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public OrderGroup Activate(OrderGroup entity)
		{
			return repository.Activate(entity);
		}
		
		public OrderGroup Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public OrderGroup Deactivate(OrderGroup entity)
		{
			return repository.Deactivate(entity);
		}
		
		public OrderGroup Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<OrderGroup> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<OrderGroup> GetActive(Expression<Func<OrderGroup, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public OrderGroup FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public OrderGroup FirstOrDefault(Expression<Func<OrderGroup, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<OrderGroup> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<OrderGroup> FirstOrDefaultAsync(Expression<Func<OrderGroup, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public OrderGroupService()
		{
			repository = G.TContainer.Resolve<IOrderGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
