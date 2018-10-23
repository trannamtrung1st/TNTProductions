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
	public partial class DeliveryInformationDomain : BaseDomain<Models.DeliveryInformation, DeliveryInformationViewModel, int, IDeliveryInformationService>
	{
		public DeliveryInformationDomain() : base()
		{
		}
		public DeliveryInformationDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
