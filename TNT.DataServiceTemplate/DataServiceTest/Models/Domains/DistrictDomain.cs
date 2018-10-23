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
	public partial class DistrictDomain : BaseDomain<Models.District, DistrictViewModel, int, IDistrictService>
	{
		public DistrictDomain() : base()
		{
		}
		public DistrictDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
