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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("primary_category_id")]
		public int PrimaryCategoryId { get; set; }
		[JsonProperty("extra_category_id")]
		public int ExtraCategoryId { get; set; }
		[JsonProperty("is_enable")]
		public bool IsEnable { get; set; }
		//[JsonProperty("product_category")]
		//public ProductCategoryViewModel ProductCategoryVM { get; set; }
		//[JsonProperty("product_category1")]
		//public ProductCategoryViewModel ProductCategory1VM { get; set; }
		
		public CategoryExtraMappingViewModel(CategoryExtraMapping entity) : this()
		{
			FromEntity(entity);
		}
		
		public CategoryExtraMappingViewModel()
		{
		}
		
	}
}
