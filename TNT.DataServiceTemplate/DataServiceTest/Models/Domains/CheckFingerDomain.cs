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
	public partial class CheckFingerDomain : BaseDomain<Models.CheckFinger, CheckFingerViewModel, int, ICheckFingerService>
	{
		public CheckFingerDomain() : base()
		{
		}
		public CheckFingerDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
