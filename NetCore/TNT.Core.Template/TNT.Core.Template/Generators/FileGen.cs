using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.Interfaces;

namespace TNT.Core.Template.Generators
{
    public class FileGen : Generator
    {
        public DirectiveGen Directive { get; set; }
        public ContainerGen Content { get; set; }

        public FileGen()
        {
            Directive = new DirectiveGen();
            Content = new ContainerGen();
        }

        public override string Generate()
        {
            Resolve();
            var text = new StringBuilder("");
            text.Append(Directive.Generate());
            text.Append(Content.Generate());

            return text.ToString();
        }

        public void GenerateComments(BodyGen container, params string[] lines)
        {
            var cmt = new CommentGen();
            foreach (var l in lines)
                cmt.Add(l);
            container.Add(cmt);
        }

        public override void Resolve()
        {
            foreach (var kvp in ResolveMapping)
            {
                Directive.ResolveMapping[kvp.Key] = kvp.Value;
                Content.ResolveMapping[kvp.Key] = kvp.Value;
            }
        }

    }
}
