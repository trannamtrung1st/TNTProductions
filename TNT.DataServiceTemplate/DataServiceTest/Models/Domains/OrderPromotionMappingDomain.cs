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
	public partial class OrderPromotionMappingDomain : BaseDomain<Models.OrderPromotionMapping, OrderPromotionMappingViewModel, int, IOrderPromotionMappingService>
	{
		public OrderPromotionMappingDomain() : base()
		{
		}
		public OrderPromotionMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
