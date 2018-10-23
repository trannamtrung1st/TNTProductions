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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("mode")]
		public Nullable<int> Mode { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("payrollDetails")]
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
