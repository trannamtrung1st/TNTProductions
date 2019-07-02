using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TempDataService.Models.Configs;

namespace TempDataService.Models.Domains
{
	public abstract partial class BaseDomain
	{
		protected readonly IMongoClient _client;
		protected readonly IMongoDatabase _database;
		protected readonly IServiceProvider _serviceProvider;
		
		public BaseDomain(IServiceProvider provider, IMongoDbSettings settings)
		{
			_serviceProvider = provider;
			_client = new MongoClient(settings.ConnectionString);
			_database = _client.GetDatabase(settings.DatabaseName);
		}
		
	}
}
