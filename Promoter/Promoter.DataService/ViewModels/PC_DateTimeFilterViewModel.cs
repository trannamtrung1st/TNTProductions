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
	public partial class PC_DateTimeFilterViewModel: BaseViewModel<PC_DateTimeFilter>
	{
		[JsonProperty("filter_id")]
		public int FilterId { get; set; }
		[JsonProperty("begin_date")]
		public Nullable<DateTime> BeginDate { get; set; }
		[JsonProperty("end_date")]
		public Nullable<DateTime> EndDate { get; set; }
		[JsonProperty("day_of_week")]
		public Nullable<int> DayOfWeek { get; set; }
		[JsonProperty("begin_hour")]
		public Nullable<System.TimeSpan> BeginHour { get; set; }
		[JsonProperty("end_hour")]
		public Nullable<System.TimeSpan> EndHour { get; set; }
		[JsonProperty("constraint_id")]
		public int ConstraintId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("promotion_constraint")]
		public PromotionConstraintViewModel PromotionConstraintVM { get; set; }
		
		public PC_DateTimeFilterViewModel(PC_DateTimeFilter entity) : this()
		{
			FromEntity(entity);
		}
		
		public PC_DateTimeFilterViewModel()
		{
		}
		
	}
}
