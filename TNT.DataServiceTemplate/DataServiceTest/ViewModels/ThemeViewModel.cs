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
	public partial class ThemeViewModel: BaseViewModel<Theme>
	{
		[JsonProperty("theme_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ThemeId { get; set; }
		[JsonProperty("theme_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ThemeName { get; set; }
		[JsonProperty("theme_folder_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ThemeFolderUrl { get; set; }
		[JsonProperty("theme_style", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ThemeStyle { get; set; }
		[JsonProperty("image_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ImageUrl { get; set; }
		[JsonProperty("created_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime CreatedDate { get; set; }
		[JsonProperty("created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string CreatedBy { get; set; }
		[JsonProperty("last_modified_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Nullable<DateTime> LastModifiedDate { get; set; }
		[JsonProperty("last_modified_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string LastModifiedBy { get; set; }
		[JsonProperty("active", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool Active { get; set; }
		[JsonProperty("description", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Description { get; set; }
		[JsonProperty("store_themes", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public ICollection<StoreThemeViewModel> StoreThemesVM { get; set; }
		
		public ThemeViewModel(Theme entity) : this()
		{
			FromEntity(entity);
		}
		
		public ThemeViewModel()
		{
			this.StoreThemesVM = new HashSet<StoreThemeViewModel>();
		}
		
	}
}
