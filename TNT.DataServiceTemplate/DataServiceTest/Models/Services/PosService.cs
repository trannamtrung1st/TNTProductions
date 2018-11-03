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
	public partial interface IPosService : IBaseService<Pos, PosViewModel, int>
	{
	}
	
	public partial class PosService : BaseService<Pos, PosViewModel, int>, IPosService
	{
		public PosService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IPosRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public PosService()
		{
			repository = G.TContainer.Resolve<IPosRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~PosService()
		{
			Dispose(false);
		}
		#endregion
	}
}
