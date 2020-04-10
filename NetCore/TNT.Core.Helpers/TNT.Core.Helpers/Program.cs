using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        [JsonProperty("child")]
        public A Child { get; set; }
    }

    public class AVM
    {
        [JsonProperty("prop_a")]
        public string A { get; set; }
        [JsonProperty("prop_b")]
        public string B { get; set; }
        [JsonProperty("child")]
        public AVM Child { get; set; }
    }

    public class Global
    {
        public List<A> list { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<A>()
            {
                new A(){PropA = "tnt", PropB = "ccc"},
                new A(){PropA = "tnt", PropB = "ccc", Child = new A{
                } },
                new A(){PropA = "tnt", PropB = "ccc", Child = new A{
                    PropA = "test",
                    Child = new A
                    {
                        PropA = "test OKOKK"
                    }
                } }
            };

            //var test = list
            //    .SelectOnly<A, AVM>(SelectOption.ByPropertyName, "A=PropA", "Child.Child.A=Child?.Child?.PropA")
            //    .ToList();

            //var test2 = list
            //    .SelectOnly(SelectOption.ByPropertyName, "PropA", "Child?.Child?.PropA")
            //    .ToList();

            //var test3 = list
            //    .SelectOnly(false, SelectOption.ByPropertyName, "PropA", "Child?.Child?.PropA")
            //    .ToList();
            //var test4 = list
            //    .SelectOnly(true, SelectOption.ByPropertyName, "PropA", "Child?.Child?.PropA")
            //    .ToList();

            //var test5 = list
            //    .SelectOnly<A, AVM>(SelectOption.ByJsonProperty, "prop_a=prop_a", "child.child.prop_a=child?.child?.prop_a")
            //    .ToList();

            //var test6 = list
            //    .SelectOnly(SelectOption.ByJsonProperty, "prop_a", "child?.child?.prop_a")
            //    .ToList();

            //var test7 = list
            //    .SelectOnly(false, SelectOption.ByJsonProperty, "prop_a", "child?.child?.prop_a")
            //    .ToList();

            //var test8 = list
            //    .SelectOnly(true, SelectOption.ByJsonProperty, "prop_a", "child?.child?.prop_a")
            //    .ToList();

            var global = new Global
            {
                list = list
            };
            var options = ScriptOptions.Default
                .WithReferences(Assembly.Load("TNT.Core.Helpers"))
                .WithImports("TNT.Core.Helpers.Data",
                "TNT.Core.Helpers",
                "System.Linq");
            var obj = CSharpScript.EvaluateAsync(
                    code: "return list.ToList()",
                    options: options,
                    globals: global,
                    globalsType: typeof(Global)).Result;

            //Console.WriteLine(JsonConvert.SerializeObject(test, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test2, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test3, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test4, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test5, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test6, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test7, Formatting.Indented));
            //Console.WriteLine("---------------");
            //Console.WriteLine(JsonConvert.SerializeObject(test8, Formatting.Indented));
            //Console.WriteLine("---------------");
        }
    }
}
