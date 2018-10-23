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
	public partial class PartnerDomain : BaseDomain<Models.Partner, PartnerViewModel, int, IPartnerService>
	{
		public PartnerDomain() : base()
		{
		}
		public PartnerDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
