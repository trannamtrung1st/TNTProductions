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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("image_collection_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ImageCollectionItemViewModel> ImageCollectionItemsVM { get; set; }
		
		public ImageCollectionViewModel(ImageCollection entity) : this()
		{
			FromEntity(entity);
		}
		
		public ImageCollectionViewModel()
		{
			this.ImageCollectionItemsVM = new HashSet<ImageCollectionItemViewModel>();
		}
		
	}
}
