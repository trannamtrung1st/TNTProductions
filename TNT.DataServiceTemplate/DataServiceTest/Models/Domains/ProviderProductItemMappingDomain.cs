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
	public partial class ProviderProductItemMappingDomain : BaseDomain<Models.ProviderProductItemMapping, ProviderProductItemMappingViewModel, int, IProviderProductItemMappingService>
	{
		public ProviderProductItemMappingDomain() : base()
		{
		}
		public ProviderProductItemMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
