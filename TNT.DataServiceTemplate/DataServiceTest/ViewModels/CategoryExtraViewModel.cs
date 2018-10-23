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
		[JsonProperty("categoryExtraId")]
		public int CategoryExtraId { get; set; }
		[JsonProperty("primaryCategoryId")]
		public int PrimaryCategoryId { get; set; }
		[JsonProperty("extraCategoryId")]
		public int ExtraCategoryId { get; set; }
		[JsonProperty("isEnable")]
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
