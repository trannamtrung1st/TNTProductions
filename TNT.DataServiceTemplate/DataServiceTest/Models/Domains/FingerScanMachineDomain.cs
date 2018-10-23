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
	public partial class FingerScanMachineDomain : BaseDomain<Models.FingerScanMachine, FingerScanMachineViewModel, int, IFingerScanMachineService>
	{
		public FingerScanMachineDomain() : base()
		{
		}
		public FingerScanMachineDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
