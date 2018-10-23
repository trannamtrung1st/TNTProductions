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
	public partial class sysdiagramDomain : BaseDomain<Models.sysdiagram, sysdiagramViewModel, int, IsysdiagramService>
	{
		public sysdiagramDomain() : base()
		{
		}
		public sysdiagramDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
