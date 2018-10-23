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
	public partial class VATOrderMappingDomain : BaseDomain<Models.VATOrderMapping, VATOrderMappingViewModel, int, IVATOrderMappingService>
	{
		public VATOrderMappingDomain() : base()
		{
		}
		public VATOrderMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
