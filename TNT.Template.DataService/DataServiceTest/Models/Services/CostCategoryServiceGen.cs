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
	public partial interface ICostCategoryService : IBaseService<CostCategory, int>
	{
	}
	
	public partial class CostCategoryService : BaseService<CostCategory, int>, ICostCategoryService
	{
		public CostCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostCategoryRepository>(uow);
		}
		
		public CostCategoryService(DbContext context)
		{
			repository = G.TContainer.Resolve<ICostCategoryRepository>(context);
		}
		
	}
}
