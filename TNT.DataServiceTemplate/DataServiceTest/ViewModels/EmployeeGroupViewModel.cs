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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("codeGroup")]
		public string CodeGroup { get; set; }
		[JsonProperty("nameGroup")]
		public string NameGroup { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("expandTime")]
		public Nullable<System.TimeSpan> ExpandTime { get; set; }
		[JsonProperty("groupPolicy")]
		public Nullable<int> GroupPolicy { get; set; }
		[JsonProperty("groupSecurity")]
		public Nullable<int> GroupSecurity { get; set; }
		[JsonProperty("employees")]
		public ICollection<EmployeeViewModel> EmployeesVM { get; set; }
		[JsonProperty("timeFrames")]
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
