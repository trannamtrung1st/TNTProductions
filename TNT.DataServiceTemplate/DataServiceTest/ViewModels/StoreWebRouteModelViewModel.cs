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
	public partial class StoreWebRouteModelViewModel: BaseViewModel<StoreWebRouteModel>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("storeWebRouteId")]
		public int StoreWebRouteId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("viewModelType")]
		public int ViewModelType { get; set; }
		[JsonProperty("idRouteValueName")]
		public string IdRouteValueName { get; set; }
		[JsonProperty("idRouteDefaultValue")]
		public string IdRouteDefaultValue { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("storeWebRoute")]
		public StoreWebRouteViewModel StoreWebRouteVM { get; set; }
		
		public StoreWebRouteModelViewModel(StoreWebRouteModel entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreWebRouteModelViewModel()
		{
		}
		
	}
}
