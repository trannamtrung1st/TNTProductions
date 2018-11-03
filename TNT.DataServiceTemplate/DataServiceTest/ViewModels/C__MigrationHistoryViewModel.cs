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
	public partial class C__MigrationHistoryViewModel: BaseViewModel<C__MigrationHistory>
	{
		[JsonProperty("migration_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string MigrationId { get; set; }
		[JsonProperty("context_key", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ContextKey { get; set; }
		[JsonProperty("model", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public byte[] Model { get; set; }
		[JsonProperty("product_version", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string ProductVersion { get; set; }
		
		public C__MigrationHistoryViewModel(C__MigrationHistory entity) : this()
		{
			FromEntity(entity);
		}
		
		public C__MigrationHistoryViewModel()
		{
		}
		
	}
}
