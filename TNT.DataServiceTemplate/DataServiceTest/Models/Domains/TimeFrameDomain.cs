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
	public partial class TimeFrameDomain : BaseDomain<Models.TimeFrame, TimeFrameViewModel, int, ITimeFrameService>
	{
		public TimeFrameDomain() : base()
		{
		}
		public TimeFrameDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
