using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class StoreWebRouteModelDomain : BaseDomain<Models.StoreWebRouteModel, StoreWebRouteModelViewModel, int, IStoreWebRouteModelService>
	{
		public StoreWebRouteModelDomain() : base()
		{
		}
		public StoreWebRouteModelDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
