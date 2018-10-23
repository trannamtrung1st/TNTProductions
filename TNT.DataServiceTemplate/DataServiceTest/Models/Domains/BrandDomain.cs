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
	public partial class BrandDomain : BaseDomain<Models.Brand, BrandViewModel, int, IBrandService>
	{
		public BrandDomain() : base()
		{
		}
		public BrandDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
