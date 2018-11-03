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
	public partial class ImageCollectionItemViewModel: BaseViewModel<ImageCollectionItem>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("image_collection_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ImageCollectionId { get; set; }
		[JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Title { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("link", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Link { get; set; }
		[JsonProperty("image_collection", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ImageCollectionViewModel ImageCollectionVM { get; set; }
		
		public ImageCollectionItemViewModel(ImageCollectionItem entity) : this()
		{
			FromEntity(entity);
		}
		
		public ImageCollectionItemViewModel()
		{
		}
		
	}
}
