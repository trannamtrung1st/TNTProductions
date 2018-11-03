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
	public partial class LanguageViewModel: BaseViewModel<Language>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("english_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string EnglishName { get; set; }
		[JsonProperty("is_fallback_language", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsFallbackLanguage { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("language_values", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<LanguageValueViewModel> LanguageValuesVM { get; set; }
		
		public LanguageViewModel(Language entity) : this()
		{
			FromEntity(entity);
		}
		
		public LanguageViewModel()
		{
			this.LanguageValuesVM = new HashSet<LanguageValueViewModel>();
		}
		
	}
}
