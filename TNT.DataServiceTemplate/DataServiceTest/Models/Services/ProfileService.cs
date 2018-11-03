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
	public partial interface IProfileService : IBaseService<Profile, ProfileViewModel, System.Guid>
	{
	}
	
	public partial class ProfileService : BaseService<Profile, ProfileViewModel, System.Guid>, IProfileService
	{
		public ProfileService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProfileRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProfileService()
		{
			repository = G.TContainer.Resolve<IProfileRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProfileService()
		{
			Dispose(false);
		}
		#endregion
	}
}
