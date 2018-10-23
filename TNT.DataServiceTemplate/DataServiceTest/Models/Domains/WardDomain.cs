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
	public partial class WardDomain : BaseDomain<Models.Ward, WardViewModel, int, IWardService>
	{
		public WardDomain() : base()
		{
		}
		public WardDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
