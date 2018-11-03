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
	public partial interface IDateProductService : IBaseService<DateProduct, DateProductViewModel, int>
	{
	}
	
	public partial class DateProductService : BaseService<DateProduct, DateProductViewModel, int>, IDateProductService
	{
		public DateProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateProductRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DateProductService()
		{
			repository = G.TContainer.Resolve<IDateProductRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateProductService()
		{
			Dispose(false);
		}
		#endregion
	}
}
