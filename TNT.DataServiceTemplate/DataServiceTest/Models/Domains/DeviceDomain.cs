using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class DeviceDomain : BaseDomain<Models.Device, DeviceViewModel, int, IDeviceService>
	{
		public DeviceDomain() : base()
		{
		}
		public DeviceDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
