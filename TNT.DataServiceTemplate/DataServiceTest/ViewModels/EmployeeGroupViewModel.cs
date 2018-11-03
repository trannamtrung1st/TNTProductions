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
	public partial class EmployeeGroupViewModel: BaseViewModel<EmployeeGroup>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("code_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CodeGroup { get; set; }
		[JsonProperty("name_group", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string NameGroup { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("expand_time", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<System.TimeSpan> ExpandTime { get; set; }
		[JsonProperty("group_policy", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GroupPolicy { get; set; }
		[JsonProperty("group_security", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> GroupSecurity { get; set; }
		[JsonProperty("employees", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<EmployeeViewModel> EmployeesVM { get; set; }
		[JsonProperty("time_frames", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<TimeFrameViewModel> TimeFramesVM { get; set; }
		
		public EmployeeGroupViewModel(EmployeeGroup entity) : this()
		{
			FromEntity(entity);
		}
		
		public EmployeeGroupViewModel()
		{
			this.EmployeesVM = new HashSet<EmployeeViewModel>();
			this.TimeFramesVM = new HashSet<TimeFrameViewModel>();
		}
		
	}
}
