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
		[JsonProperty("storeThemeId")]
		public int StoreThemeId { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("themeName")]
		public string ThemeName { get; set; }
		[JsonProperty("themeId")]
		public int ThemeId { get; set; }
		[JsonProperty("storeThemeName")]
		public string StoreThemeName { get; set; }
		[JsonProperty("themeLogoUrl")]
		public string ThemeLogoUrl { get; set; }
		[JsonProperty("customThemeStyle")]
		public string CustomThemeStyle { get; set; }
		[JsonProperty("createdDate")]
		public DateTime CreatedDate { get; set; }
		[JsonProperty("isUsing")]
		public bool IsUsing { get; set; }
		[JsonProperty("createdBy")]
		public string CreatedBy { get; set; }
		[JsonProperty("lastModifiedDate")]
		public DateTime LastModifiedDate { get; set; }
		[JsonProperty("lastModifiedBy")]
		public string LastModifiedBy { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("store")]
		public StoreViewModel StoreVM { get; set; }
		[JsonProperty("theme")]
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
