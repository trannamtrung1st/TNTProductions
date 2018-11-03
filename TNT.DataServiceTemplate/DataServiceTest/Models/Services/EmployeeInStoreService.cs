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
	public partial interface IEmployeeInStoreService : IBaseService<EmployeeInStore, EmployeeInStoreViewModel, int>
	{
	}
	
	public partial class EmployeeInStoreService : BaseService<EmployeeInStore, EmployeeInStoreViewModel, int>, IEmployeeInStoreService
	{
		public EmployeeInStoreService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IEmployeeInStoreRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public EmployeeInStoreService()
		{
			repository = G.TContainer.Resolve<IEmployeeInStoreRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~EmployeeInStoreService()
		{
			Dispose(false);
		}
		#endregion
	}
}
