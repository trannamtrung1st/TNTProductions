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
		[JsonProperty("iid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int IID { get; set; }
		[JsonProperty("sid", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string SID { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Address { get; set; }
		[JsonProperty("phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Phone { get; set; }
		[JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Email { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> Active { get; set; }
		[JsonProperty("orders", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<OrderViewModel> OrdersVM { get; set; }
		[JsonProperty("promotion_store_rules", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PromotionStoreRuleViewModel> PromotionStoreRulesVM { get; set; }
		
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
