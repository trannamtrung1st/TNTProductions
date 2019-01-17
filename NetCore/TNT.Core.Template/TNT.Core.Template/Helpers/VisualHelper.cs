using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Template.Helpers
{
    public class VisualHelper
    {
        public static int CurrentTabs { get; set; } = 0;

        public static string PrintTabs()
        {
            var tabs = new StringBuilder("");
            for (var i = 0; i < CurrentTabs; i++)
                tabs.Append("\t");
            return tabs.ToString();
        }

        public static string Enter()
        {
            return "\r\n";
        }
    }
}
