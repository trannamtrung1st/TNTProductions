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
	public partial class StoreThemeDomain : BaseDomain<Models.StoreTheme, StoreThemeViewModel, int, IStoreThemeService>
	{
		public StoreThemeDomain() : base()
		{
		}
		public StoreThemeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
