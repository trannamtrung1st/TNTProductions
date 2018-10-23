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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("userId")]
		public string UserId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("district")]
		public string District { get; set; }
		[JsonProperty("ward")]
		public string Ward { get; set; }
		[JsonProperty("typeAddress")]
		public Nullable<bool> TypeAddress { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("isDefault")]
		public Nullable<bool> IsDefault { get; set; }
		[JsonProperty("provinceCode")]
		public Nullable<int> ProvinceCode { get; set; }
		[JsonProperty("districtCode")]
		public Nullable<int> DistrictCode { get; set; }
		[JsonProperty("aspNetUser")]
		public AspNetUserViewModel AspNetUserVM { get; set; }
		[JsonProperty("aspNetUser1")]
		public AspNetUserViewModel AspNetUser1VM { get; set; }
		[JsonProperty("district1")]
		public DistrictViewModel District1VM { get; set; }
		[JsonProperty("province")]
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
