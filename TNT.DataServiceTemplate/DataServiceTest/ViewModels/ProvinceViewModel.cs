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
	public partial class ProvinceViewModel: BaseViewModel<Province>
	{
		[JsonProperty("province_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ProvinceCode { get; set; }
		[JsonProperty("province_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProvinceName { get; set; }
		[JsonProperty("province_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProvinceType { get; set; }
		[JsonProperty("base_price_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<decimal> BasePriceDelivery { get; set; }
		[JsonProperty("area_province_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AreaProvinceId { get; set; }
		[JsonProperty("area_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AreaDeliveryViewModel AreaDeliveryVM { get; set; }
		[JsonProperty("delivery_informations", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		[JsonProperty("districts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DistrictViewModel> DistrictsVM { get; set; }
		
		public ProvinceViewModel(Province entity) : this()
		{
			FromEntity(entity);
		}
		
		public ProvinceViewModel()
		{
			this.DeliveryInformationsVM = new HashSet<DeliveryInformationViewModel>();
			this.DistrictsVM = new HashSet<DistrictViewModel>();
		}
		
	}
}
