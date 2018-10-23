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
	public partial interface IOrderPromotionMappingService : IBaseService<OrderPromotionMapping, OrderPromotionMappingViewModel, int>
	{
	}
	
	public partial class OrderPromotionMappingService : BaseService, IOrderPromotionMappingService
	{
		private IOrderPromotionMappingRepository repository;
		
		public OrderPromotionMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IOrderPromotionMappingRepository>(uow);
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
		public OrderPromotionMapping Add(OrderPromotionMapping entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<OrderPromotionMapping> AddAsync(OrderPromotionMapping entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public OrderPromotionMapping Update(OrderPromotionMapping entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<OrderPromotionMapping> UpdateAsync(OrderPromotionMapping entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public OrderPromotionMapping Delete(OrderPromotionMapping entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<OrderPromotionMapping> DeleteAsync(OrderPromotionMapping entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public OrderPromotionMapping Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<OrderPromotionMapping> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public OrderPromotionMapping FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<OrderPromotionMapping> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public OrderPromotionMapping Activate(OrderPromotionMapping entity)
		{
			return repository.Activate(entity);
		}
		
		public OrderPromotionMapping Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public OrderPromotionMapping Deactivate(OrderPromotionMapping entity)
		{
			return repository.Deactivate(entity);
		}
		
		public OrderPromotionMapping Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<OrderPromotionMapping> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<OrderPromotionMapping> GetActive(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public OrderPromotionMapping FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public OrderPromotionMapping FirstOrDefault(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<OrderPromotionMapping> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<OrderPromotionMapping> FirstOrDefaultAsync(Expression<Func<OrderPromotionMapping, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public OrderPromotionMappingService()
		{
			repository = G.TContainer.Resolve<IOrderPromotionMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~OrderPromotionMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
