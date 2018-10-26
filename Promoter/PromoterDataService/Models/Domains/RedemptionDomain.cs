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
	public partial class RedemptionDomain : BaseDomain<Models.Redemption, RedemptionViewModel, int, IRedemptionService>
	{
		public RedemptionDomain() : base()
		{
		}
		public RedemptionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
