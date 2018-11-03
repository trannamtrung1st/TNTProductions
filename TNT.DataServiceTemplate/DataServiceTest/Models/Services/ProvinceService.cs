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
	public partial interface IProvinceService : IBaseService<Province, ProvinceViewModel, int>
	{
	}
	
	public partial class ProvinceService : BaseService<Province, ProvinceViewModel, int>, IProvinceService
	{
		public ProvinceService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProvinceRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProvinceService()
		{
			repository = G.TContainer.Resolve<IProvinceRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProvinceService()
		{
			Dispose(false);
		}
		#endregion
	}
}
