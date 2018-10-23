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
	public partial class DateProductDomain : BaseDomain<Models.DateProduct, DateProductViewModel, int, IDateProductService>
	{
		public DateProductDomain() : base()
		{
		}
		public DateProductDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
