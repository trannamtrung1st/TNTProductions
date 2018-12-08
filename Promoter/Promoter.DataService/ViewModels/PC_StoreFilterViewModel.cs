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
	public partial class PC_StoreFilterViewModel: BaseViewModel<PC_StoreFilter>
	{
		[JsonProperty("store_id")]
		public int StoreId { get; set; }
		[JsonProperty("constraint_id")]
		public int ConstraintId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_constraint")]
		public PromotionConstraintViewModel PromotionConstraintVM { get; set; }
		
		public PC_StoreFilterViewModel(PC_StoreFilter entity) : this()
		{
			FromEntity(entity);
		}
		
		public PC_StoreFilterViewModel()
		{
		}
		
	}
}
