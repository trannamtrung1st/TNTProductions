using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TNT.Core.Template.Interfaces;

namespace TNT.Core.Template.Generators
{
    public class DirectiveGen : Generator
    {
        private HashSet<string> Namespaces { get; set; }

        public DirectiveGen(params string[] namespaces)
        {
            Namespaces = new HashSet<string>()
            {
                "System","System.Collections.Generic","System.Linq","System.Text",
                "System.Threading.Tasks"
            };
            Add(namespaces);
        }

        public void Add(params string[] namespaces)
        {
            foreach (var n in namespaces)
                if (n != null)
                    Namespaces.Add(n);
        }

        public override string Generate()
        {
            Resolve();
            var text = new StringBuilder("");

            foreach (var n in Namespaces)
            {
                text.AppendLine("using " + n + ";");
            }
            text.AppendLine();

            return text.ToString();
        }

        public override void Resolve()
        {
            foreach (var n in Namespaces)
            {
                var resolvePatt = "`([^`]*)`";
                var match = Regex.Match(n, resolvePatt);
                while (match.Length > 0)
                {
                    var area = match.Groups[0].Value;
                    var key = match.Groups[1].Value;
                    var val = ResolveMapping[key];
                    Namespaces.Remove(n);
                    Namespaces.Add(n.Replace(area, val));
                    match = match.NextMatch();
                }
            }
        }

    }
}
