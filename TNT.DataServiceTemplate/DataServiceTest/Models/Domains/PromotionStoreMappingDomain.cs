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
	public partial class PromotionStoreMappingDomain : BaseDomain<Models.PromotionStoreMapping, PromotionStoreMappingViewModel, int, IPromotionStoreMappingService>
	{
		public PromotionStoreMappingDomain() : base()
		{
		}
		public PromotionStoreMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
