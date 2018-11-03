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
	public partial interface IMachineConnectService : IBaseService<MachineConnect, MachineConnectViewModel, int>
	{
	}
	
	public partial class MachineConnectService : BaseService<MachineConnect, MachineConnectViewModel, int>, IMachineConnectService
	{
		public MachineConnectService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMachineConnectRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public MachineConnectService()
		{
			repository = G.TContainer.Resolve<IMachineConnectRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MachineConnectService()
		{
			Dispose(false);
		}
		#endregion
	}
}
