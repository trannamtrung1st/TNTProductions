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
	public partial interface IPosFileService : IBaseService<PosFile, PosFileViewModel, int>
	{
	}
	
	public partial class PosFileService : BaseService<PosFile, PosFileViewModel, int>, IPosFileService
	{
		public PosFileService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPosFileRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PosFileService()
		{
			repository = G.TContainer.Resolve<IPosFileRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PosFileService()
		{
			Dispose(false);
		}
		#endregion
	}
}
