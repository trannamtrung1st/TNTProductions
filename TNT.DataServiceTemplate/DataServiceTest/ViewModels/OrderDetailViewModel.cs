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
		[JsonProperty("orderDetailID")]
		public int OrderDetailID { get; set; }
		[JsonProperty("rentID")]
		public int RentID { get; set; }
		[JsonProperty("productID")]
		public int ProductID { get; set; }
		[JsonProperty("totalAmount")]
		public double TotalAmount { get; set; }
		[JsonProperty("quantity")]
		public int Quantity { get; set; }
		[JsonProperty("orderDate")]
		public DateTime OrderDate { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("finalAmount")]
		public double FinalAmount { get; set; }
		[JsonProperty("isAddition")]
		public bool IsAddition { get; set; }
		[JsonProperty("detailDescription")]
		public string DetailDescription { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("taxPercent")]
		public Nullable<double> TaxPercent { get; set; }
		[JsonProperty("taxValue")]
		public Nullable<double> TaxValue { get; set; }
		[JsonProperty("unitPrice")]
		public double UnitPrice { get; set; }
		[JsonProperty("productType")]
		public Nullable<int> ProductType { get; set; }
		[JsonProperty("parentId")]
		public Nullable<int> ParentId { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("productOrderType")]
		public Nullable<int> ProductOrderType { get; set; }
		[JsonProperty("itemQuantity")]
		public int ItemQuantity { get; set; }
		[JsonProperty("tmpDetailId")]
		public Nullable<int> TmpDetailId { get; set; }
		[JsonProperty("orderDetailPromotionMappingId")]
		public Nullable<int> OrderDetailPromotionMappingId { get; set; }
		[JsonProperty("orderPromotionMappingId")]
		public Nullable<int> OrderPromotionMappingId { get; set; }
		[JsonProperty("orderDetailAtt1")]
		public string OrderDetailAtt1 { get; set; }
		[JsonProperty("orderDetailAtt2")]
		public string OrderDetailAtt2 { get; set; }
		[JsonProperty("order")]
		public OrderViewModel OrderVM { get; set; }
		[JsonProperty("orderDetail2")]
		public OrderDetailViewModel OrderDetail2VM { get; set; }
		[JsonProperty("orderDetailPromotionMapping")]
		public OrderDetailPromotionMappingViewModel OrderDetailPromotionMappingVM { get; set; }
		[JsonProperty("orderPromotionMapping")]
		public OrderPromotionMappingViewModel OrderPromotionMappingVM { get; set; }
		[JsonProperty("product")]
		public ProductViewModel ProductVM { get; set; }
		[JsonProperty("orderDetail1")]
		public ICollection<OrderDetailViewModel> OrderDetail1VM { get; set; }
		[JsonProperty("orderDetailPromotionMappings")]
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
