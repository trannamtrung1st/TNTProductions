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
	public partial interface ICostCategoryService : IBaseService<CostCategory, CostCategoryViewModel, int>
	{
	}
	
	public partial class CostCategoryService : BaseService<CostCategory, CostCategoryViewModel, int>, ICostCategoryService
	{
		public CostCategoryService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICostCategoryRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CostCategoryService()
		{
			repository = G.TContainer.Resolve<ICostCategoryRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CostCategoryService()
		{
			Dispose(false);
		}
		#endregion
	}
}
