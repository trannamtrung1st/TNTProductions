using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IDateProductItemService : IBaseService<DateProductItem, int>
	{
	}
	
	public partial class DateProductItemService : BaseService<DateProductItem, int>, IDateProductItemService
	{
		public DateProductItemService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDateProductItemRepository>(uow);
		}
		
		public DateProductItemService(DbContext context)
		{
			repository = G.TContainer.Resolve<IDateProductItemRepository>(context);
		}
		
	}
}
