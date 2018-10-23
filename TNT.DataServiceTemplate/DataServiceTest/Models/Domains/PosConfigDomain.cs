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
	public partial class PosConfigDomain : BaseDomain<Models.PosConfig, PosConfigViewModel, int, IPosConfigService>
	{
		public PosConfigDomain() : base()
		{
		}
		public PosConfigDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
