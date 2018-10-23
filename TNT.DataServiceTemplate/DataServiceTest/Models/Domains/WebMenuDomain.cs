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
	public partial class WebMenuDomain : BaseDomain<Models.WebMenu, WebMenuViewModel, int, IWebMenuService>
	{
		public WebMenuDomain() : base()
		{
		}
		public WebMenuDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
