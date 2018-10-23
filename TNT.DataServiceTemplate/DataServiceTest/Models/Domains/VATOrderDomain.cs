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
	public partial class VATOrderDomain : BaseDomain<Models.VATOrder, VATOrderViewModel, int, IVATOrderService>
	{
		public VATOrderDomain() : base()
		{
		}
		public VATOrderDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
