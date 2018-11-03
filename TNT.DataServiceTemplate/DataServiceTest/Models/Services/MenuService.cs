using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Utilities;
using DataServiceTest.Managers;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Repositories;
using DataServiceTest.Global;
using TNT.IoContainer.Wrapper;

namespace DataServiceTest.Models.Services
{
	public partial interface IMenuService : IBaseService<Menu, MenuViewModel, int>
	{
	}
	
	public partial class MenuService : BaseService<Menu, MenuViewModel, int>, IMenuService
	{
		public MenuService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IMenuRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public MenuService()
		{
			repository = G.TContainer.Resolve<IMenuRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~MenuService()
		{
			Dispose(false);
		}
		#endregion
	}
}
