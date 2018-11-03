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
	public partial interface ICustomerTypeService : IBaseService<CustomerType, CustomerTypeViewModel, int>
	{
	}
	
	public partial class CustomerTypeService : BaseService<CustomerType, CustomerTypeViewModel, int>, ICustomerTypeService
	{
		public CustomerTypeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICustomerTypeRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CustomerTypeService()
		{
			repository = G.TContainer.Resolve<ICustomerTypeRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CustomerTypeService()
		{
			Dispose(false);
		}
		#endregion
	}
}
