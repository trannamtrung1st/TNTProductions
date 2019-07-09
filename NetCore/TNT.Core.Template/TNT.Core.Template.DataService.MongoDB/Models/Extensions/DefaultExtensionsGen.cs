using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models.Extensions
{
    public class DefaultExtensionsGen : FileGen
    {
        private readonly Info _info;

        public DefaultExtensionsGen(Info info)
        {
            _info = info;

            GenerateNamespace();
            GenerateDefaultExtensions();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + _info.ProjectName + ".Models";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        private ContainerGen Main { get; set; }
        private BodyGen MainBody { get; set; }
        public void GenerateDefaultExtensions()
        {
            Main = new ContainerGen();
            Main.Signature = "public static partial class DefaultExtensions";
            MainBody = Main.Body;

            var s1 = new StatementGen(
                "public static readonly string[] Fam = new string[]",
                "{",
                "\t\"ặẵẳằắăậẫẩầấâạãảàáa\",",
                "\t\"ệễểềếêẹẽẻèée\",",
                "\t\"ỵỹỷỳýy\",",
                "\t\"ựữửừứưụũủùúu\",",
                "\t\"ịĩỉìíi\",",
                "\t\"ợỡởờớơộỗổồốôọõỏòóo\",",
                "\t\"đd\"",
                "};"
                );

            var m1 = new ContainerGen();
            m1.Signature = "public static string ToIgnoreAccentRegex(this string input)";
            m1.Body.Add(new StatementGen(
                "var newString = new StringBuilder(\"\");",
                "foreach (var c in input)",
                "{",
                "\tvar fam = Fam.FirstOrDefault(f => f.Contains(c));",
                "\tif (fam == null)",
                "\t\tnewString.Append(c);",
                "\telse newString.Append($\"[{fam}]\");",
                "}",
                "return newString.ToString();"
                ));
            MainBody.Add(
                s1,
                m1);

            NamespaceBody.Add(Main, new StatementGen(""));
        }


    }
}
