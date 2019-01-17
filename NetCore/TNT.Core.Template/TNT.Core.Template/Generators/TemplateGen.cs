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
    public interface ITemplate : IGenerator
    {
    }

    public class TemplateGen : Generator
    {
        private List<string> Directives { get; set; }
        private List<ITemplate> Contents { get; set; }

        public TemplateGen(params string[] addedDirectives)
        {
            Contents = new List<ITemplate>();
            Directives = new List<string>()
            {
                "template debug=\"true\" hostSpecific=\"true\"",
                "output extension=\".cs\"",
                "Assembly Name=\"System.Core\"",
                "Assembly Name=\"System.Windows.Forms\"",
                "import namespace=\"System\"",
                "import namespace=\"System.IO\"",
                "import namespace=\"System.Diagnostics\"",
                "import namespace=\"System.Linq\"",
                "import namespace=\"System.Collections\"",
                "import namespace=\"System.Collections.Generic\"",
            };
            AddDirectives(addedDirectives);
        }

        public override string Generate()
        {
            Resolve();
            var builder = new StringBuilder("");
            foreach (var d in Directives)
                builder.AppendLine("<#@ " + d + " #>");
            foreach (var t in Contents)
                builder.Append(t.Generate());
            return builder.ToString();
        }

        public void Add(params ITemplate[] temps)
        {
            foreach (var t in temps)
                if (t != null)
                    Contents.Add(t);
        }

        public void AddDirectives(params string[] directives)
        {
            if (directives != null)
                Directives.AddRange(directives);
        }

        public override void Resolve()
        {
            foreach (var kvp in ResolveMapping)
            {
                foreach (var m in Contents)
                {
                    m.ResolveMapping[kvp.Key] = kvp.Value;
                }
            }
            for (var i = 0; i < Directives.Count; i++)
            {
                var resolvePatt = "`([^`]*)`";
                var match = Regex.Match(Directives[i], resolvePatt);
                while (match.Length > 0)
                {
                    var area = match.Groups[0].Value;
                    var key = match.Groups[1].Value;
                    var val = ResolveMapping[key];
                    Directives[i] = Directives[i].Replace(area, val);
                    match = match.NextMatch();
                }
            }
        }
    }

    public class TemplateTextBlock : Generator, ITemplate
    {
        private string Content { get; set; }

        public TemplateTextBlock(string content)
        {
            Content = content;
        }

        public override string Generate()
        {
            Resolve();
            var builder = new StringBuilder("");
            builder.Append(Content);
            return builder.ToString();
        }

        public override void Resolve()
        {
            var resolvePatt = "`([^`]*)`";
            var match = Regex.Match(Content, resolvePatt);
            while (match.Length > 0)
            {
                var area = match.Groups[0].Value;
                var key = match.Groups[1].Value;
                var val = ResolveMapping[key];
                Content = Content.Replace(area, val);
                match = match.NextMatch();
            }
        }
    }

    public class TemplateCodeBlock : Generator, ITemplate
    {
        private List<IGenerator> Members { get; set; }

        public TemplateCodeBlock(params IGenerator[] members)
        {
            Members = new List<IGenerator>();
            Add(members);
        }

        public void Add(params IGenerator[] members)
        {
            if (members != null)
                foreach (var m in members)
                    if (m != null)
                        Members.Add(m);
        }

        public override string Generate()
        {
            Resolve();
            var builder = new StringBuilder("");
            builder.AppendLine("<#");
            VisualHelper.CurrentTabs++;
            foreach (var m in Members)
                builder.Append(m.Generate());
            VisualHelper.CurrentTabs--;
            builder.AppendLine("#>");

            return builder.ToString();
        }

        public override void Resolve()
        {
            foreach (var kvp in ResolveMapping)
            {
                foreach (var m in Members)
                {
                    m.ResolveMapping[kvp.Key] = kvp.Value;
                }
            }
        }
    }

}
