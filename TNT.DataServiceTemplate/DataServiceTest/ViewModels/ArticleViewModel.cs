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
		[JsonProperty("iD")]
		public int ID { get; set; }
		[JsonProperty("storeId")]
		public int StoreId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("decription")]
		public string Decription { get; set; }
		[JsonProperty("contentHTML")]
		public string ContentHTML { get; set; }
		[JsonProperty("dateCreate")]
		public DateTime DateCreate { get; set; }
		[JsonProperty("isAvailable")]
		public bool IsAvailable { get; set; }
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }
		[JsonProperty("store")]
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
