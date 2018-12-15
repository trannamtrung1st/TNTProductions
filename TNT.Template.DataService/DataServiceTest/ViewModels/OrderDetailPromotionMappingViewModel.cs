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
	public partial class OrderDetailPromotionMappingViewModel: BaseViewModel<OrderDetailPromotionMapping>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("order_detail_id")]
		public int OrderDetailId { get; set; }
		[JsonProperty("promotion_id")]
		public int PromotionId { get; set; }
		[JsonProperty("promotion_detail_id")]
		public Nullable<int> PromotionDetailId { get; set; }
		[JsonProperty("discount_amount")]
		public decimal DiscountAmount { get; set; }
		[JsonProperty("discount_rate")]
		public Nullable<double> DiscountRate { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("mapping_index")]
		public int MappingIndex { get; set; }
		[JsonProperty("tmp_mapping_id")]
		public Nullable<int> TmpMappingId { get; set; }
		//[JsonProperty("order_detail")]
		//public OrderDetailViewModel OrderDetailVM { get; set; }
		//[JsonProperty("promotion")]
		//public PromotionViewModel PromotionVM { get; set; }
		//[JsonProperty("order_details")]
		//public IEnumerable<OrderDetailViewModel> OrderDetailsVM { get; set; }
		
		public OrderDetailPromotionMappingViewModel(OrderDetailPromotionMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderDetailPromotionMappingViewModel()
		{
			//this.OrderDetailsVM = new HashSet<OrderDetailViewModel>();
		}
		
	}
}
