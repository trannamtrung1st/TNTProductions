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
	public partial class TimeModeRuleDomain : BaseDomain<Models.TimeModeRule, TimeModeRuleViewModel, int, ITimeModeRuleService>
	{
		public TimeModeRuleDomain() : base()
		{
		}
		public TimeModeRuleDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
