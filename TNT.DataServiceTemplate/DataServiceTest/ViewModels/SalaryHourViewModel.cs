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
		[JsonProperty("insertMode")]
		public int InsertMode { get; set; }
		[JsonProperty("employeeId")]
		public Nullable<int> EmployeeId { get; set; }
		[JsonProperty("updatePerson")]
		public string UpdatePerson { get; set; }
		[JsonProperty("timeModeRuleId")]
		public Nullable<int> TimeModeRuleId { get; set; }
		[JsonProperty("existCode")]
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
