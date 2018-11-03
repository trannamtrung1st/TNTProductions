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
	public partial class GiftDetailDomain : BaseDomain<Models.GiftDetail, GiftDetailViewModel, GiftDetailPK, IGiftDetailService>
	{
		public GiftDetailDomain() : base()
		{
		}
		public GiftDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
