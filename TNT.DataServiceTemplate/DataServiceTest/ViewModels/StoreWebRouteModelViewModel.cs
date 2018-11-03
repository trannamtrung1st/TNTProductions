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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_web_route_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreWebRouteId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("view_model_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ViewModelType { get; set; }
		[JsonProperty("id_route_value_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdRouteValueName { get; set; }
		[JsonProperty("id_route_default_value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string IdRouteDefaultValue { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store_web_route", DefaultValueHandling = DefaultValueHandling.Ignore)]
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
