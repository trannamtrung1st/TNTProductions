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
		[JsonProperty("customerId")]
		public Nullable<int> CustomerId { get; set; }
		[JsonProperty("membershipCardCode")]
		public string MembershipCardCode { get; set; }
		[JsonProperty("cSV")]
		public string CSV { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("status")]
		public Nullable<int> Status { get; set; }
		[JsonProperty("createdTime")]
		public DateTime CreatedTime { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("c_Level")]
		public Nullable<int> C_Level { get; set; }
		[JsonProperty("membershipTypeId")]
		public Nullable<int> MembershipTypeId { get; set; }
		[JsonProperty("isSample")]
		public Nullable<bool> IsSample { get; set; }
		[JsonProperty("storeId")]
		public Nullable<int> StoreId { get; set; }
		[JsonProperty("productCode")]
		public string ProductCode { get; set; }
		[JsonProperty("initialValue")]
		public Nullable<double> InitialValue { get; set; }
		[JsonProperty("createBy")]
		public string CreateBy { get; set; }
		[JsonProperty("physicalCardCode")]
		public string PhysicalCardCode { get; set; }
		[JsonProperty("customer")]
		public CustomerViewModel CustomerVM { get; set; }
		[JsonProperty("membershipCardType")]
		public MembershipCardTypeViewModel MembershipCardTypeVM { get; set; }
		[JsonProperty("accounts")]
		public ICollection<AccountViewModel> AccountsVM { get; set; }
		[JsonProperty("vouchers")]
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
