using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.Helpers;
using TNT.Core.Template.Interfaces;

namespace TNT.Core.Template.Generators
{
    public class BodyGen : Generator
    {
        private List<IGenerator> Members { get; set; }

        public BodyGen(params IGenerator[] members)
        {
            Members = new List<IGenerator>();
            Add(members);
        }

        public void Add(params IGenerator[] members)
        {
            foreach (var m in members)
            {
                if (m != null)
                    Members.Add(m);
            }
        }

        public override string Generate()
        {
            Resolve();
            var text = new StringBuilder("");
            text.AppendLine(T() + "{");
            VisualHelper.CurrentTabs++;

            foreach (var m in Members)
                text.Append(m.Generate());

            VisualHelper.CurrentTabs--;
            text.AppendLine(T() + "}");

            return text.ToString();
        }

        public override void Resolve()
        {
            foreach (var m in Members)
            {
                foreach (var kvp in ResolveMapping)
                {
                    m.ResolveMapping[kvp.Key] = kvp.Value;
                }
            }
        }
    }
}
