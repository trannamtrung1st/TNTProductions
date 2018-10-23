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
	public partial class MembershipCardTypeDomain : BaseDomain<Models.MembershipCardType, MembershipCardTypeViewModel, int, IMembershipCardTypeService>
	{
		public MembershipCardTypeDomain() : base()
		{
		}
		public MembershipCardTypeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
