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
	public partial class PriceAdditionViewModel: BaseViewModel<PriceAddition>
	{
		[JsonProperty("addition_price_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int AdditionPriceID { get; set; }
		[JsonProperty("early_hour_range", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EarlyHourRange { get; set; }
		[JsonProperty("early_price_range", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EarlyPriceRange { get; set; }
		[JsonProperty("late_hour_range", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LateHourRange { get; set; }
		[JsonProperty("late_price_range", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LatePriceRange { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		
		public PriceAdditionViewModel(PriceAddition entity) : this()
		{
			FromEntity(entity);
		}
		
		public PriceAdditionViewModel()
		{
		}
		
	}
}
