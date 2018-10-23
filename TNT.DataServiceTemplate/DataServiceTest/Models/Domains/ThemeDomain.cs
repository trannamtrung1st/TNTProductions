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
	public partial class ThemeDomain : BaseDomain<Models.Theme, ThemeViewModel, int, IThemeService>
	{
		public ThemeDomain() : base()
		{
		}
		public ThemeDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
