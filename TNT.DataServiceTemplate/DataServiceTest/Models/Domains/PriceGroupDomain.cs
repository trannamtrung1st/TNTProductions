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
	public partial class PriceGroupDomain : BaseDomain<Models.PriceGroup, PriceGroupViewModel, int, IPriceGroupService>
	{
		public PriceGroupDomain() : base()
		{
		}
		public PriceGroupDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
