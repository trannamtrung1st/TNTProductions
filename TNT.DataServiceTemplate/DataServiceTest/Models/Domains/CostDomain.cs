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
	public partial class CostDomain : BaseDomain<Models.Cost, CostViewModel, int, ICostService>
	{
		public CostDomain() : base()
		{
		}
		public CostDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
