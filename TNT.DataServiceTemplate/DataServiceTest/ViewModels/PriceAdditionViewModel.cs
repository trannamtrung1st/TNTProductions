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
		[JsonProperty("additionPriceID")]
		public int AdditionPriceID { get; set; }
		[JsonProperty("earlyHourRange")]
		public string EarlyHourRange { get; set; }
		[JsonProperty("earlyPriceRange")]
		public string EarlyPriceRange { get; set; }
		[JsonProperty("lateHourRange")]
		public string LateHourRange { get; set; }
		[JsonProperty("latePriceRange")]
		public string LatePriceRange { get; set; }
		[JsonProperty("name")]
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
