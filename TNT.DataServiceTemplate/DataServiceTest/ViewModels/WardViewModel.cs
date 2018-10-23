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
		[JsonProperty("wardCode")]
		public int WardCode { get; set; }
		[JsonProperty("wardName")]
		public string WardName { get; set; }
		[JsonProperty("wardType")]
		public string WardType { get; set; }
		[JsonProperty("districtCode")]
		public int DistrictCode { get; set; }
		[JsonProperty("district")]
		public DistrictViewModel DistrictVM { get; set; }
		[JsonProperty("orders")]
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
