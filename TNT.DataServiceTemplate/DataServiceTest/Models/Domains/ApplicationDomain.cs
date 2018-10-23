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
	public partial class ApplicationDomain : BaseDomain<Models.Application, ApplicationViewModel, System.Guid, IApplicationService>
	{
		public ApplicationDomain() : base()
		{
		}
		public ApplicationDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
