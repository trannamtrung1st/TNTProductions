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
	public partial class StoreWebSettingDomain : BaseDomain<Models.StoreWebSetting, StoreWebSettingViewModel, int, IStoreWebSettingService>
	{
		public StoreWebSettingDomain() : base()
		{
		}
		public StoreWebSettingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
