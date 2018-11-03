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
	public partial class DistrictViewModel: BaseViewModel<District>
	{
		[JsonProperty("district_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DistrictCode { get; set; }
		[JsonProperty("district_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DistrictName { get; set; }
		[JsonProperty("district_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string DistrictType { get; set; }
		[JsonProperty("province_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProvinceCode { get; set; }
		[JsonProperty("price_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<decimal> PriceDelivery { get; set; }
		[JsonProperty("area_district_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AreaDistrictId { get; set; }
		[JsonProperty("area_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AreaDeliveryViewModel AreaDeliveryVM { get; set; }
		[JsonProperty("province", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProvinceViewModel ProvinceVM { get; set; }
		[JsonProperty("delivery_informations", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("wards", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<WardViewModel> WardsVM { get; set; }
		
		public DistrictViewModel(District entity) : this()
		{
			FromEntity(entity);
		}
		
		public DistrictViewModel()
		{
			this.DeliveryInformationsVM = new HashSet<DeliveryInformationViewModel>();
			this.OrdersVM = new HashSet<OrderViewModel>();
			this.WardsVM = new HashSet<WardViewModel>();
		}
		
	}
}
