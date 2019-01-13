using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Template.DataService.Data
{
    public class EntityInfo
    {
        public DataInfo Data { get; set; }
        public string EntityName { get; set; }
        public string PluralEntityName { get; set; }
        public string PKClass { get; set; }
        public string VMClass { get; set; }
        public bool Activable { get; set; }
        //key: propName - value: type
        public IDictionary<string, string> PKPropMapping { get; set; }
        public IDictionary<string, string> PropMapping { get; set; }
        public IDictionary<string, string> NavPropMapping { get; set; }
        public IDictionary<string, string> NavCollectionPropMapping { get; set; }

        public EntityInfo(DataInfo dt)
        {
            Data = dt;
            PKPropMapping = new Dictionary<string, string>();
            PropMapping = new Dictionary<string, string>();
            NavPropMapping = new Dictionary<string, string>();
            NavCollectionPropMapping = new Dictionary<string, string>();

        }

        public override string ToString()
        {
            var builder = new StringBuilder("");
            builder.AppendLine(EntityName + "(" + PluralEntityName + ")");
            builder.AppendLine("\tViewModel: " + VMClass);
            builder.AppendLine("\tActivable: " + Activable);
            builder.AppendLine("\tPKClass: " + PKClass);
            builder.AppendLine("\t---- Key(s) ----");
            foreach (var p in PKPropMapping)
            {
                builder.AppendLine("\t" + p.Key + ": " + p.Value);
            }
            builder.AppendLine("\t---- Prop(s) ----");
            foreach (var p in PropMapping)
            {
                builder.AppendLine("\t" + p.Key + ": " + p.Value);
            }
            return builder.ToString();
        }

    }
}
