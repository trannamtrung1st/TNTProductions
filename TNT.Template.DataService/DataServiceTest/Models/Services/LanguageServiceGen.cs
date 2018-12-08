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
	public partial interface ILanguageService : IBaseService<Language, int>
	{
	}
	
	public partial class LanguageService : BaseService<Language, int>, ILanguageService
	{
		public LanguageService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageRepository>(uow);
		}
		
		public LanguageService(DbContext context)
		{
			repository = G.TContainer.Resolve<ILanguageRepository>(context);
		}
		
	}
}
