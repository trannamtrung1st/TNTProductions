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
        public bool ActiveCol { get; set; } //or else Deactive col
        public List<EntityInfo> Entities { get; set; }

        public ContextInfo()
        {
            Entities = new List<EntityInfo>();
        }

        //====== TEST =======
        //private void Test()
        //{
        //    ContextName = "UniLinkEntities";
        //    var supplyInfo = new EntityInfo(this)
        //    {
        //        EntityName = "Supply",
        //        PKClass = "SupplyPK",
        //        VMClass = "SupplyViewModel",
        //        Activable = true,
        //        PluralEntityName = GeneralHelper.PluralizeNoun("Supply"),
        //        PKPropMapping = new Dictionary<string, string>()
        //        {
        //            { "PromotionId", "int"},
        //            { "ToolId", "int"}
        //        }
        //    };

        //    var toolInfo = new EntityInfo(this)
        //    {
        //        EntityName = "Tool",
        //        PKClass = "int",
        //        VMClass = "ToolViewModel",
        //        Activable = true,
        //        PluralEntityName = GeneralHelper.PluralizeNoun("Tool"),
        //        PKPropMapping = new Dictionary<string, string>()
        //        {
        //            {"ToolId", "int" }
        //        }
        //    };

        //    Entities.Add(toolInfo);
        //    Entities.Add(supplyInfo);
        //}

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
