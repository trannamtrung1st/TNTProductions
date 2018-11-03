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
	public partial class CategoryExtraMappingViewModel: BaseViewModel<CategoryExtraMapping>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("primary_category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int PrimaryCategoryId { get; set; }
		[JsonProperty("extra_category_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ExtraCategoryId { get; set; }
		[JsonProperty("is_enable", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsEnable { get; set; }
		[JsonProperty("product_category", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductCategoryViewModel ProductCategoryVM { get; set; }
		[JsonProperty("product_category1", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ProductCategoryViewModel ProductCategory1VM { get; set; }
		
		public CategoryExtraMappingViewModel(CategoryExtraMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CategoryExtraMappingViewModel()
		{
		}
		
	}
}
