using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TNT.Core.Template.Helpers;
using TNT.Core.Template.Interfaces;

namespace TNT.Core.Template.Generators
{
    public class ContainerGen : Generator
    {
        public string Signature { get; set; }
        public BodyGen Body { get; set; }

        public ContainerGen()
        {
            Body = new BodyGen();
        }

        public override string Generate()
        {
            Resolve();
            var text = new StringBuilder("");
            text.AppendLine(T() + Signature);
            text.Append(Body.Generate());

            return text.ToString();
        }

        public override void Resolve()
        {
            var resolvePatt = "`([^`]*)`";
            var match = Regex.Match(Signature, resolvePatt);
            while (match.Length > 0)
            {
                var area = match.Groups[0].Value;
                var key = match.Groups[1].Value;
                var val = ResolveMapping[key];
                Signature = Signature.Replace(area, val);
                match = match.NextMatch();
            }

            foreach (var kvp in ResolveMapping)
            {
                Body.ResolveMapping[kvp.Key] = kvp.Value;

            }
        }
    }
}
