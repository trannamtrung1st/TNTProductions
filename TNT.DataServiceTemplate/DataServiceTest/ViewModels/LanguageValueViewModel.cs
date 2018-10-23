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
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("languageKeyId")]
		public int LanguageKeyId { get; set; }
		[JsonProperty("languageId")]
		public int LanguageId { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("language")]
		public LanguageViewModel LanguageVM { get; set; }
		[JsonProperty("languageKey")]
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
