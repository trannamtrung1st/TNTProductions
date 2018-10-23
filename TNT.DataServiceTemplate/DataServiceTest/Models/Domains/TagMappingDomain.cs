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
	public partial class TagMappingDomain : BaseDomain<Models.TagMapping, TagMappingViewModel, int, ITagMappingService>
	{
		public TagMappingDomain() : base()
		{
		}
		public TagMappingDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
