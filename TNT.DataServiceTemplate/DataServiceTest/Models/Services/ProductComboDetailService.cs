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
	public partial interface IProductComboDetailService : IBaseService<ProductComboDetail, ProductComboDetailViewModel, ProductComboDetailPK>
	{
	}
	
	public partial class ProductComboDetailService : BaseService<ProductComboDetail, ProductComboDetailViewModel, ProductComboDetailPK>, IProductComboDetailService
	{
		public ProductComboDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductComboDetailRepository>(uow);
		}
		
		
		#region Implement for Resource Pooling
		public ProductComboDetailService()
		{
			repository = G.TContainer.Resolve<IProductComboDetailRepository>();
		}
		
		//params order: 0/ uow
		
		public override void ReInit(params object[] initParams)
		{
			base.ReInit(initParams);
			repository.ReInit(initParams);
		}
		
		~ProductComboDetailService()
		{
			Dispose(false);
		}
		#endregion
	}
}
