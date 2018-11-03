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
	public partial interface IDistrictService : IBaseService<District, DistrictViewModel, int>
	{
	}
	
	public partial class DistrictService : BaseService<District, DistrictViewModel, int>, IDistrictService
	{
		public DistrictService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDistrictRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DistrictService()
		{
			repository = G.TContainer.Resolve<IDistrictRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DistrictService()
		{
			Dispose(false);
		}
		#endregion
	}
}
