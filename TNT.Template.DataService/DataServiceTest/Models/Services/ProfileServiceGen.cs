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
	public partial interface IProfileService : IBaseService<Profile, System.Guid>
	{
	}
	
	public partial class ProfileService : BaseService<Profile, System.Guid>, IProfileService
	{
		public ProfileService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProfileRepository>(uow);
		}
		
		public ProfileService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProfileRepository>(context);
		}
		
	}
}
