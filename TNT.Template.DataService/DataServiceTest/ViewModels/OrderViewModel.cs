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
		[JsonProperty("rent_id")]
		public int RentID { get; set; }
		[JsonProperty("invoice_id")]
		public string InvoiceID { get; set; }
		[JsonProperty("check_in_date")]
		public Nullable<DateTime> CheckInDate { get; set; }
		[JsonProperty("check_out_date")]
		public Nullable<DateTime> CheckOutDate { get; set; }
		[JsonProperty("approve_date")]
		public Nullable<DateTime> ApproveDate { get; set; }
		[JsonProperty("total_amount")]
		public double TotalAmount { get; set; }
		[JsonProperty("discount")]
		public double Discount { get; set; }
		[JsonProperty("discount_order_detail")]
		public double DiscountOrderDetail { get; set; }
		[JsonProperty("final_amount")]
		public double FinalAmount { get; set; }
		[JsonProperty("order_status")]
		public int OrderStatus { get; set; }
		[JsonProperty("rent_status")]
		public Nullable<int> RentStatus { get; set; }
		[JsonProperty("order_type")]
		public int OrderType { get; set; }
		[JsonProperty("rent_type")]
		public int RentType { get; set; }
		[JsonProperty("notes")]
		public string Notes { get; set; }
		[JsonProperty("fee_description")]
		public string FeeDescription { get; set; }
		[JsonProperty("check_in_person")]
		public string CheckInPerson { get; set; }
		[JsonProperty("check_out_person")]
		public string CheckOutPerson { get; set; }
		[JsonProperty("approve_person")]
		public string ApprovePerson { get; set; }
		[JsonProperty("price_group_id")]
		public Nullable<int> PriceGroupID { get; set; }
		[JsonProperty("booking_date")]
		public Nullable<DateTime> BookingDate { get; set; }
		[JsonProperty("arrival_date")]
		public Nullable<DateTime> ArrivalDate { get; set; }
		[JsonProperty("departure_date")]
		public Nullable<DateTime> DepartureDate { get; set; }
		[JsonProperty("customer_id")]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("sub_rent_group_id")]
		public Nullable<int> SubRentGroupID { get; set; }
		[JsonProperty("room_id")]
		public Nullable<int> RoomId { get; set; }
		[JsonProperty("is_fixed_price")]
		public bool IsFixedPrice { get; set; }
		[JsonProperty("last_record_date")]
		public Nullable<DateTime> LastRecordDate { get; set; }
		[JsonProperty("served_person")]
		public string ServedPerson { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("source_id")]
		public Nullable<int> SourceID { get; set; }
		[JsonProperty("source_type")]
		public int SourceType { get; set; }
		[JsonProperty("delivery_address")]
		public string DeliveryAddress { get; set; }
		[JsonProperty("delivery_status")]
		public Nullable<int> DeliveryStatus { get; set; }
		[JsonProperty("order_details_total_quantity")]
		public Nullable<int> OrderDetailsTotalQuantity { get; set; }
		[JsonProperty("checkin_hour")]
		public Nullable<int> CheckinHour { get; set; }
		[JsonProperty("total_invoice_print")]
		public Nullable<int> TotalInvoicePrint { get; set; }
		[JsonProperty("vat")]
		public Nullable<double> VAT { get; set; }
		[JsonProperty("vatamount")]
		public Nullable<double> VATAmount { get; set; }
		[JsonProperty("number_of_guest")]
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
		[JsonProperty("group_payment_status")]
		public int GroupPaymentStatus { get; set; }
		[JsonProperty("delivery_receiver")]
		public string DeliveryReceiver { get; set; }
		[JsonProperty("delivery_phone")]
		public string DeliveryPhone { get; set; }
		[JsonProperty("last_modified_payment")]
		public Nullable<DateTime> LastModifiedPayment { get; set; }
		[JsonProperty("last_modified_order_detail")]
		public Nullable<DateTime> LastModifiedOrderDetail { get; set; }
		[JsonProperty("payment_status")]
		public Nullable<int> PaymentStatus { get; set; }
		[JsonProperty("delivery_type")]
		public Nullable<int> DeliveryType { get; set; }
		[JsonProperty("delivery_payment")]
		public Nullable<int> DeliveryPayment { get; set; }
		[JsonProperty("invoice_status")]
		public Nullable<int> InvoiceStatus { get; set; }
		[JsonProperty("ward_code")]
		public Nullable<int> WardCode { get; set; }
		[JsonProperty("district_code")]
		public Nullable<int> DistrictCode { get; set; }
		[JsonProperty("province_code")]
		public Nullable<int> ProvinceCode { get; set; }
		[JsonProperty("promotion_partner_id")]
		public Nullable<int> PromotionPartnerId { get; set; }
		[JsonProperty("member_point")]
		public Nullable<double> MemberPoint { get; set; }
		[JsonProperty("receiver")]
		public string Receiver { get; set; }
		[JsonProperty("is_sync")]
		public Nullable<bool> isSync { get; set; }
		[JsonProperty("is_exported")]
		public bool IsExported { get; set; }
		[JsonProperty("customer_type_id")]
		public Nullable<int> CustomerTypeId { get; set; }
		//[JsonProperty("customer")]
		//public CustomerViewModel CustomerVM { get; set; }
		//[JsonProperty("district")]
		//public DistrictViewModel DistrictVM { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("ward")]
		//public WardViewModel WardVM { get; set; }
		//[JsonProperty("order_details")]
		//public IEnumerable<OrderDetailViewModel> OrderDetailsVM { get; set; }
		//[JsonProperty("order_fee_items")]
		//public IEnumerable<OrderFeeItemViewModel> OrderFeeItemsVM { get; set; }
		//[JsonProperty("order_promotion_mappings")]
		//public IEnumerable<OrderPromotionMappingViewModel> OrderPromotionMappingsVM { get; set; }
		//[JsonProperty("payments")]
		//public IEnumerable<PaymentViewModel> PaymentsVM { get; set; }
		//[JsonProperty("vatorder_mappings")]
		//public IEnumerable<VATOrderMappingViewModel> VATOrderMappingsVM { get; set; }
		
		public OrderViewModel(Order entity) : this()
		{
			FromEntity(entity);
		}
		
		public OrderViewModel()
		{
			//this.OrderDetailsVM = new HashSet<OrderDetailViewModel>();
			//this.OrderFeeItemsVM = new HashSet<OrderFeeItemViewModel>();
			//this.OrderPromotionMappingsVM = new HashSet<OrderPromotionMappingViewModel>();
			//this.PaymentsVM = new HashSet<PaymentViewModel>();
			//this.VATOrderMappingsVM = new HashSet<VATOrderMappingViewModel>();
		}
		
	}
}
