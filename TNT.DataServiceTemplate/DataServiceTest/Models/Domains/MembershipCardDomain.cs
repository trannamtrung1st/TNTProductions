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
	public partial class MembershipCardDomain : BaseDomain<Models.MembershipCard, MembershipCardViewModel, int, IMembershipCardService>
	{
		public MembershipCardDomain() : base()
		{
		}
		public MembershipCardDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
