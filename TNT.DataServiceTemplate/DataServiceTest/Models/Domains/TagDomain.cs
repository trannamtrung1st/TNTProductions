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
	public partial class TagDomain : BaseDomain<Models.Tag, TagViewModel, int, ITagService>
	{
		public TagDomain() : base()
		{
		}
		public TagDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
