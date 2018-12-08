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
	public partial interface IWebElementService : IBaseService<WebElement, int>
	{
	}
	
	public partial class WebElementService : BaseService<WebElement, int>, IWebElementService
	{
		public WebElementService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IWebElementRepository>(uow);
		}
		
		public WebElementService(DbContext context)
		{
			repository = G.TContainer.Resolve<IWebElementRepository>(context);
		}
		
	}
}
