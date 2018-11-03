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
	public partial interface ITagService : IBaseService<Tag, TagViewModel, int>
	{
	}
	
	public partial class TagService : BaseService<Tag, TagViewModel, int>, ITagService
	{
		public TagService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<ITagRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public TagService()
		{
			repository = G.TContainer.Resolve<ITagRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~TagService()
		{
			Dispose(false);
		}
		#endregion
	}
}
