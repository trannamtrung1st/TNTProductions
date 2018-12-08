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
	public partial interface IProductComboDetailService : IBaseService<ProductComboDetail, ProductComboDetailPK>
	{
	}
	
	public partial class ProductComboDetailService : BaseService<ProductComboDetail, ProductComboDetailPK>, IProductComboDetailService
	{
		public ProductComboDetailService(IUnitOfWork uow)
		{
			repository = uow.Scope.Resolve<IProductComboDetailRepository>(uow);
		}
		
		public ProductComboDetailService(DbContext context)
		{
			repository = G.TContainer.Resolve<IProductComboDetailRepository>(context);
		}
		
	}
}
