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
	public partial class TimeModeTypeViewModel: BaseViewModel<TimeModeType>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("timeModeRules")]
		public ICollection<TimeModeRuleViewModel> TimeModeRulesVM { get; set; }
		
		public TimeModeTypeViewModel(TimeModeType entity) : this()
		{
			FromEntity(entity);
		}
		
		public TimeModeTypeViewModel()
		{
			this.TimeModeRulesVM = new HashSet<TimeModeRuleViewModel>();
		}
		
	}
}
