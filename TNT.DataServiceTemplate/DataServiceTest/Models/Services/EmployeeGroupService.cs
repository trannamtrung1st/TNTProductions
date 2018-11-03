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
	public partial interface IEmployeeGroupService : IBaseService<EmployeeGroup, EmployeeGroupViewModel, int>
	{
	}
	
	public partial class EmployeeGroupService : BaseService<EmployeeGroup, EmployeeGroupViewModel, int>, IEmployeeGroupService
	{
		public EmployeeGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeGroupRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public EmployeeGroupService()
		{
			repository = G.TContainer.Resolve<IEmployeeGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
