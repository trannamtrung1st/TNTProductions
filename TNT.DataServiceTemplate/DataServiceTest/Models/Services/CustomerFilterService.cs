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
	public partial interface ICustomerFilterService : IBaseService<CustomerFilter, CustomerFilterViewModel, int>
	{
	}
	
	public partial class CustomerFilterService : BaseService<CustomerFilter, CustomerFilterViewModel, int>, ICustomerFilterService
	{
		public CustomerFilterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerFilterRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CustomerFilterService()
		{
			repository = G.TContainer.Resolve<ICustomerFilterRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerFilterService()
		{
			Dispose(false);
		}
		#endregion
	}
}
