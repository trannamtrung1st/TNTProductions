using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Helpers;

namespace TNT.Core.Template.DataService.Data
{
    public class ContextInfo
    {
        public string ProjectName { get; set; }
        public string ContextName { get; set; }
        public string ContextNamespace { get; set; }
        public bool RequestScope { get; set; }
        public List<EntityInfo> Entities { get; set; }

        public ContextInfo()
        {
            Entities = new List<EntityInfo>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder("");
            builder.AppendLine("Context: " + ContextName);
            builder.AppendLine("---------------------");
            foreach (var e in Entities)
            {
                builder.AppendLine(e.ToString());
            }
            return builder.ToString();
        }
    }
}
