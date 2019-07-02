using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TempDataService.Global;
using TempDataService.Models.Configs;
using TempDataService.Models.Repositories;
using TNT.Core.Template.DataService.MongoDB;

namespace BookStore.Data
{

    class Program
    {
        static void Main(string[] args)
        {
            var serCol = new ServiceCollection();
            G.Configure(serCol, new MongoDbSettings()
            {
                ConnectionString = "mongodb://sa:123456@localhost:27017",
                DatabaseName = "BookstoreDb",
            });
            var provider = serCol.BuildServiceProvider();
            var client = new MongoClient(provider.GetService<IMongoDbSettings>().ConnectionString);
            var db = client.GetDatabase("BookstoreDb");
            var lisdb = db.ListCollectionNames().ToList();
            var repo = provider.GetService<ITestBooksRepository>();

            repo.Create(new TempDataService.Models.TestBooks()
            {
                Id = Guid.NewGuid().ToString()
            });

            var list = repo.Get().ToList();

            Console.WriteLine(list.Count);

            //SimpleGenerator.Generate("../../../Models", "BookStore.Data.Models", "../../../../TempDataService", "TempDataService",
            //    TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper.JsonPropertyFormatEnum.JsonStyle);
        }

    }
}
