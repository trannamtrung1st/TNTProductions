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
	public partial class C__MigrationHistoryDomain : BaseDomain<Models.C__MigrationHistory, C__MigrationHistoryViewModel, C__MigrationHistoryPK, IC__MigrationHistoryService>
	{
		public C__MigrationHistoryDomain() : base()
		{
		}
		public C__MigrationHistoryDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
