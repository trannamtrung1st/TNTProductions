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
	public partial interface ILanguageValueService : IBaseService<LanguageValue, LanguageValueViewModel, int>
	{
	}
	
	public partial class LanguageValueService : BaseService<LanguageValue, LanguageValueViewModel, int>, ILanguageValueService
	{
		public LanguageValueService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageValueRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public LanguageValueService()
		{
			repository = G.TContainer.Resolve<ILanguageValueRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~LanguageValueService()
		{
			Dispose(false);
		}
		#endregion
	}
}
