using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TNT.Core.Helpers.Cryptography;
using TNT.Core.Helpers.Data;

namespace TNT.Core.Helpers
{
    public class A
    {
        [JsonProperty("prop_a")]
        public string PropA { get; set; }
        [JsonProperty("prop_b")]
        public string PropB { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<A>()
            {
                new A(){ PropA = "asd", PropB = "dsc"},
                new A(){PropA = "tnt", PropB = "ccc" }
            };

            var test = list.SelectOnly(false, SelectOption.ByJsonProperty, "prop_a", "prop_b");
        }
    }
}
