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
	public partial interface IMachineConnectService : IBaseService<MachineConnect, int>
	{
	}
	
	public partial class MachineConnectService : BaseService<MachineConnect, int>, IMachineConnectService
	{
		public MachineConnectService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMachineConnectRepository>(uow);
		}
		
		public MachineConnectService(DbContext context)
		{
			repository = G.TContainer.Resolve<IMachineConnectRepository>(context);
		}
		
	}
}
