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
	public partial class CustomerFilterDomain : BaseDomain<Models.CustomerFilter, CustomerFilterViewModel, int, ICustomerFilterService>
	{
		public CustomerFilterDomain() : base()
		{
		}
		public CustomerFilterDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
