using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.ViewModels;
using DataServiceTest.Global;

namespace DataServiceTest.Models
{
	public partial class ImageCollectionItem : BaseEntity<ImageCollectionItemViewModel>
	{
		public override ImageCollectionItemViewModel ToViewModel()
		{
			return new ImageCollectionItemViewModel(this);
		}
		
	}
}
