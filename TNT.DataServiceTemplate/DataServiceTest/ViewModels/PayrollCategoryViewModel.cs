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
	public partial class PayrollCategoryViewModel: BaseViewModel<PayrollCategory>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("mode", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Mode { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("payroll_details", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<PayrollDetailViewModel> PayrollDetailsVM { get; set; }
		
		public PayrollCategoryViewModel(PayrollCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public PayrollCategoryViewModel()
		{
			this.PayrollDetailsVM = new HashSet<PayrollDetailViewModel>();
		}
		
	}
}
