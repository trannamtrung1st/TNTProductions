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
	public partial class FavoritedViewModel: BaseViewModel<Favorited>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserID { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductID { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("favorite_stt", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> FavoriteStt { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		
		public FavoritedViewModel(Favorited entity) : this()
		{
			FromEntity(entity);
		}
		
		public FavoritedViewModel()
		{
		}
		
	}
}
