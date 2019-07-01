using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataService.Models.Configs
{
	public partial interface IMongoDbSettings
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
		
	}
	public partial class MongoDbSettings : IMongoDbSettings
	{
		 public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		
	}
}
