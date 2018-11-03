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
	public partial class LanguageValueViewModel: BaseViewModel<LanguageValue>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int Id { get; set; }
		[JsonProperty("language_key_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int LanguageKeyId { get; set; }
		[JsonProperty("language_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int LanguageId { get; set; }
		[JsonProperty("value", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Value { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("language", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public LanguageViewModel LanguageVM { get; set; }
		[JsonProperty("language_key", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public LanguageKeyViewModel LanguageKeyVM { get; set; }
		
		public LanguageValueViewModel(LanguageValue entity) : this()
		{
			FromEntity(entity);
		}
		
		public LanguageValueViewModel()
		{
		}
		
	}
}
