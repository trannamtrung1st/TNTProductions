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
	public partial class TimeModeTypeDomain : BaseDomain<Models.TimeModeType, TimeModeTypeViewModel, int, ITimeModeTypeService>
	{
		public TimeModeTypeDomain() : base()
		{
		}
		public TimeModeTypeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
