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
	public partial class ProfileDomain : BaseDomain<Models.Profile, ProfileViewModel, System.Guid, IProfileService>
	{
		public ProfileDomain() : base()
		{
		}
		public ProfileDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
