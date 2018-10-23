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
	public partial class StoreGroupMappingDomain : BaseDomain<Models.StoreGroupMapping, StoreGroupMappingViewModel, int, IStoreGroupMappingService>
	{
		public StoreGroupMappingDomain() : base()
		{
		}
		public StoreGroupMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
