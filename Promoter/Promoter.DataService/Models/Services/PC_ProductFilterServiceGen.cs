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
	public partial interface IPC_ProductFilterService : IBaseService<PC_ProductFilter, int>
	{
	}
	
	public partial class PC_ProductFilterService : BaseService<PC_ProductFilter, int>, IPC_ProductFilterService
	{
		public PC_ProductFilterService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPC_ProductFilterRepository>(uow);
		}
		
		public PC_ProductFilterService(DbContext context)
		{
			repository = G.TContainer.Resolve<IPC_ProductFilterRepository>(context);
		}
		
	}
}
