using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Models.Services;
using DataServiceTest.Managers;
using DataServiceTest.Models;

namespace DataServiceTest.Models.Domains
{
	public partial class ProductComboDetailDomain : BaseDomain<Models.ProductComboDetail, ProductComboDetailViewModel, ProductComboDetailPK, IProductComboDetailService>
	{
		public ProductComboDetailDomain() : base()
		{
		}
		public ProductComboDetailDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
