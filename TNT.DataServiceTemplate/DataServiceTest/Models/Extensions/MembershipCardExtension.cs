using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class MembershipCard : BaseEntity<MembershipCardViewModel>
	{
		public override MembershipCardViewModel ToViewModel()
		{
			return new MembershipCardViewModel(this);
		}
		
	}
}
