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
	public partial class RatingStarViewModel: BaseViewModel<RatingStar>
	{
		[JsonProperty("id")]
		public int ID { get; set; }
		[JsonProperty("product_id")]
		public int ProductID { get; set; }
		[JsonProperty("user_id")]
		public string UserID { get; set; }
		[JsonProperty("rate")]
		public Nullable<int> Rate { get; set; }
		//[JsonProperty("product")]
		//public ProductViewModel ProductVM { get; set; }
		
		public RatingStarViewModel(RatingStar entity) : this()
		{
			FromEntity(entity);
		}
		
		public RatingStarViewModel()
		{
		}
		
	}
}
