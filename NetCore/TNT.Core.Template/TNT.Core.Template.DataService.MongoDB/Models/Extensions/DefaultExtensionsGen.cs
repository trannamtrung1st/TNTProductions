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

            var m1 = new ContainerGen();
            m1.Signature = "public static string ToIgnoreAccentRegex(this string input)";
            m1.Body.Add(new StatementGen(
                "var newString = new StringBuilder(\"\");",
                "foreach (var c in input)",
                "{",
                "\tswitch (c)",
                "\t{",
                "\t\tcase 'a':",
                "\t\t\tnewString.Append(\"[ặẵẳằắăậẫẩầấâạãảàáa]\");",
                "\t\tbreak;",
                "\t\tcase 'e':",
                "\t\t\tnewString.Append(\"[ệễểềếêẹẽẻèée]\");",
                "\t\tbreak;",
                "\t\tcase 'y':",
                "\t\t\tnewString.Append(\"[ỵỹỷỳýy]\");",
                "\t\tbreak;",
                "\t\tcase 'u':",
                "\t\t\tnewString.Append(\"[ựữửừứưụũủùúu]\");",
                "\t\tbreak;",
                "\t\tcase 'i':",
                "\t\t\tnewString.Append(\"[ịĩỉìíi]\");",
                "\t\tbreak;",
                "\t\tcase 'o':",
                "\t\t\tnewString.Append(\"[ợỡởờớơộỗổồốôọõỏòóo]\");",
                "\t\tbreak;",
                "\t\tdefault:",
                "\t\t\tnewString.Append(c);",
                "\t\tbreak;",
                "\t}",
                "}",
                "return newString.ToString();"
                ));
            MainBody.Add(m1);

            NamespaceBody.Add(Main, new StatementGen(""));
        }


    }
}
