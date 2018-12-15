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
	public partial class AreaDeliveryViewModel: BaseViewModel<AreaDelivery>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("area_name")]
		public string AreaName { get; set; }
		[JsonProperty("area_type")]
		public int AreaType { get; set; }
		[JsonProperty("price_delivery")]
		public decimal PriceDelivery { get; set; }
		[JsonProperty("area_id")]
		public Nullable<int> AreaID { get; set; }
		//[JsonProperty("area_delivery2")]
		//public AreaDeliveryViewModel AreaDelivery2VM { get; set; }
		//[JsonProperty("area_delivery1")]
		//public IEnumerable<AreaDeliveryViewModel> AreaDelivery1VM { get; set; }
		//[JsonProperty("districts")]
		//public IEnumerable<DistrictViewModel> DistrictsVM { get; set; }
		//[JsonProperty("provinces")]
		//public IEnumerable<ProvinceViewModel> ProvincesVM { get; set; }
		
		public AreaDeliveryViewModel(AreaDelivery entity) : this()
		{
			FromEntity(entity);
		}
		
		public AreaDeliveryViewModel()
		{
			//this.AreaDelivery1VM = new HashSet<AreaDeliveryViewModel>();
			//this.DistrictsVM = new HashSet<DistrictViewModel>();
			//this.ProvincesVM = new HashSet<ProvinceViewModel>();
		}
		
	}
}
