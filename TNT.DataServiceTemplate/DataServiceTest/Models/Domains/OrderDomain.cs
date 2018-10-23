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
	public partial class OrderDomain : BaseDomain<Models.Order, OrderViewModel, int, IOrderService>
	{
		public OrderDomain() : base()
		{
		}
		public OrderDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
