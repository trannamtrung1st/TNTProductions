using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promoter.DataService.Global;
using Promoter.DataService.Models;
using Newtonsoft.Json;

namespace Promoter.DataService.ViewModels
{
	public partial class PC_ProductFilterViewModel: BaseViewModel<PC_ProductFilter>
	{
		[JsonProperty("filter_id")]
		public int FilterId { get; set; }
		[JsonProperty("product_id")]
		public Nullable<int> ProductId { get; set; }
		[JsonProperty("product_category_id")]
		public Nullable<int> ProductCategoryId { get; set; }
		[JsonProperty("product_menu_id")]
		public Nullable<int> ProductMenuId { get; set; }
		[JsonProperty("min_buy_quantity")]
		public Nullable<int> MinBuyQuantity { get; set; }
		[JsonProperty("max_buy_quantity")]
		public Nullable<int> MaxBuyQuantity { get; set; }
		[JsonProperty("constraint_id")]
		public int ConstraintId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_constraint")]
		public PromotionConstraintViewModel PromotionConstraintVM { get; set; }
		
		public PC_ProductFilterViewModel(PC_ProductFilter entity) : this()
		{
			FromEntity(entity);
		}
		
		public PC_ProductFilterViewModel()
		{
		}
		
	}
}
