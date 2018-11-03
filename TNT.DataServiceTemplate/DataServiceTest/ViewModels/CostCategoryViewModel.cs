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
	public partial class CostCategoryViewModel: BaseViewModel<CostCategory>
	{
		[JsonProperty("cat_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CatID { get; set; }
		[JsonProperty("cat_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CatName { get; set; }
		[JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> Type { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("costs", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<CostViewModel> CostsVM { get; set; }
		
		public CostCategoryViewModel(CostCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public CostCategoryViewModel()
		{
			this.CostsVM = new HashSet<CostViewModel>();
		}
		
	}
}
