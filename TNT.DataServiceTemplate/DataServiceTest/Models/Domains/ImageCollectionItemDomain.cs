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
	public partial class ImageCollectionItemDomain : BaseDomain<Models.ImageCollectionItem, ImageCollectionItemViewModel, int, IImageCollectionItemService>
	{
		public ImageCollectionItemDomain() : base()
		{
		}
		public ImageCollectionItemDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
