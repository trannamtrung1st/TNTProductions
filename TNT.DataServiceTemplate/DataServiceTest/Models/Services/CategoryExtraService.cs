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
	public partial interface ICategoryExtraService : IBaseService<CategoryExtra, CategoryExtraViewModel, int>
	{
	}
	
	public partial class CategoryExtraService : BaseService<CategoryExtra, CategoryExtraViewModel, int>, ICategoryExtraService
	{
		public CategoryExtraService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICategoryExtraRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CategoryExtraService()
		{
			repository = G.TContainer.Resolve<ICategoryExtraRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CategoryExtraService()
		{
			Dispose(false);
		}
		#endregion
	}
}
