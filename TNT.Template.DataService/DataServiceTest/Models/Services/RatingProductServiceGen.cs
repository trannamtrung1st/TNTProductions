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
	public partial interface IRatingProductService : IBaseService<RatingProduct, int>
	{
	}
	
	public partial class RatingProductService : BaseService<RatingProduct, int>, IRatingProductService
	{
		public RatingProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRatingProductRepository>(uow);
		}
		
		public RatingProductService(DbContext context)
		{
			repository = G.TContainer.Resolve<IRatingProductRepository>(context);
		}
		
	}
}
