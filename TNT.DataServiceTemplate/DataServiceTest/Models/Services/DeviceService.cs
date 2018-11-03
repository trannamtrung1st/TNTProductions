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
	
	public partial class DeviceService : BaseService<Device, DeviceViewModel, int>, IDeviceService
	{
		public DeviceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeviceRepository>(uow);
		}
		
		
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
