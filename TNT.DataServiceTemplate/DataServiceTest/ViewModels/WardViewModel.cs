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
	public partial class WardViewModel: BaseViewModel<Ward>
	{
		[JsonProperty("ward_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int WardCode { get; set; }
		[JsonProperty("ward_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string WardName { get; set; }
		[JsonProperty("ward_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string WardType { get; set; }
		[JsonProperty("district_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int DistrictCode { get; set; }
		[JsonProperty("district", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DistrictViewModel DistrictVM { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		
		public WardViewModel(Ward entity) : this()
		{
			FromEntity(entity);
		}
		
		public WardViewModel()
		{
			this.OrdersVM = new HashSet<OrderViewModel>();
		}
		
	}
}
