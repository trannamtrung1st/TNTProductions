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

namespace DataServiceTest.Models.Services
{
	public partial interface ICategoryExtraMappingService : IBaseService<CategoryExtraMapping, int>
	{
	}
	
	public partial class CategoryExtraMappingService : BaseService<CategoryExtraMapping, int>, ICategoryExtraMappingService
	{
		public CategoryExtraMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ICategoryExtraMappingRepository>(uow);
		}
		
	}
}
