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
		[JsonProperty("store_web_route_id")]
		public int StoreWebRouteId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("view_model_type")]
		public int ViewModelType { get; set; }
		[JsonProperty("id_route_value_name")]
		public string IdRouteValueName { get; set; }
		[JsonProperty("id_route_default_value")]
		public string IdRouteDefaultValue { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("store_web_route")]
		//public StoreWebRouteViewModel StoreWebRouteVM { get; set; }
		
		public StoreWebRouteModelViewModel(StoreWebRouteModel entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreWebRouteModelViewModel()
		{
		}
		
	}
}
