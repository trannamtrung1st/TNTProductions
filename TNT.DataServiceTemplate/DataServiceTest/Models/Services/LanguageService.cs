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
	public partial interface ILanguageService : IBaseService<Language, LanguageViewModel, int>
	{
	}
	
	public partial class LanguageService : BaseService<Language, LanguageViewModel, int>, ILanguageService
	{
		public LanguageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public LanguageService()
		{
			repository = G.TContainer.Resolve<ILanguageRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~LanguageService()
		{
			Dispose(false);
		}
		#endregion
	}
}
