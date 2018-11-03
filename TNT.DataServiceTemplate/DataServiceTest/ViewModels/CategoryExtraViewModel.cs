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
	public partial class CategoryExtraViewModel: BaseViewModel<CategoryExtra>
	{
		[JsonProperty("category_extra_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int CategoryExtraId { get; set; }
		[JsonProperty("primary_category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PrimaryCategoryId { get; set; }
		[JsonProperty("extra_category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ExtraCategoryId { get; set; }
		[JsonProperty("is_enable", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsEnable { get; set; }
		
		public CategoryExtraViewModel(CategoryExtra entity) : this()
		{
			FromEntity(entity);
		}
		
		public CategoryExtraViewModel()
		{
		}
		
	}
}
