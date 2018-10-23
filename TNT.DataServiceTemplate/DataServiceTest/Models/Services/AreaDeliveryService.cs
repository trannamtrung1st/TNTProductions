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
	public partial interface IAreaDeliveryService : IBaseService<AreaDelivery, AreaDeliveryViewModel, int>
	{
	}
	
	public partial class AreaDeliveryService : BaseService, IAreaDeliveryService
	{
		private IAreaDeliveryRepository repository;
		
		public AreaDeliveryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IAreaDeliveryRepository>(uow);
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
		public AreaDelivery Add(AreaDelivery entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<AreaDelivery> AddAsync(AreaDelivery entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public AreaDelivery Update(AreaDelivery entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<AreaDelivery> UpdateAsync(AreaDelivery entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public AreaDelivery Delete(AreaDelivery entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<AreaDelivery> DeleteAsync(AreaDelivery entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public AreaDelivery Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<AreaDelivery> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public AreaDelivery FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<AreaDelivery> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public AreaDelivery Activate(AreaDelivery entity)
		{
			return repository.Activate(entity);
		}
		
		public AreaDelivery Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public AreaDelivery Deactivate(AreaDelivery entity)
		{
			return repository.Deactivate(entity);
		}
		
		public AreaDelivery Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<AreaDelivery> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<AreaDelivery> GetActive(Expression<Func<AreaDelivery, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public AreaDelivery FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public AreaDelivery FirstOrDefault(Expression<Func<AreaDelivery, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<AreaDelivery> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<AreaDelivery> FirstOrDefaultAsync(Expression<Func<AreaDelivery, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public AreaDeliveryService()
		{
			repository = G.TContainer.Resolve<IAreaDeliveryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~AreaDeliveryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
