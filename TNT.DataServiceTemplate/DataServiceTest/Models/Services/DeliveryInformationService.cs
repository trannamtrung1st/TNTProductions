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
	public partial interface IDeliveryInformationService : IBaseService<DeliveryInformation, DeliveryInformationViewModel, int>
	{
	}
	
	public partial class DeliveryInformationService : BaseService<DeliveryInformation, DeliveryInformationViewModel, int>, IDeliveryInformationService
	{
		public DeliveryInformationService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IDeliveryInformationRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public DeliveryInformationService()
		{
			repository = G.TContainer.Resolve<IDeliveryInformationRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~DeliveryInformationService()
		{
			Dispose(false);
		}
		#endregion
	}
}
