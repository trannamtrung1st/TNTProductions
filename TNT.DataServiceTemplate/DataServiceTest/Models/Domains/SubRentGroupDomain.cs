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
	public partial class SubRentGroupDomain : BaseDomain<Models.SubRentGroup, SubRentGroupViewModel, int, ISubRentGroupService>
	{
		public SubRentGroupDomain() : base()
		{
		}
		public SubRentGroupDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
