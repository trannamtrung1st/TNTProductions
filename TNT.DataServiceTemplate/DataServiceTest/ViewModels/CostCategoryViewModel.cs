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
		[JsonProperty("catID")]
		public int CatID { get; set; }
		[JsonProperty("catName")]
		public string CatName { get; set; }
		[JsonProperty("type")]
		public Nullable<int> Type { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("brandId")]
		public Nullable<int> BrandId { get; set; }
		[JsonProperty("costs")]
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
