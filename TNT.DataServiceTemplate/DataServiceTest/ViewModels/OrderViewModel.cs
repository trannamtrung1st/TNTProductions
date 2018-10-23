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
	public partial class OrderViewModel: BaseViewModel<Order>
	{
		[JsonProperty("rentID")]
		public int RentID { get; set; }
		[JsonProperty("invoiceID")]
		public string InvoiceID { get; set; }
		[JsonProperty("checkInDate")]
		public Nullable<DateTime> CheckInDate { get; set; }
		[JsonProperty("checkOutDate")]
		public Nullable<DateTime> CheckOutDate { get; set; }
		[JsonProperty("approveDate")]
		public Nullable<DateTime> ApproveDate { get; set; }
		[JsonProperty("totalAmount")]
		public double TotalAmount { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("discountOrderDetail")]
		public double DiscountOrderDetail { get; set; }
		[JsonProperty("finalAmount")]
		public double FinalAmount { get; set; }
		[JsonProperty("orderStatus")]
		public int OrderStatus { get; set; }
		[JsonProperty("rentStatus")]
		public Nullable<int> RentStatus { get; set; }
		[JsonProperty("orderType")]
		public int OrderType { get; set; }
		[JsonProperty("rentType")]
		public int RentType { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("feeDescription")]
		public string FeeDescription { get; set; }
		[JsonProperty("checkInPerson")]
		public string CheckInPerson { get; set; }
		[JsonProperty("checkOutPerson")]
		public string CheckOutPerson { get; set; }
		[JsonProperty("approvePerson")]
		public string ApprovePerson { get; set; }
		[JsonProperty("priceGroupID")]
		public Nullable<int> PriceGroupID { get; set; }
		[JsonProperty("bookingDate")]
		public Nullable<DateTime> BookingDate { get; set; }
		[JsonProperty("arrivalDate")]
		public Nullable<DateTime> ArrivalDate { get; set; }
		[JsonProperty("departureDate")]
		public Nullable<DateTime> DepartureDate { get; set; }
		[JsonProperty("customerID")]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("subRentGroupID")]
		public Nullable<int> SubRentGroupID { get; set; }
		[JsonProperty("roomId")]
		public Nullable<int> RoomId { get; set; }
		[JsonProperty("isFixedPrice")]
		public bool IsFixedPrice { get; set; }
		[JsonProperty("lastRecordDate")]
		public Nullable<DateTime> LastRecordDate { get; set; }
		[JsonProperty("servedPerson")]
		public string ServedPerson { get; set; }
		[JsonProperty("storeID")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("sourceID")]
		public Nullable<int> SourceID { get; set; }
		[JsonProperty("sourceType")]
		public int SourceType { get; set; }
		[JsonProperty("deliveryAddress")]
		public string DeliveryAddress { get; set; }
		[JsonProperty("deliveryStatus")]
		public Nullable<int> DeliveryStatus { get; set; }
		[JsonProperty("orderDetailsTotalQuantity")]
		public Nullable<int> OrderDetailsTotalQuantity { get; set; }
		[JsonProperty("checkinHour")]
		public Nullable<int> CheckinHour { get; set; }
		[JsonProperty("totalInvoicePrint")]
		public Nullable<int> TotalInvoicePrint { get; set; }
		[JsonProperty("vAT")]
		public Nullable<double> VAT { get; set; }
		[JsonProperty("vATAmount")]
		public Nullable<double> VATAmount { get; set; }
		[JsonProperty("numberOfGuest")]
		public Nullable<int> NumberOfGuest { get; set; }
		[JsonProperty("att1")]
		public string Att1 { get; set; }
		[JsonProperty("att2")]
		public string Att2 { get; set; }
		[JsonProperty("att3")]
		public string Att3 { get; set; }
		[JsonProperty("att4")]
		public string Att4 { get; set; }
		[JsonProperty("att5")]
		public string Att5 { get; set; }
		[JsonProperty("groupPaymentStatus")]
		public int GroupPaymentStatus { get; set; }
		[JsonProperty("deliveryReceiver")]
		public string DeliveryReceiver { get; set; }
		[JsonProperty("deliveryPhone")]
		public string DeliveryPhone { get; set; }
		[JsonProperty("lastModifiedPayment")]
		public Nullable<DateTime> LastModifiedPayment { get; set; }
		[JsonProperty("lastModifiedOrderDetail")]
		public Nullable<DateTime> LastModifiedOrderDetail { get; set; }
		[JsonProperty("paymentStatus")]
		public Nullable<int> PaymentStatus { get; set; }
		[JsonProperty("deliveryType")]
		public Nullable<int> DeliveryType { get; set; }
		[JsonProperty("deliveryPayment")]
		public Nullable<int> DeliveryPayment { get; set; }
		[JsonProperty("invoiceStatus")]
		public Nullable<int> InvoiceStatus { get; set; }
		[JsonProperty("wardCode")]
		public Nullable<int> WardCode { get; set; }
		[JsonProperty("districtCode")]
		public Nullable<int> DistrictCode { get; set; }
		[JsonProperty("provinceCode")]
		public Nullable<int> ProvinceCode { get; set; }
		[JsonProperty("promotionPartnerId")]
		public Nullable<int> PromotionPartnerId { get; set; }
		[JsonProperty("memberPoint")]
		public Nullable<double> MemberPoint { get; set; }
		[JsonProperty("receiver")]
		public string Receiver { get; set; }
		[JsonProperty("isSync")]
		public Nullable<bool> isSync { get; set; }
		[JsonProperty("isExported")]
		public bool IsExported { get; set; }
		[JsonProperty("customerTypeId")]
		public Nullable<int> CustomerTypeId { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("district")]
		public DistrictViewModel DistrictVM { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("ward")]
		public WardViewModel WardVM { get; set; }
		[JsonProperty("orderDetails")]
		public ICollection<OrderDetailViewModel> OrderDetailsVM { get; set; }
		[JsonProperty("orderFeeItems")]
		public ICollection<OrderFeeItemViewModel> OrderFeeItemsVM { get; set; }
		[JsonProperty("orderPromotionMappings")]
		public ICollection<OrderPromotionMappingViewModel> OrderPromotionMappingsVM { get; set; }
		[JsonProperty("payments")]
		public ICollection<PaymentViewModel> PaymentsVM { get; set; }
		[JsonProperty("vATOrderMappings")]
		public ICollection<VATOrderMappingViewModel> VATOrderMappingsVM { get; set; }
		
		public OrderViewModel(Order entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderViewModel()
		{
			this.OrderDetailsVM = new HashSet<OrderDetailViewModel>();
			this.OrderFeeItemsVM = new HashSet<OrderFeeItemViewModel>();
			this.OrderPromotionMappingsVM = new HashSet<OrderPromotionMappingViewModel>();
			this.PaymentsVM = new HashSet<PaymentViewModel>();
			this.VATOrderMappingsVM = new HashSet<VATOrderMappingViewModel>();
		}
		
	}
}
