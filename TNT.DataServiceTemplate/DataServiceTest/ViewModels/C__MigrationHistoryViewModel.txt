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
		[JsonProperty("migration_id")]
		public string MigrationId { get; set; }
		[JsonProperty("context_key")]
		public string ContextKey { get; set; }
		[JsonProperty("model")]
		public byte[] Model { get; set; }
		[JsonProperty("product_version")]
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
