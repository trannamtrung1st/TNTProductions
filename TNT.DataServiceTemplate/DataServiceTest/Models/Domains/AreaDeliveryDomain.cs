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
	public partial class AreaDeliveryDomain : BaseDomain<Models.AreaDelivery, AreaDeliveryViewModel, int, IAreaDeliveryService>
	{
		public AreaDeliveryDomain() : base()
		{
		}
		public AreaDeliveryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
