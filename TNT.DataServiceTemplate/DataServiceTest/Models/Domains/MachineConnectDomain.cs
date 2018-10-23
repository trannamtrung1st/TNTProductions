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
	public partial class MachineConnectDomain : BaseDomain<Models.MachineConnect, MachineConnectViewModel, int, IMachineConnectService>
	{
		public MachineConnectDomain() : base()
		{
		}
		public MachineConnectDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
