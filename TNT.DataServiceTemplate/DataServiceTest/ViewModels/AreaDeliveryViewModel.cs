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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("area_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string AreaName { get; set; }
		[JsonProperty("area_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int AreaType { get; set; }
		[JsonProperty("price_delivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public decimal PriceDelivery { get; set; }
		[JsonProperty("area_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> AreaID { get; set; }
		[JsonProperty("area_delivery2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public AreaDeliveryViewModel AreaDelivery2VM { get; set; }
		[JsonProperty("area_delivery1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<AreaDeliveryViewModel> AreaDelivery1VM { get; set; }
		[JsonProperty("districts", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<DistrictViewModel> DistrictsVM { get; set; }
		[JsonProperty("provinces", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProvinceViewModel> ProvincesVM { get; set; }
		
		public AreaDeliveryViewModel(AreaDelivery entity) : this()
		{
			FromEntity(entity);
		}
		
		public AreaDeliveryViewModel()
		{
			this.AreaDelivery1VM = new HashSet<AreaDeliveryViewModel>();
			this.DistrictsVM = new HashSet<DistrictViewModel>();
			this.ProvincesVM = new HashSet<ProvinceViewModel>();
		}
		
	}
}
