using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Template.DataService.MongoDB.Data
{
    public class EntityInfo
    {
        public Info Info { get; set; }
        public Type SourceType { get; set; }
        public string EntityName { get; set; }
        public string PKClass { get; set; }
        public string PKProp { get; set; }
        public string VMClass { get; set; }
        public EntityInfo(Info info)
        {
            Info = info;
        }
    }
}
