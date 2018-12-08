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
	public partial interface IProvinceService : IBaseService<Province, int>
	{
	}
	
	public partial class ProvinceService : BaseService<Province, int>, IProvinceService
	{
		public ProvinceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProvinceRepository>(uow);
		}
		
		public ProvinceService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProvinceRepository>(context);
		}
		
	}
}
