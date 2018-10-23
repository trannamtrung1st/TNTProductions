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
	public partial class OrderGroupDomain : BaseDomain<Models.OrderGroup, OrderGroupViewModel, int, IOrderGroupService>
	{
		public OrderGroupDomain() : base()
		{
		}
		public OrderGroupDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
