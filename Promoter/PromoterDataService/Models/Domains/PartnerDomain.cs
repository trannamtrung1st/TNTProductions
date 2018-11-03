using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.ViewModels;
using PromoterDataService.Models.Services;
using PromoterDataService.Managers;
using PromoterDataService.Models;

namespace PromoterDataService.Models.Domains
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
