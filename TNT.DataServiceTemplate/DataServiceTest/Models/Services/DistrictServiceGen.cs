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
	public partial interface IDistrictService : IBaseService<District, int>
	{
	}
	
	public partial class DistrictService : BaseService<District, int>, IDistrictService
	{
		public DistrictService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDistrictRepository>(uow);
		}
		
	}
}
