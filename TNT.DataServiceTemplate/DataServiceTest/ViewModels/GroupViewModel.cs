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
	public partial class GroupViewModel: BaseViewModel<Group>
	{
		[JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int GroupId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("is_displayed", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<bool> IsDisplayed { get; set; }
		[JsonProperty("brand_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int BrandId { get; set; }
		[JsonProperty("products", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<ProductViewModel> ProductsVM { get; set; }
		[JsonProperty("stores", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreViewModel> StoresVM { get; set; }
		
		public GroupViewModel(Group entity) : this()
		{
			FromEntity(entity);
		}
		
		public GroupViewModel()
		{
			this.ProductsVM = new HashSet<ProductViewModel>();
			this.StoresVM = new HashSet<StoreViewModel>();
		}
		
	}
}
