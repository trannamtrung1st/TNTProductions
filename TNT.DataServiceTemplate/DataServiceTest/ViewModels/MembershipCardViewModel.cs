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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("customer_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("membership_card_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MembershipCardCode { get; set; }
		[JsonProperty("csv", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CSV { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Status { get; set; }
		[JsonProperty("created_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreatedTime { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("c_level", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> C_Level { get; set; }
		[JsonProperty("membership_type_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> MembershipTypeId { get; set; }
		[JsonProperty("is_sample", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsSample { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("product_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductCode { get; set; }
		[JsonProperty("initial_value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> InitialValue { get; set; }
		[JsonProperty("create_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CreateBy { get; set; }
		[JsonProperty("physical_card_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string PhysicalCardCode { get; set; }
		[JsonProperty("customer", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("membership_card_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public MembershipCardTypeViewModel MembershipCardTypeVM { get; set; }
		[JsonProperty("accounts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AccountViewModel> AccountsVM { get; set; }
		[JsonProperty("vouchers", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<VoucherViewModel> VouchersVM { get; set; }
		
		public MembershipCardViewModel(MembershipCard entity) : this()
		{
			FromEntity(entity);
		}
		
		public MembershipCardViewModel()
		{
			this.AccountsVM = new HashSet<AccountViewModel>();
			this.VouchersVM = new HashSet<VoucherViewModel>();
		}
		
	}
}
