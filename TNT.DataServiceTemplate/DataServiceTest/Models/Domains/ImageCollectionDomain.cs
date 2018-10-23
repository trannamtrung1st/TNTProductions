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
	public partial class ImageCollectionDomain : BaseDomain<Models.ImageCollection, ImageCollectionViewModel, int, IImageCollectionService>
	{
		public ImageCollectionDomain() : base()
		{
		}
		public ImageCollectionDomain(IUnitOfWork uow) : base(uow)
		{
		}
	}
	
}
