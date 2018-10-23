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
	public partial class ProviderDomain : BaseDomain<Models.Provider, ProviderViewModel, int, IProviderService>
	{
		public ProviderDomain() : base()
		{
		}
		public ProviderDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
