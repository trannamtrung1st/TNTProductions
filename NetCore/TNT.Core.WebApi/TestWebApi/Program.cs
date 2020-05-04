using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using TNT.Core.WebApi.Postman;

namespace TestWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiVarName = "web_api_url";
            var apiVarHolder = apiVarName.ToPlaceholder();

            #region LogsController
            var getLogs = new RequestItemBuilder()
                .Name("Get logs")
                .Method(HttpMethod.Get.Method)
                .Url($"{apiVarHolder}/api/logs", new List<Query>
                {
                    new Query{ key = "date", value = DateTime.Now.ToString() },
                    new Query{ key = "sorts", value = "ddate" },
                    new Query{ key = "page", value = "0" },
                    new Query{ key = "limit", value = "50" },
                    new Query{ key = "count_total", value = "true" },
                })
                .Description("Get all logs in date")
                .Build();
            var logFolder = new FolderItemBuilder()
                .Description("Logs controller")
                .Name("Logs")
                .AddItems(getLogs)
                .Build();
            #endregion

            #region Collection
            var collection = new CollectionBuilder()
                .Info("Test collection", "This is test collection")
                .AddStringVariables(new Variable
                {
                    key = apiVarName,
                    value = "http://localhost:64878",
                })
                .AddItems(logFolder)
                .Build();
            #endregion

            var json = JsonConvert.SerializeObject(collection, Formatting.Indented);
            File.WriteAllText($"./postman-collection.json", json);
        }
    }
}
