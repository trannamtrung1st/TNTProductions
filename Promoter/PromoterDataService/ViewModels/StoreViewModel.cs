using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoterDataService.Global;
using PromoterDataService.Models;
using Newtonsoft.Json;

namespace PromoterDataService.ViewModels
{
	public partial class StoreViewModel: BaseViewModel<Store>
	{
		[JsonProperty("iid")]
		public int IID { get; set; }
		[JsonProperty("sid")]
		public string SID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("address")]
		public string Address { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("active")]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("orders")]
		public IEnumerable<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("promotion_store_rules")]
		public IEnumerable<PromotionStoreRuleViewModel> PromotionStoreRulesVM { get; set; }
		
		public StoreViewModel(Store entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreViewModel()
		{
			this.OrdersVM = new HashSet<OrderViewModel>();
			this.PromotionStoreRulesVM = new HashSet<PromotionStoreRuleViewModel>();
		}
		
	}
}
