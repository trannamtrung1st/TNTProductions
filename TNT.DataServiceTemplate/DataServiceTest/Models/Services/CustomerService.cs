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
	public partial interface ICustomerService : IBaseService<Customer, CustomerViewModel, int>
	{
	}
	
	public partial class CustomerService : BaseService<Customer, CustomerViewModel, int>, ICustomerService
	{
		public CustomerService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CustomerService()
		{
			repository = G.TContainer.Resolve<ICustomerRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerService()
		{
			Dispose(false);
		}
		#endregion
	}
}
