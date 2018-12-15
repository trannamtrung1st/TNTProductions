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
	public partial class OrderDetailViewModel: BaseViewModel<OrderDetail>
	{
		[JsonProperty("order_detail_id")]
		public int OrderDetailID { get; set; }
		[JsonProperty("rent_id")]
		public int RentID { get; set; }
		[JsonProperty("product_id")]
		public int ProductID { get; set; }
		[JsonProperty("total_amount")]
		public double TotalAmount { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("order_date")]
		public DateTime OrderDate { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("final_amount")]
		public double FinalAmount { get; set; }
		[JsonProperty("is_addition")]
		public bool IsAddition { get; set; }
		[JsonProperty("detail_description")]
		public string DetailDescription { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("tax_percent")]
		public Nullable<double> TaxPercent { get; set; }
		[JsonProperty("tax_value")]
		public Nullable<double> TaxValue { get; set; }
		[JsonProperty("unit_price")]
		public double UnitPrice { get; set; }
		[JsonProperty("product_type")]
		public Nullable<int> ProductType { get; set; }
		[JsonProperty("parent_id")]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("product_order_type")]
		public Nullable<int> ProductOrderType { get; set; }
		[JsonProperty("item_quantity")]
		public int ItemQuantity { get; set; }
		[JsonProperty("tmp_detail_id")]
		public Nullable<int> TmpDetailId { get; set; }
		[JsonProperty("order_detail_promotion_mapping_id")]
		public Nullable<int> OrderDetailPromotionMappingId { get; set; }
		[JsonProperty("order_promotion_mapping_id")]
		public Nullable<int> OrderPromotionMappingId { get; set; }
		[JsonProperty("order_detail_att1")]
		public string OrderDetailAtt1 { get; set; }
		[JsonProperty("order_detail_att2")]
		public string OrderDetailAtt2 { get; set; }
		//[JsonProperty("order")]
		//public OrderViewModel OrderVM { get; set; }
		//[JsonProperty("order_detail2")]
		//public OrderDetailViewModel OrderDetail2VM { get; set; }
		//[JsonProperty("order_detail_promotion_mapping")]
		//public OrderDetailPromotionMappingViewModel OrderDetailPromotionMappingVM { get; set; }
		//[JsonProperty("order_promotion_mapping")]
		//public OrderPromotionMappingViewModel OrderPromotionMappingVM { get; set; }
		//[JsonProperty("product")]
		//public ProductViewModel ProductVM { get; set; }
		//[JsonProperty("order_detail1")]
		//public IEnumerable<OrderDetailViewModel> OrderDetail1VM { get; set; }
		//[JsonProperty("order_detail_promotion_mappings")]
		//public IEnumerable<OrderDetailPromotionMappingViewModel> OrderDetailPromotionMappingsVM { get; set; }
		
		public OrderDetailViewModel(OrderDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderDetailViewModel()
		{
			//this.OrderDetail1VM = new HashSet<OrderDetailViewModel>();
			//this.OrderDetailPromotionMappingsVM = new HashSet<OrderDetailPromotionMappingViewModel>();
		}
		
	}
}
