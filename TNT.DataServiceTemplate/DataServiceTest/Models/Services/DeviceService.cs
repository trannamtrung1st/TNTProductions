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
	public partial interface IDeviceService : IBaseService<Device, DeviceViewModel, int>
	{
	}
	
	public partial class DeviceService : BaseService, IDeviceService
	{
		private IDeviceRepository repository;
		
		public DeviceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeviceRepository>(uow);
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
		public Device Add(Device entity)
		{
			return repository.Add(entity);
		}
		
		public async Task<Device> AddAsync(Device entity)
		{
			return await repository.AddAsync(entity);
		}
		
		public Device Update(Device entity)
		{
			return repository.Update(entity);
		}
		
		public async Task<Device> UpdateAsync(Device entity)
		{
			return await repository.UpdateAsync(entity);
		}
		
		public Device Delete(Device entity)
		{
			return repository.Delete(entity);
		}
		
		public async Task<Device> DeleteAsync(Device entity)
		{
			return await repository.DeleteAsync(entity);
		}
		
		public Device Delete(int key)
		{
			return repository.Delete(key);
		}
		
		public async Task<Device> DeleteAsync(int key)
		{
			return await repository.DeleteAsync(key);
		}
		
		public Device FindById(int key)
		{
			return repository.FindActiveById(key);
		}
		
		public async Task<Device> FindByIdAsync(int key)
		{
			return await repository.FindActiveByIdAsync(key);
		}
		
		public Device Activate(Device entity)
		{
			return repository.Activate(entity);
		}
		
		public Device Activate(int key)
		{
			return repository.Activate(key);
		}
		
		public Device Deactivate(Device entity)
		{
			return repository.Deactivate(entity);
		}
		
		public Device Deactivate(int key)
		{
			return repository.Deactivate(key);
		}
		
		public IQueryable<Device> GetActive()
		{
			return repository.GetActive();
		}
		
		public IQueryable<Device> GetActive(Expression<Func<Device, bool>> expr)
		{
			return repository.GetActive(expr);
		}
		
		public Device FirstOrDefault()
		{
			return repository.FirstOrDefault();
		}
		
		public Device FirstOrDefault(Expression<Func<Device, bool>> expr)
		{
			return repository.FirstOrDefault(expr);
		}
		
		public async Task<Device> FirstOrDefaultAsync()
		{
			return await repository.FirstOrDefaultAsync();
		}
		
		public async Task<Device> FirstOrDefaultAsync(Expression<Func<Device, bool>> expr)
		{
			return await repository.FirstOrDefaultAsync(expr);
		}
		#endregion
		
		#region Implement for Resource Pooling
		public DeviceService()
		{
			repository = G.TContainer.Resolve<IDeviceRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DeviceService()
		{
			Dispose(false);
		}
		#endregion
	}
}
