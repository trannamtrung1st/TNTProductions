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
	public partial class PromotionDetailDomain : BaseDomain<Models.PromotionDetail, PromotionDetailViewModel, int, IPromotionDetailService>
	{
		public PromotionDetailDomain() : base()
		{
		}
		public PromotionDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
