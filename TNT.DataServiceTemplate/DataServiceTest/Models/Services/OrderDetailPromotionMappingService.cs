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
	public partial interface IOrderDetailPromotionMappingService : IBaseService<OrderDetailPromotionMapping, OrderDetailPromotionMappingViewModel, int>
	{
	}
	
	public partial class OrderDetailPromotionMappingService : BaseService, IOrderDetailPromotionMappingService
	{
		private IOrderDetailPromotionMappingRepository repository;
		
		public OrderDetailPromotionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderDetailPromotionMappingRepository>(uow);
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
		public OrderDetailPromotionMapping Add(OrderDetailPromotionMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<OrderDetailPromotionMapping> AddAsync(OrderDetailPromotionMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public OrderDetailPromotionMapping Update(OrderDetailPromotionMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<OrderDetailPromotionMapping> UpdateAsync(OrderDetailPromotionMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public OrderDetailPromotionMapping Delete(OrderDetailPromotionMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<OrderDetailPromotionMapping> DeleteAsync(OrderDetailPromotionMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public OrderDetailPromotionMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<OrderDetailPromotionMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public OrderDetailPromotionMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<OrderDetailPromotionMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public OrderDetailPromotionMapping Activate(OrderDetailPromotionMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public OrderDetailPromotionMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public OrderDetailPromotionMapping Deactivate(OrderDetailPromotionMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public OrderDetailPromotionMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<OrderDetailPromotionMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<OrderDetailPromotionMapping> GetActive(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public OrderDetailPromotionMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public OrderDetailPromotionMapping FirstOrDefault(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<OrderDetailPromotionMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<OrderDetailPromotionMapping> FirstOrDefaultAsync(Expression<Func<OrderDetailPromotionMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public OrderDetailPromotionMappingService()
		{
			repository = G.TContainer.Resolve<IOrderDetailPromotionMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderDetailPromotionMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
