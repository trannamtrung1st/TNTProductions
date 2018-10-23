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
	public partial class CustomerProductMappingDomain : BaseDomain<Models.CustomerProductMapping, CustomerProductMappingViewModel, int, ICustomerProductMappingService>
	{
		public CustomerProductMappingDomain() : base()
		{
		}
		public CustomerProductMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
