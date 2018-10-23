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
	public partial class TemplateDetailMappingViewModel: BaseViewModel<TemplateDetailMapping>
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("paySlipTemplateId")]
		public int PaySlipTemplateId { get; set; }
		[JsonProperty("payrollDetailId")]
		public Nullable<int> PayrollDetailId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("payrollDetail")]
		public PayrollDetailViewModel PayrollDetailVM { get; set; }
		[JsonProperty("paySlipTemplate")]
		public PaySlipTemplateViewModel PaySlipTemplateVM { get; set; }
		[JsonProperty("paySlips")]
		public ICollection<PaySlipViewModel> PaySlipsVM { get; set; }
		
		public TemplateDetailMappingViewModel(TemplateDetailMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public TemplateDetailMappingViewModel()
		{
			this.PaySlipsVM = new HashSet<PaySlipViewModel>();
		}
		
	}
}
