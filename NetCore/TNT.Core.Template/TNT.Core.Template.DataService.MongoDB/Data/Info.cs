using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Template.DataService.MongoDB.Data
{
    public class Info
    {
        public string ProjectName { get; set; }
        public List<EntityInfo> Entities { get; set; } = new List<EntityInfo>();
    }
}
