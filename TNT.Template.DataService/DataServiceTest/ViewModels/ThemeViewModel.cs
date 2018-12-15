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
		[JsonProperty("theme_id")]
		public int ThemeId { get; set; }
		[JsonProperty("theme_name")]
		public string ThemeName { get; set; }
		[JsonProperty("theme_folder_url")]
		public string ThemeFolderUrl { get; set; }
		[JsonProperty("theme_style")]
		public string ThemeStyle { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("created_date")]
		public DateTime CreatedDate { get; set; }
		[JsonProperty("created_by")]
		public string CreatedBy { get; set; }
		[JsonProperty("last_modified_date")]
		public Nullable<DateTime> LastModifiedDate { get; set; }
		[JsonProperty("last_modified_by")]
		public string LastModifiedBy { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		//[JsonProperty("store_themes")]
		//public IEnumerable<StoreThemeViewModel> StoreThemesVM { get; set; }
		
		public ThemeViewModel(Theme entity) : this()
		{
			FromEntity(entity);
		}
		
		public ThemeViewModel()
		{
			//this.StoreThemesVM = new HashSet<StoreThemeViewModel>();
		}
		
	}
}
