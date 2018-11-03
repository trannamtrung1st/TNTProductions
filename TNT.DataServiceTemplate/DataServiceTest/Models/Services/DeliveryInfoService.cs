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
	public partial interface IDeliveryInfoService : IBaseService<DeliveryInfo, DeliveryInfoViewModel, int>
	{
	}
	
	public partial class DeliveryInfoService : BaseService<DeliveryInfo, DeliveryInfoViewModel, int>, IDeliveryInfoService
	{
		public DeliveryInfoService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeliveryInfoRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DeliveryInfoService()
		{
			repository = G.TContainer.Resolve<IDeliveryInfoRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DeliveryInfoService()
		{
			Dispose(false);
		}
		#endregion
	}
}
