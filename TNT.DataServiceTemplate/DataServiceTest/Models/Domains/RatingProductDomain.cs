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
	public partial class RatingProductDomain : BaseDomain<Models.RatingProduct, RatingProductViewModel, int, IRatingProductService>
	{
		public RatingProductDomain() : base()
		{
		}
		public RatingProductDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
