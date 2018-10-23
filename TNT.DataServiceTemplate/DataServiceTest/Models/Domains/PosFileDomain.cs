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
	public partial class PosFileDomain : BaseDomain<Models.PosFile, PosFileViewModel, int, IPosFileService>
	{
		public PosFileDomain() : base()
		{
		}
		public PosFileDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
