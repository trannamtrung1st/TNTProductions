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
	public partial interface IWebMenuService : IBaseService<WebMenu, int>
	{
	}
	
	public partial class WebMenuService : BaseService<WebMenu, int>, IWebMenuService
	{
		public WebMenuService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebMenuRepository>(uow);
		}
		
		public WebMenuService(DbContext context)
		{
			repository = G.TContainer.Resolve<IWebMenuRepository>(context);
		}
		
	}
}
