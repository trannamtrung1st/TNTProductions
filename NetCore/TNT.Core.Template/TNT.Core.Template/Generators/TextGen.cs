using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.Interfaces;

namespace TNT.Core.Template.Generators
{
    public class TextGen : Generator
    {
        public string Text { get; set; }

        public override string Generate()
        {
            return Text;
        }

        public override void Resolve()
        {
            throw new NotImplementedException();
        }
    }
}
