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
		[JsonProperty("order_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OrderDetailID { get; set; }
		[JsonProperty("rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RentID { get; set; }
		[JsonProperty("product_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProductID { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalAmount { get; set; }
		[JsonProperty("quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Quantity { get; set; }
		[JsonProperty("order_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime OrderDate { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Status { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double FinalAmount { get; set; }
		[JsonProperty("is_addition", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsAddition { get; set; }
		[JsonProperty("detail_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DetailDescription { get; set; }
		[JsonProperty("discount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Discount { get; set; }
		[JsonProperty("tax_percent", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TaxPercent { get; set; }
		[JsonProperty("tax_value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> TaxValue { get; set; }
		[JsonProperty("unit_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double UnitPrice { get; set; }
		[JsonProperty("product_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProductType { get; set; }
		[JsonProperty("parent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("product_order_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProductOrderType { get; set; }
		[JsonProperty("item_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ItemQuantity { get; set; }
		[JsonProperty("tmp_detail_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TmpDetailId { get; set; }
		[JsonProperty("order_detail_promotion_mapping_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderDetailPromotionMappingId { get; set; }
		[JsonProperty("order_promotion_mapping_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderPromotionMappingId { get; set; }
		[JsonProperty("order_detail_att1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string OrderDetailAtt1 { get; set; }
		[JsonProperty("order_detail_att2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string OrderDetailAtt2 { get; set; }
		[JsonProperty("order", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("order_detail2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderDetailViewModel OrderDetail2VM { get; set; }
		[JsonProperty("order_detail_promotion_mapping", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderDetailPromotionMappingViewModel OrderDetailPromotionMappingVM { get; set; }
		[JsonProperty("order_promotion_mapping", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public OrderPromotionMappingViewModel OrderPromotionMappingVM { get; set; }
		[JsonProperty("product", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("order_detail1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderDetailViewModel> OrderDetail1VM { get; set; }
		[JsonProperty("order_detail_promotion_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderDetailPromotionMappingViewModel> OrderDetailPromotionMappingsVM { get; set; }
		
		public OrderDetailViewModel(OrderDetail entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderDetailViewModel()
		{
			this.OrderDetail1VM = new HashSet<OrderDetailViewModel>();
			this.OrderDetailPromotionMappingsVM = new HashSet<OrderDetailPromotionMappingViewModel>();
		}
		
	}
}
