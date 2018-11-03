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
	public partial interface IRatingProductService : IBaseService<RatingProduct, RatingProductViewModel, int>
	{
	}
	
	public partial class RatingProductService : BaseService<RatingProduct, RatingProductViewModel, int>, IRatingProductService
	{
		public RatingProductService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IRatingProductRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public RatingProductService()
		{
			repository = G.TContainer.Resolve<IRatingProductRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~RatingProductService()
		{
			Dispose(false);
		}
		#endregion
	}
}
