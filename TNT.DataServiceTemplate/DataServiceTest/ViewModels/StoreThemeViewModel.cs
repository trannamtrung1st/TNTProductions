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
	public partial class StoreThemeViewModel: BaseViewModel<StoreTheme>
	{
		[JsonProperty("store_theme_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreThemeId { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("theme_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ThemeName { get; set; }
		[JsonProperty("theme_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ThemeId { get; set; }
		[JsonProperty("store_theme_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string StoreThemeName { get; set; }
		[JsonProperty("theme_logo_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ThemeLogoUrl { get; set; }
		[JsonProperty("custom_theme_style", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CustomThemeStyle { get; set; }
		[JsonProperty("created_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreatedDate { get; set; }
		[JsonProperty("is_using", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsUsing { get; set; }
		[JsonProperty("created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CreatedBy { get; set; }
		[JsonProperty("last_modified_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime LastModifiedDate { get; set; }
		[JsonProperty("last_modified_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LastModifiedBy { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("theme", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ThemeViewModel ThemeVM { get; set; }
		
		public StoreThemeViewModel(StoreTheme entity) : this()
		{
			FromEntity(entity);
		}
		
		public StoreThemeViewModel()
		{
		}
		
	}
}
