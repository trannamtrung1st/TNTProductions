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
	public partial interface IDeliveryInformationService : IBaseService<DeliveryInformation, DeliveryInformationViewModel, int>
	{
	}
	
	public partial class DeliveryInformationService : BaseService, IDeliveryInformationService
	{
		private IDeliveryInformationRepository repository;
		
		public DeliveryInformationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeliveryInformationRepository>(uow);
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
		public DeliveryInformation Add(DeliveryInformation entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<DeliveryInformation> AddAsync(DeliveryInformation entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public DeliveryInformation Update(DeliveryInformation entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<DeliveryInformation> UpdateAsync(DeliveryInformation entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public DeliveryInformation Delete(DeliveryInformation entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<DeliveryInformation> DeleteAsync(DeliveryInformation entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public DeliveryInformation Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<DeliveryInformation> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public DeliveryInformation FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<DeliveryInformation> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public DeliveryInformation Activate(DeliveryInformation entity)
		{
			return repository.Activate(entity);
		}
		
		public DeliveryInformation Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public DeliveryInformation Deactivate(DeliveryInformation entity)
		{
			return repository.Deactivate(entity);
		}
		
		public DeliveryInformation Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<DeliveryInformation> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<DeliveryInformation> GetActive(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public DeliveryInformation FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public DeliveryInformation FirstOrDefault(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<DeliveryInformation> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<DeliveryInformation> FirstOrDefaultAsync(Expression<Func<DeliveryInformation, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DeliveryInformationService()
		{
			repository = G.TContainer.Resolve<IDeliveryInformationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DeliveryInformationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
