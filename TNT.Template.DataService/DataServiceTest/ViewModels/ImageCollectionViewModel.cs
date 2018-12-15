using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Global;
using DataServiceTest.Models;
using Newtonsoft.Json;

namespace DataServiceTest.ViewModels
{
	public partial class ImageCollectionViewModel: BaseViewModel<ImageCollection>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("image_collection_items")]
		//public IEnumerable<ImageCollectionItemViewModel> ImageCollectionItemsVM { get; set; }
		
		public ImageCollectionViewModel(ImageCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public ImageCollectionViewModel()
		{
			//this.ImageCollectionItemsVM = new HashSet<ImageCollectionItemViewModel>();
		}
		
	}
}
