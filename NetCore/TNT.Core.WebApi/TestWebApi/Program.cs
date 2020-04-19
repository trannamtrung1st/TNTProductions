using System;
using System.Collections.Generic;
using TNT.Core.WebApi.Postman;

namespace TestWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new RequestItemBuilder()
                .Url("{{web_api_url}}", "{{web_api_url}}", new List<Query>()
                {
                    new Query{Key="",Value=""},
                    new Query{Key="",Value=""},
                })
                .Build();
        }
    }
}
