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
		[JsonProperty("areaName")]
		public string AreaName { get; set; }
		[JsonProperty("areaType")]
		public int AreaType { get; set; }
		[JsonProperty("priceDelivery")]
		public decimal PriceDelivery { get; set; }
		[JsonProperty("areaID")]
		public Nullable<int> AreaID { get; set; }
		[JsonProperty("areaDelivery2")]
		public AreaDeliveryViewModel AreaDelivery2VM { get; set; }
		[JsonProperty("areaDelivery1")]
		public ICollection<AreaDeliveryViewModel> AreaDelivery1VM { get; set; }
		[JsonProperty("districts")]
		public ICollection<DistrictViewModel> DistrictsVM { get; set; }
		[JsonProperty("provinces")]
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
