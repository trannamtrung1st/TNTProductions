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
		[JsonProperty("groupId")]
		public int GroupId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("isDisplayed")]
		public Nullable<bool> IsDisplayed { get; set; }
		[JsonProperty("brandId")]
		public int BrandId { get; set; }
		[JsonProperty("products")]
		public ICollection<ProductViewModel> ProductsVM { get; set; }
		[JsonProperty("stores")]
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
