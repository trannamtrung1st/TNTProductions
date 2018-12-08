﻿using System;
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
	public partial interface ILanguageValueService : IBaseService<LanguageValue, int>
	{
	}
	
	public partial class LanguageValueService : BaseService<LanguageValue, int>, ILanguageValueService
	{
		public LanguageValueService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ILanguageValueRepository>(uow);
		}
		
		public LanguageValueService(DbContext context)
		{
			repository = G.TContainer.Resolve<ILanguageValueRepository>(context);
		}
		
	}
}
