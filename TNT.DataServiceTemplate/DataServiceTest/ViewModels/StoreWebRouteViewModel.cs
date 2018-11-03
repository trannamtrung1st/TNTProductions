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
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("store_web_route_copy_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> StoreWebRouteCopyId { get; set; }
		[JsonProperty("path", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Path { get; set; }
		[JsonProperty("view_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ViewName { get; set; }
		[JsonProperty("layout_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LayoutName { get; set; }
		[JsonProperty("position", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Position { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("store_web_route2", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreWebRouteViewModel StoreWebRoute2VM { get; set; }
		[JsonProperty("store_web_route1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreWebRouteViewModel> StoreWebRoute1VM { get; set; }
		[JsonProperty("store_web_route_models", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreWebRouteModelViewModel> StoreWebRouteModelsVM { get; set; }
		
		public StoreWebRouteViewModel(StoreWebRoute entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreWebRouteViewModel()
		{
			this.StoreWebRoute1VM = new HashSet<StoreWebRouteViewModel>();
			this.StoreWebRouteModelsVM = new HashSet<StoreWebRouteModelViewModel>();
		}
		
	}
}
