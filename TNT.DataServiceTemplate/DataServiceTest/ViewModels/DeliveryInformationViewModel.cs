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
	public partial class DeliveryInformationViewModel: BaseViewModel<DeliveryInformation>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UserId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("city", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string City { get; set; }
		[JsonProperty("district", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string District { get; set; }
		[JsonProperty("ward", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Ward { get; set; }
		[JsonProperty("type_address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> TypeAddress { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("is_default", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDefault { get; set; }
		[JsonProperty("province_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> ProvinceCode { get; set; }
		[JsonProperty("district_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> DistrictCode { get; set; }
		[JsonProperty("asp_net_user", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AspNetUserViewModel AspNetUserVM { get; set; }
		[JsonProperty("asp_net_user1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AspNetUserViewModel AspNetUser1VM { get; set; }
		[JsonProperty("district1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DistrictViewModel District1VM { get; set; }
		[JsonProperty("province", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProvinceViewModel ProvinceVM { get; set; }
		
		public DeliveryInformationViewModel(DeliveryInformation entity) : this()
		{
			FromEntity(entity);
		}
		
		public DeliveryInformationViewModel()
		{
		}
		
	}
}
