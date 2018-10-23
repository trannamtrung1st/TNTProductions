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
		[JsonProperty("provinceCode")]
		public int ProvinceCode { get; set; }
		[JsonProperty("provinceName")]
		public string ProvinceName { get; set; }
		[JsonProperty("provinceType")]
		public string ProvinceType { get; set; }
		[JsonProperty("basePriceDelivery")]
		public Nullable<decimal> BasePriceDelivery { get; set; }
		[JsonProperty("areaProvinceId")]
		public Nullable<int> AreaProvinceId { get; set; }
		[JsonProperty("areaDelivery")]
		public AreaDeliveryViewModel AreaDeliveryVM { get; set; }
		[JsonProperty("deliveryInformations")]
		public ICollection<DeliveryInformationViewModel> DeliveryInformationsVM { get; set; }
		[JsonProperty("districts")]
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
