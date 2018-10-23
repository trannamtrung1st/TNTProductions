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
		[JsonProperty("primaryCategoryId")]
		public int PrimaryCategoryId { get; set; }
		[JsonProperty("extraCategoryId")]
		public int ExtraCategoryId { get; set; }
		[JsonProperty("isEnable")]
		public bool IsEnable { get; set; }
		[JsonProperty("productCategory")]
		public ProductCategoryViewModel ProductCategoryVM { get; set; }
		[JsonProperty("productCategory1")]
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
