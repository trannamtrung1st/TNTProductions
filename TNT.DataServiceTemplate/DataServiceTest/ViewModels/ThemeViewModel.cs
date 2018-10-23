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
		[JsonProperty("themeId")]
		public int ThemeId { get; set; }
		[JsonProperty("themeName")]
		public string ThemeName { get; set; }
		[JsonProperty("themeFolderUrl")]
		public string ThemeFolderUrl { get; set; }
		[JsonProperty("themeStyle")]
		public string ThemeStyle { get; set; }
		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
		[JsonProperty("createdDate")]
		public DateTime CreatedDate { get; set; }
		[JsonProperty("createdBy")]
		public string CreatedBy { get; set; }
		[JsonProperty("lastModifiedDate")]
		public Nullable<DateTime> LastModifiedDate { get; set; }
		[JsonProperty("lastModifiedBy")]
		public string LastModifiedBy { get; set; }
		[JsonProperty("active")]
		public bool Active { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("storeThemes")]
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
