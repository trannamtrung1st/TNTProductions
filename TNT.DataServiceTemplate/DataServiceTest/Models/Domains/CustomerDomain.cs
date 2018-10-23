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
	public partial class CustomerDomain : BaseDomain<Models.Customer, CustomerViewModel, int, ICustomerService>
	{
		public CustomerDomain() : base()
		{
		}
		public CustomerDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
