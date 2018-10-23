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
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("storeWebRouteCopyId")]
		public Nullable<int> StoreWebRouteCopyId { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("viewName")]
		public string ViewName { get; set; }
		[JsonProperty("layoutName")]
		public string LayoutName { get; set; }
		[JsonProperty("position")]
		public int Position { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("storeWebRoute2")]
		public StoreWebRouteViewModel StoreWebRoute2VM { get; set; }
		[JsonProperty("storeWebRoute1")]
		public ICollection<StoreWebRouteViewModel> StoreWebRoute1VM { get; set; }
		[JsonProperty("storeWebRouteModels")]
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
