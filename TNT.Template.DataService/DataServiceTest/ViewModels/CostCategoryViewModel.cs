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
		[JsonProperty("cat_id")]
		public int CatID { get; set; }
		[JsonProperty("cat_name")]
		public string CatName { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brand_id")]
		public Nullable<int> BrandId { get; set; }
		//[JsonProperty("costs")]
		//public IEnumerable<CostViewModel> CostsVM { get; set; }
		
		public CostCategoryViewModel(CostCategory entity) : this()
		{
			FromEntity(entity);
		}
		
		public CostCategoryViewModel()
		{
			//this.CostsVM = new HashSet<CostViewModel>();
		}
		
	}
}
