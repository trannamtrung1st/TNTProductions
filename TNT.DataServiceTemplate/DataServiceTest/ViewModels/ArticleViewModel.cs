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
	public partial class ArticleViewModel: BaseViewModel<Article>
	{
		[JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int ID { get; set; }
		[JsonProperty("store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public int StoreId { get; set; }
		[JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Name { get; set; }
		[JsonProperty("decription", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Decription { get; set; }
		[JsonProperty("content_html", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContentHTML { get; set; }
		[JsonProperty("date_create", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public DateTime DateCreate { get; set; }
		[JsonProperty("is_available", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public bool IsAvailable { get; set; }
		[JsonProperty("thumbnail", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Thumbnail { get; set; }
		[JsonProperty("store", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public StoreViewModel StoreVM { get; set; }
		
		public ArticleViewModel(Article entity) : this()
		{
			FromEntity(entity);
		}
		
		public ArticleViewModel()
		{
		}
		
	}
}
