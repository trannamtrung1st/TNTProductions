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
	public partial interface IDeliveryInfoService : IBaseService<DeliveryInfo, DeliveryInfoViewModel, int>
	{
	}
	
	public partial class DeliveryInfoService : BaseService, IDeliveryInfoService
	{
		private IDeliveryInfoRepository repository;
		
		public DeliveryInfoService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeliveryInfoRepository>(uow);
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
		public DeliveryInfo Add(DeliveryInfo entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DeliveryInfo> AddAsync(DeliveryInfo entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DeliveryInfo Update(DeliveryInfo entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DeliveryInfo> UpdateAsync(DeliveryInfo entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DeliveryInfo Delete(DeliveryInfo entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DeliveryInfo> DeleteAsync(DeliveryInfo entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DeliveryInfo Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DeliveryInfo> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DeliveryInfo FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DeliveryInfo> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DeliveryInfo Activate(DeliveryInfo entity)
		{
			return repository.Activate(entity);
		}
		
		public DeliveryInfo Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DeliveryInfo Deactivate(DeliveryInfo entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DeliveryInfo Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DeliveryInfo> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DeliveryInfo> GetActive(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DeliveryInfo FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DeliveryInfo FirstOrDefault(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DeliveryInfo> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DeliveryInfo> FirstOrDefaultAsync(Expression<Func<DeliveryInfo, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DeliveryInfoService()
		{
			repository = G.TContainer.Resolve<IDeliveryInfoRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DeliveryInfoService()
		{
			Dispose(false);
		}
		#endregion
	}
}
