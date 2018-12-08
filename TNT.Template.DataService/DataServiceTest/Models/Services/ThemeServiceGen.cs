using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;
using System.Data.Entity;

namespace DataServiceTest.Models.Services
{
	public partial interface IThemeService : IBaseService<Theme, int>
	{
	}
	
	public partial class ThemeService : BaseService<Theme, int>, IThemeService
	{
		public ThemeService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IThemeRepository>(uow);
		}
		
		public ThemeService(DbContext context)
		{
			repository = G.TContainer.Resolve<IThemeRepository>(context);
		}
		
	}
}
