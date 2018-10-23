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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("userId")]
		public string UserId { get; set; }
		[JsonProperty("productId")]
		public int ProductId { get; set; }
		[JsonProperty("createTime")]
		public DateTime CreateTime { get; set; }
		[JsonProperty("star")]
		public int Star { get; set; }
		[JsonProperty("reviewContent")]
		public string ReviewContent { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("product")]
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
