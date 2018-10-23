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
	public partial class CustomerTypeDomain : BaseDomain<Models.CustomerType, CustomerTypeViewModel, int, ICustomerTypeService>
	{
		public CustomerTypeDomain() : base()
		{
		}
		public CustomerTypeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
