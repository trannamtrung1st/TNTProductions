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
	public partial interface ICategoryExtraMappingService : IBaseService<CategoryExtraMapping, CategoryExtraMappingViewModel, int>
	{
	}
	
	public partial class CategoryExtraMappingService : BaseService<CategoryExtraMapping, CategoryExtraMappingViewModel, int>, ICategoryExtraMappingService
	{
		public CategoryExtraMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICategoryExtraMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public CategoryExtraMappingService()
		{
			repository = G.TContainer.Resolve<ICategoryExtraMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~CategoryExtraMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
