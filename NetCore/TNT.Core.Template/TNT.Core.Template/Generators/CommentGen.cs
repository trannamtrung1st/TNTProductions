using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TNT.Core.Template.Interfaces;

namespace TNT.Core.Template.Generators
{
    public enum CommentType
    {
        LINE,
        BLOCK
    }

    public class CommentGen : Generator
    {
        private string Prefix { get; set; }
        private List<string> Lines { get; set; }

        public CommentGen(string content = null, CommentType type = CommentType.LINE)
        {
            if (type == CommentType.LINE)
                Prefix = "//";
            else Prefix = "*";

            Lines = new List<string>();
            if (content != null)
                Add(content);
        }

        public void Add(string line)
        {
            Lines.Add(Prefix + line);
        }

        public override string Generate()
        {
            Resolve();
            var text = new StringBuilder("");
            var isBlock = Prefix.Equals("*");

            if (isBlock)
                text.AppendLine(T() + "/*");

            foreach (var l in Lines)
                text.AppendLine(T() + l);

            if (isBlock)
                text.AppendLine(T() + "*/");

            return text.ToString();
        }

        public override void Resolve()
        {
            for (var i = 0; i < Lines.Count; i++)
            {
                var resolvePatt = "`([^`]*)`";
                var match = Regex.Match(Lines[i], resolvePatt);
                while (match.Length > 0)
                {
                    var area = match.Groups[0].Value;
                    var key = match.Groups[1].Value;
                    var val = ResolveMapping[key];
                    Lines[i] = Lines[i].Replace(area, val);
                    match = match.NextMatch();
                }
            }
        }
    }
}
