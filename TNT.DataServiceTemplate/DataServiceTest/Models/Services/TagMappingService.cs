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
	public partial interface ITagMappingService : IBaseService<TagMapping, TagMappingViewModel, int>
	{
	}
	
	public partial class TagMappingService : BaseService<TagMapping, TagMappingViewModel, int>, ITagMappingService
	{
		public TagMappingService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITagMappingRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public TagMappingService()
		{
			repository = G.TContainer.Resolve<ITagMappingRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TagMappingService()
		{
			Dispose(false);
		}
		#endregion
	}
}
