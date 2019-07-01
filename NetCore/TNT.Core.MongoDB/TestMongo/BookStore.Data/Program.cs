using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BookStore.Data
{

    class Program
    {
        static void Main(string[] args)
        {
            //var serCol = new ServiceCollection();
            //G.Configure(serCol, new MongoDbSettings()
            //{
            //    ConnectionString = "mongodb://sa:123456@localhost:27017",
            //    DatabaseName = "BookstoreDb",
            //});
            //serCol.AddSingleton<TestDomain>();
            //var provider = serCol.BuildServiceProvider();

            //var domain = provider.GetService<TestDomain>();
            //domain.CreateWithTransaction(new Books()
            //{
            //    Id = Guid.NewGuid().ToString()
            //});
            //var allBooks = domain.Books.ToList();

        }
    }
}
