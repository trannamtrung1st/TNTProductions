using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IDeviceService : IBaseService<Device, int>
	{
	}
	
	public partial class DeviceService : BaseService<Device, int>, IDeviceService
	{
		public DeviceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeviceRepository>(uow);
		}
		
		public DeviceService(DbContext context)
		{
			repository = G.TContainer.Resolve<IDeviceRepository>(context);
		}
		
	}
}
