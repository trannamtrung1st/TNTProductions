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
	public partial class DayModeViewModel: BaseViewModel<DayMode>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("dayFilter")]
		public Nullable<int> DayFilter { get; set; }
		[JsonProperty("isSpecialDay")]
		public Nullable<int> IsSpecialDay { get; set; }
		[JsonProperty("priority")]
		public Nullable<int> Priority { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("timeModeRules")]
		public ICollection<TimeModeRuleViewModel> TimeModeRulesVM { get; set; }
		
		public DayModeViewModel(DayMode entity) : this()
		{
			FromEntity(entity);
		}
		
		public DayModeViewModel()
		{
			this.TimeModeRulesVM = new HashSet<TimeModeRuleViewModel>();
		}
		
	}
}
