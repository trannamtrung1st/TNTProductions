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
    public class StatementGen : Generator
    {
        private List<string> Contents { get; set; }
        private bool NeedTabs { get; set; }

        public StatementGen(params string[] content)
        {
            Contents = new List<string>();
            if (content != null)
                Add(content);
        }

        public StatementGen(bool needTabs = false, params string[] content)
        {
            NeedTabs = needTabs;
            Contents = new List<string>();
            if (content != null)
                Add(content);
        }

        public void Add(params string[] lines)
        {
            foreach (var l in lines)
            {
                if (l != null)
                    Contents.Add(l);
            }
        }

        public override string Generate()
        {
            Resolve();
            var text = new StringBuilder("");

            if (NeedTabs)
                VisualHelper.CurrentTabs++;
            foreach (var c in Contents)
                text.AppendLine(T() + c);
            if (NeedTabs)
                VisualHelper.CurrentTabs--;

            return text.ToString();
        }

        public override void Resolve()
        {
            for (var i = 0; i < Contents.Count; i++)
            {
                var resolvePatt = "`([^`]*)`";
                var match = Regex.Match(Contents[i], resolvePatt);
                while (match.Length > 0)
                {
                    var area = match.Groups[0].Value;
                    var key = match.Groups[1].Value;
                    var val = ResolveMapping[key];
                    Contents[i] = Contents[i].Replace(area, val);
                    match = match.NextMatch();
                }
            }
        }

    }
}
