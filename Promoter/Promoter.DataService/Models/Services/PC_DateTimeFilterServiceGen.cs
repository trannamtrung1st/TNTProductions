using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Utilities;
using Promoter.DataService.Managers;
using Promoter.DataService.Models.Repositories;
using Promoter.DataService.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace Promoter.DataService.Models.Services
{
	public partial interface IPC_DateTimeFilterService : IBaseService<PC_DateTimeFilter, int>
	{
	}
	
	public partial class PC_DateTimeFilterService : BaseService<PC_DateTimeFilter, int>, IPC_DateTimeFilterService
	{
		public PC_DateTimeFilterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPC_DateTimeFilterRepository>(uow);
		}
		
		public PC_DateTimeFilterService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPC_DateTimeFilterRepository>(context);
		}
		
	}
}
