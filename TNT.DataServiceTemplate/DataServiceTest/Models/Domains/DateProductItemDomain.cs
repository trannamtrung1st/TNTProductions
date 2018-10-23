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
	public partial class DateProductItemDomain : BaseDomain<Models.DateProductItem, DateProductItemViewModel, int, IDateProductItemService>
	{
		public DateProductItemDomain() : base()
		{
		}
		public DateProductItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
