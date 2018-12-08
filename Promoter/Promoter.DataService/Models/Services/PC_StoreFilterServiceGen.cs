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
	public partial interface IPC_StoreFilterService : IBaseService<PC_StoreFilter, PC_StoreFilterPK>
	{
	}
	
	public partial class PC_StoreFilterService : BaseService<PC_StoreFilter, PC_StoreFilterPK>, IPC_StoreFilterService
	{
		public PC_StoreFilterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPC_StoreFilterRepository>(uow);
		}
		
		public PC_StoreFilterService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPC_StoreFilterRepository>(context);
		}
		
	}
}
