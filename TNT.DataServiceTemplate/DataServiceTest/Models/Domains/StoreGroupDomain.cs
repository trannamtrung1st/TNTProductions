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
	public partial class StoreGroupDomain : BaseDomain<Models.StoreGroup, StoreGroupViewModel, int, IStoreGroupService>
	{
		public StoreGroupDomain() : base()
		{
		}
		public StoreGroupDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
