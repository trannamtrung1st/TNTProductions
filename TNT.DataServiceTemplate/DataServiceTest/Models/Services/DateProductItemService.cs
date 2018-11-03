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
	public partial interface IDateProductItemService : IBaseService<DateProductItem, DateProductItemViewModel, int>
	{
	}
	
	public partial class DateProductItemService : BaseService<DateProductItem, DateProductItemViewModel, int>, IDateProductItemService
	{
		public DateProductItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateProductItemRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DateProductItemService()
		{
			repository = G.TContainer.Resolve<IDateProductItemRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DateProductItemService()
		{
			Dispose(false);
		}
		#endregion
	}
}
