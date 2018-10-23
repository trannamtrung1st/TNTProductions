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
	public partial class MenuDomain : BaseDomain<Models.Menu, MenuViewModel, int, IMenuService>
	{
		public MenuDomain() : base()
		{
		}
		public MenuDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
