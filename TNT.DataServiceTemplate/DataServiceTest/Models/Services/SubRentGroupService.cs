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
	public partial interface ISubRentGroupService : IBaseService<SubRentGroup, SubRentGroupViewModel, int>
	{
	}
	
	public partial class SubRentGroupService : BaseService<SubRentGroup, SubRentGroupViewModel, int>, ISubRentGroupService
	{
		public SubRentGroupService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ISubRentGroupRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public SubRentGroupService()
		{
			repository = G.TContainer.Resolve<ISubRentGroupRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~SubRentGroupService()
		{
			Dispose(false);
		}
		#endregion
	}
}
