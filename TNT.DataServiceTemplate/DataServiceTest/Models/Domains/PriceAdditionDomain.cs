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
	public partial class PriceAdditionDomain : BaseDomain<Models.PriceAddition, PriceAdditionViewModel, int, IPriceAdditionService>
	{
		public PriceAdditionDomain() : base()
		{
		}
		public PriceAdditionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
