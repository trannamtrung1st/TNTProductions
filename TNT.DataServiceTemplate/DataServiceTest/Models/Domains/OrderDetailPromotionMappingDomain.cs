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
	public partial class OrderDetailPromotionMappingDomain : BaseDomain<Models.OrderDetailPromotionMapping, OrderDetailPromotionMappingViewModel, int, IOrderDetailPromotionMappingService>
	{
		public OrderDetailPromotionMappingDomain() : base()
		{
		}
		public OrderDetailPromotionMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
