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
	public partial class CategoryExtraMappingDomain : BaseDomain<Models.CategoryExtraMapping, CategoryExtraMappingViewModel, int, ICategoryExtraMappingService>
	{
		public CategoryExtraMappingDomain() : base()
		{
		}
		public CategoryExtraMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
