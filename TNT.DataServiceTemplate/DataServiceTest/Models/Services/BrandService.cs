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
	public partial interface IBrandService : IBaseService<Brand, BrandViewModel, int>
	{
	}
	
	public partial class BrandService : BaseService<Brand, BrandViewModel, int>, IBrandService
	{
		public BrandService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IBrandRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public BrandService()
		{
			repository = G.TContainer.Resolve<IBrandRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~BrandService()
		{
			Dispose(false);
		}
		#endregion
	}
}
