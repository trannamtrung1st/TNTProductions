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
	public partial class PosDomain : BaseDomain<Models.Pos, PosViewModel, int, IPosService>
	{
		public PosDomain() : base()
		{
		}
		public PosDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
