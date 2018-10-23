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
	public partial class WebElementTypeDomain : BaseDomain<Models.WebElementType, WebElementTypeViewModel, int, IWebElementTypeService>
	{
		public WebElementTypeDomain() : base()
		{
		}
		public WebElementTypeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
