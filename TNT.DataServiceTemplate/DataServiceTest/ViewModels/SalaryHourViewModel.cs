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
	public partial class SalaryHourViewModel: BaseViewModel<SalaryHour>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime Date { get; set; }
		[JsonProperty("duration", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<double> Duration { get; set; }
		[JsonProperty("insert_mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int InsertMode { get; set; }
		[JsonProperty("employee_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("update_person", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string UpdatePerson { get; set; }
		[JsonProperty("time_mode_rule_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> TimeModeRuleId { get; set; }
		[JsonProperty("exist_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ExistCode { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		
		public SalaryHourViewModel(SalaryHour entity) : this()
		{
			FromEntity(entity);
		}
		
		public SalaryHourViewModel()
		{
		}
		
	}
}
