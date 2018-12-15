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
	public partial class StoreWebRouteViewModel: BaseViewModel<StoreWebRoute>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("store_web_route_copy_id")]
		public Nullable<int> StoreWebRouteCopyId { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("view_name")]
		public string ViewName { get; set; }
		[JsonProperty("layout_name")]
		public string LayoutName { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		//[JsonProperty("store")]
		//public StoreViewModel StoreVM { get; set; }
		//[JsonProperty("store_web_route2")]
		//public StoreWebRouteViewModel StoreWebRoute2VM { get; set; }
		//[JsonProperty("store_web_route1")]
		//public IEnumerable<StoreWebRouteViewModel> StoreWebRoute1VM { get; set; }
		//[JsonProperty("store_web_route_models")]
		//public IEnumerable<StoreWebRouteModelViewModel> StoreWebRouteModelsVM { get; set; }
		
		public StoreWebRouteViewModel(StoreWebRoute entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreWebRouteViewModel()
		{
			//this.StoreWebRoute1VM = new HashSet<StoreWebRouteViewModel>();
			//this.StoreWebRouteModelsVM = new HashSet<StoreWebRouteModelViewModel>();
		}
		
	}
}
