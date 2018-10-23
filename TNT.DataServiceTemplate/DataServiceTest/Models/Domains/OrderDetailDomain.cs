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
	public partial class OrderDetailDomain : BaseDomain<Models.OrderDetail, OrderDetailViewModel, int, IOrderDetailService>
	{
		public OrderDetailDomain() : base()
		{
		}
		public OrderDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
