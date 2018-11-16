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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("duration")]
		public Nullable<double> Duration { get; set; }
		[JsonProperty("insert_mode")]
		public int InsertMode { get; set; }
		[JsonProperty("employee_id")]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("update_person")]
		public string UpdatePerson { get; set; }
		[JsonProperty("time_mode_rule_id")]
		public Nullable<int> TimeModeRuleId { get; set; }
		[JsonProperty("exist_code")]
		public string ExistCode { get; set; }
		[JsonProperty("active")]
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
