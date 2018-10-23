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
		[JsonProperty("districtCode")]
		public int DistrictCode { get; set; }
		[JsonProperty("districtName")]
		public string DistrictName { get; set; }
		[JsonProperty("districtType")]
		public string DistrictType { get; set; }
		[JsonProperty("provinceCode")]
		public int ProvinceCode { get; set; }
		[JsonProperty("priceDelivery")]
		public Nullable<decimal> PriceDelivery { get; set; }
		[JsonProperty("areaDistrictId")]
		public Nullable<int> AreaDistrictId { get; set; }
		[JsonProperty("areaDelivery")]
		public AreaDeliveryViewModel AreaDeliveryVM { get; set; }
		[JsonProperty("province")]
		public ProvinceViewModel ProvinceVM { get; set; }
		[JsonProperty("deliveryInformations")]
		public ICollection<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		[JsonProperty("orders")]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("wards")]
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
