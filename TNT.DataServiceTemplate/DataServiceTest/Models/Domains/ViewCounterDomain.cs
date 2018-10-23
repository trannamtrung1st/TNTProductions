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
	public partial class ViewCounterDomain : BaseDomain<Models.ViewCounter, ViewCounterViewModel, int, IViewCounterService>
	{
		public ViewCounterDomain() : base()
		{
		}
		public ViewCounterDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
