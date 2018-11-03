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
	public partial interface IGroupService : IBaseService<Group, GroupViewModel, int>
	{
	}
	
	public partial class GroupService : BaseService<Group, GroupViewModel, int>, IGroupService
	{
		public GroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IGroupRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public GroupService()
		{
			repository = G.TContainer.Resolve<IGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~GroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
