using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.DataService.MongoDB.Helpers;
using TNT.Core.Template.Generators;
using static TNT.Core.Template.DataService.MongoDB.Helpers.GeneralHelper;

namespace TNT.Core.Template.DataService.MongoDB.ViewModels
{
    public class VMGen : FileGen
    {
        private EntityInfo EInfo { get; set; }
        private string[] JsonIgnoreProps { get; set; }
        private string[] ExceptProps { get; set; }
        private JsonPropertyFormatEnum Style { get; set; }
        public VMGen(EntityInfo eInfo, string[] jsonIgnoreProps, string[] exceptProps, JsonPropertyFormatEnum style)
        {
            Style = style;
            EInfo = eInfo;

            ResolveMapping["entity"] = EInfo.EntityName;
            ResolveMapping["entityVM"] = EInfo.VMClass;

            JsonIgnoreProps = jsonIgnoreProps;
            ExceptProps = exceptProps;
            Directive.Add(EInfo.Info.ProjectName + ".Models",
                "Newtonsoft.Json");

            //GENERATE
            GenerateNamespace();
            GenerateVMClass();
            GenerateVMClassBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Info.ProjectName + ".ViewModels";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate VMClass
        private ContainerGen VMClass { get; set; }
        private BodyGen VMClassBody { get; set; }
        public void GenerateVMClass()
        {
            VMClass = new ContainerGen();
            VMClass.Signature = "public partial class `entityVM`: BaseViewModel<`entity`>";
            VMClassBody = VMClass.Body;

            NamespaceBody.Add(VMClass, new StatementGen(""));
        }

        //generate VMClass body
        public void GenerateVMClassBody()
        {
            var s0 = new StatementGen();
            var props = EInfo.SourceType.GetProperties();
            foreach (var p in props)
            {
                if (!ExceptProps.Contains(p.Name))
                {
                    if (JsonIgnoreProps.Contains(p.Name))
                        s0.Add("//[JsonIgnore]");
                    else
                        s0.Add("//[JsonProperty(\"" + GeneralHelper.ToJsonPropertyFormat(p.Name, Style) + "\")]");//+ "\", DefaultValueHandling = DefaultValueHandling.Ignore)]");
                    s0.Add("public " + p.PropertyType.Name + " " + p.Name + " { get; set; }");
                }
            }

            var c2 = new ContainerGen();
            c2.Signature = "public `entityVM`(`entity` entity) : base(entity)"; //: this()";

            var c21 = new ContainerGen();
            c21.Signature = "public `entityVM`()";

            VMClassBody.Add(
                s0, new StatementGen(""),
                c2, new StatementGen(""),
                c21, new StatementGen(""));
        }

    }
}
