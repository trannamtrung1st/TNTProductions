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
	public partial interface ILanguageKeyService : IBaseService<LanguageKey, LanguageKeyViewModel, int>
	{
	}
	
	public partial class LanguageKeyService : BaseService<LanguageKey, LanguageKeyViewModel, int>, ILanguageKeyService
	{
		public LanguageKeyService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageKeyRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public LanguageKeyService()
		{
			repository = G.TContainer.Resolve<ILanguageKeyRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~LanguageKeyService()
		{
			Dispose(false);
		}
		#endregion
	}
}
