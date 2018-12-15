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
	public partial class MembershipCardViewModel: BaseViewModel<MembershipCard>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("customer_id")]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("membership_card_code")]
		public string MembershipCardCode { get; set; }
		[JsonProperty("csv")]
		public string CSV { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("created_time")]
		public DateTime CreatedTime { get; set; }
		[JsonProperty("brand_id")]
		public int BrandId { get; set; }
		[JsonProperty("c_level")]
		public Nullable<int> C_Level { get; set; }
		[JsonProperty("membership_type_id")]
		public Nullable<int> MembershipTypeId { get; set; }
		[JsonProperty("is_sample")]
		public Nullable<bool> IsSample { get; set; }
		[JsonProperty("store_id")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("product_code")]
		public string ProductCode { get; set; }
		[JsonProperty("initial_value")]
		public Nullable<double> InitialValue { get; set; }
		[JsonProperty("create_by")]
		public string CreateBy { get; set; }
		[JsonProperty("physical_card_code")]
		public string PhysicalCardCode { get; set; }
		//[JsonProperty("customer")]
		//public CustomerViewModel CustomerVM { get; set; }
		//[JsonProperty("membership_card_type")]
		//public MembershipCardTypeViewModel MembershipCardTypeVM { get; set; }
		//[JsonProperty("accounts")]
		//public IEnumerable<AccountViewModel> AccountsVM { get; set; }
		//[JsonProperty("vouchers")]
		//public IEnumerable<VoucherViewModel> VouchersVM { get; set; }
		
		public MembershipCardViewModel(MembershipCard entity) : this()
		{
			FromEntity(entity);
		}
		
		public MembershipCardViewModel()
		{
			//this.AccountsVM = new HashSet<AccountViewModel>();
			//this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
