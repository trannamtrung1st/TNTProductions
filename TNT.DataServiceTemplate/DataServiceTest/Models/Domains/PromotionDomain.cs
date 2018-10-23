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
	public partial class PromotionDomain : BaseDomain<Models.Promotion, PromotionViewModel, int, IPromotionService>
	{
		public PromotionDomain() : base()
		{
		}
		public PromotionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
