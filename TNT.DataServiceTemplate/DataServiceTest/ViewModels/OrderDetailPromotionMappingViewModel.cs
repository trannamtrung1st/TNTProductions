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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("order_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OrderDetailId { get; set; }
		[JsonProperty("promotion_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PromotionId { get; set; }
		[JsonProperty("promotion_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionDetailId { get; set; }
		[JsonProperty("discount_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public decimal DiscountAmount { get; set; }
		[JsonProperty("discount_rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> DiscountRate { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("mapping_index", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int MappingIndex { get; set; }
		[JsonProperty("tmp_mapping_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TmpMappingId { get; set; }
		[JsonProperty("order_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderDetailViewModel OrderDetailVM { get; set; }
		[JsonProperty("promotion", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("order_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderDetailViewModel> OrderDetailsVM { get; set; }
		
		public OrderDetailPromotionMappingViewModel(OrderDetailPromotionMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderDetailPromotionMappingViewModel()
		{
			this.OrderDetailsVM = new HashSet<OrderDetailViewModel>();
		}
		
	}
}
