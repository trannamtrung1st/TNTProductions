using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TNT.Core.Template.DataService.MongoDB;
using TNT.Core.Template.DataService.MongoDB.Schema;

namespace GeneratorTest
{
    public class Dynamic
    {
        [BsonId]
        public string Id { get; set; }

        public IEnumerable<Metadata> Metadatas { get; set; }
        //public string NewField { get; set; }
    }

    public class Metadata
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public object Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //SimpleGenerator.Generate(
            //    "../../../Models",
            //    "GeneratorTest.Models",
            //    "../../../../TestDataService",
            //    "TestDataService",
            //    TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper.JsonPropertyFormatEnum.JsonStyle);

            //var mongo = new MongoClient("mongodb://sa:123456@localhost:27017/?authSource=admin&replicaSet=rs0");
            //var testDB = mongo.GetDatabase("DynamicDB");
            //var collection = testDB.GetCollection<Dynamic>("Dynamic");
            //var dynamic = collection.AsQueryable().ToList();
            //rename, set, unset, remove collection 

        }
    }
}
