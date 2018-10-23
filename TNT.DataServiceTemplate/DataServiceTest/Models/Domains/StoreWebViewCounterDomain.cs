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
	public partial class StoreWebViewCounterDomain : BaseDomain<Models.StoreWebViewCounter, StoreWebViewCounterViewModel, int, IStoreWebViewCounterService>
	{
		public StoreWebViewCounterDomain() : base()
		{
		}
		public StoreWebViewCounterDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
