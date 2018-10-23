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
	public partial class DayModeDomain : BaseDomain<Models.DayMode, DayModeViewModel, int, IDayModeService>
	{
		public DayModeDomain() : base()
		{
		}
		public DayModeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
