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
	public partial interface ITagMappingService : IBaseService<TagMapping, int>
	{
	}
	
	public partial class TagMappingService : BaseService<TagMapping, int>, ITagMappingService
	{
		public TagMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITagMappingRepository>(uow);
		}
		
		public TagMappingService(DbContext context)
		{
			repository = G.TContainer.Resolve<ITagMappingRepository>(context);
		}
		
	}
}
