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
	public partial class OrderPromotionMappingViewModel: BaseViewModel<OrderPromotionMapping>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("orderId")]
		public int OrderId { get; set; }
		[JsonProperty("promotionId")]
		public int PromotionId { get; set; }
		[JsonProperty("promotionDetailId")]
		public Nullable<int> PromotionDetailId { get; set; }
		[JsonProperty("discountAmount")]
		public decimal DiscountAmount { get; set; }
		[JsonProperty("discountRate")]
		public Nullable<double> DiscountRate { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("mappingIndex")]
		public int MappingIndex { get; set; }
		[JsonProperty("tmpMappingId")]
		public Nullable<int> TmpMappingId { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("promotion")]
		public PromotionViewModel PromotionVM { get; set; }
		[JsonProperty("orderDetails")]
		public ICollection<OrderDetailViewModel> OrderDetailsVM { get; set; }
		
		public OrderPromotionMappingViewModel(OrderPromotionMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderPromotionMappingViewModel()
		{
			this.OrderDetailsVM = new HashSet<OrderDetailViewModel>();
		}
		
	}
}
