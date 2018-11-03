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
		[JsonProperty("rent_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RentID { get; set; }
		[JsonProperty("invoice_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string InvoiceID { get; set; }
		[JsonProperty("check_in_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CheckInDate { get; set; }
		[JsonProperty("check_out_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> CheckOutDate { get; set; }
		[JsonProperty("approve_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ApproveDate { get; set; }
		[JsonProperty("total_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double TotalAmount { get; set; }
		[JsonProperty("discount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double Discount { get; set; }
		[JsonProperty("discount_order_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double DiscountOrderDetail { get; set; }
		[JsonProperty("final_amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public double FinalAmount { get; set; }
		[JsonProperty("order_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OrderStatus { get; set; }
		[JsonProperty("rent_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RentStatus { get; set; }
		[JsonProperty("order_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int OrderType { get; set; }
		[JsonProperty("rent_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int RentType { get; set; }
		[JsonProperty("notes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Notes { get; set; }
		[JsonProperty("fee_description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string FeeDescription { get; set; }
		[JsonProperty("check_in_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CheckInPerson { get; set; }
		[JsonProperty("check_out_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CheckOutPerson { get; set; }
		[JsonProperty("approve_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ApprovePerson { get; set; }
		[JsonProperty("price_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PriceGroupID { get; set; }
		[JsonProperty("booking_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> BookingDate { get; set; }
		[JsonProperty("arrival_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> ArrivalDate { get; set; }
		[JsonProperty("departure_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> DepartureDate { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerID { get; set; }
		[JsonProperty("sub_rent_group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SubRentGroupID { get; set; }
		[JsonProperty("room_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> RoomId { get; set; }
		[JsonProperty("is_fixed_price", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsFixedPrice { get; set; }
		[JsonProperty("last_record_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LastRecordDate { get; set; }
		[JsonProperty("served_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ServedPerson { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreID { get; set; }
		[JsonProperty("source_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> SourceID { get; set; }
		[JsonProperty("source_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int SourceType { get; set; }
		[JsonProperty("delivery_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DeliveryAddress { get; set; }
		[JsonProperty("delivery_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DeliveryStatus { get; set; }
		[JsonProperty("order_details_total_quantity", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> OrderDetailsTotalQuantity { get; set; }
		[JsonProperty("checkin_hour", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CheckinHour { get; set; }
		[JsonProperty("total_invoice_print", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TotalInvoicePrint { get; set; }
		[JsonProperty("vat", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> VAT { get; set; }
		[JsonProperty("vatamount", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> VATAmount { get; set; }
		[JsonProperty("number_of_guest", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> NumberOfGuest { get; set; }
		[JsonProperty("att1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att1 { get; set; }
		[JsonProperty("att2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att2 { get; set; }
		[JsonProperty("att3", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att3 { get; set; }
		[JsonProperty("att4", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att4 { get; set; }
		[JsonProperty("att5", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Att5 { get; set; }
		[JsonProperty("group_payment_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int GroupPaymentStatus { get; set; }
		[JsonProperty("delivery_receiver", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DeliveryReceiver { get; set; }
		[JsonProperty("delivery_phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DeliveryPhone { get; set; }
		[JsonProperty("last_modified_payment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LastModifiedPayment { get; set; }
		[JsonProperty("last_modified_order_detail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LastModifiedOrderDetail { get; set; }
		[JsonProperty("payment_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PaymentStatus { get; set; }
		[JsonProperty("delivery_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DeliveryType { get; set; }
		[JsonProperty("delivery_payment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DeliveryPayment { get; set; }
		[JsonProperty("invoice_status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> InvoiceStatus { get; set; }
		[JsonProperty("ward_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> WardCode { get; set; }
		[JsonProperty("district_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DistrictCode { get; set; }
		[JsonProperty("province_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProvinceCode { get; set; }
		[JsonProperty("promotion_partner_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> PromotionPartnerId { get; set; }
		[JsonProperty("member_point", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> MemberPoint { get; set; }
		[JsonProperty("receiver", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Receiver { get; set; }
		[JsonProperty("is_sync", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> isSync { get; set; }
		[JsonProperty("is_exported", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsExported { get; set; }
		[JsonProperty("customer_type_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerTypeId { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("district", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DistrictViewModel DistrictVM { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("ward", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public WardViewModel WardVM { get; set; }
		[JsonProperty("order_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderDetailViewModel> OrderDetailsVM { get; set; }
		[JsonProperty("order_fee_items", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderFeeItemViewModel> OrderFeeItemsVM { get; set; }
		[JsonProperty("order_promotion_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderPromotionMappingViewModel> OrderPromotionMappingsVM { get; set; }
		[JsonProperty("payments", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PaymentViewModel> PaymentsVM { get; set; }
		[JsonProperty("vatorder_mappings", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
