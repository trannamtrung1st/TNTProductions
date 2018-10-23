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
	public partial class WebElementDomain : BaseDomain<Models.WebElement, WebElementViewModel, int, IWebElementService>
	{
		public WebElementDomain() : base()
		{
		}
		public WebElementDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
