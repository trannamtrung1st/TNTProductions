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
	public partial class RatingProductViewModel: BaseViewModel<RatingProduct>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserId { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductId { get; set; }
		[JsonProperty("create_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreateTime { get; set; }
		[JsonProperty("star", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Star { get; set; }
		[JsonProperty("review_content", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ReviewContent { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		
		public RatingProductViewModel(RatingProduct entity) : this()
		{
			FromEntity(entity);
		}
		
		public RatingProductViewModel()
		{
		}
		
	}
}
