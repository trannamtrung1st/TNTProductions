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
	public partial class RedemptionRollbackDomain : BaseDomain<Models.RedemptionRollback, RedemptionRollbackViewModel, int, IRedemptionRollbackService>
	{
		public RedemptionRollbackDomain() : base()
		{
		}
		public RedemptionRollbackDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
