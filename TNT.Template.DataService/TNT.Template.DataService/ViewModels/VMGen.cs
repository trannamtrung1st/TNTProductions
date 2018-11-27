using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.Template.DataService.Helpers;
using TNT.TemplateAPI.Generators;
using static TNT.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Template.DataService.ViewModels
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
            ResolveMapping.Add("entity", EInfo.EntityName);
            ResolveMapping.Add("entityVM", EInfo.VMClass);
            JsonIgnoreProps = jsonIgnoreProps;
            ExceptProps = exceptProps;
            Directive.Add(EInfo.Data.ProjectName + ".Global", EInfo.Data.ProjectName + ".Models",
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
            Namespace.Signature = "namespace " + EInfo.Data.ProjectName + ".ViewModels";
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

            NamespaceBody.Add(VMClass);
        }

        //generate VMClass body
        public void GenerateVMClassBody()
        {
            var s0 = new StatementGen();
            foreach (var p in EInfo.PropMapping)
            {
                if (!ExceptProps.Contains(p.Key))
                {
                    if (JsonIgnoreProps.Contains(p.Key))
                        s0.Add("[JsonIgnore]");
                    else
                        s0.Add("[JsonProperty(\"" + GeneralHelper.ToJsonPropertyFormat(p.Key, Style) + "\")]");//+ "\", DefaultValueHandling = DefaultValueHandling.Ignore)]");
                    s0.Add("public " + p.Value + " " + p.Key + " { get; set; }");
                }
            }
            foreach (var p in EInfo.NavPropMapping)
            {
                if (!ExceptProps.Contains(p.Key))
                {
                    if (JsonIgnoreProps.Contains(p.Key))
                        s0.Add("[JsonIgnore]");
                    else
                        s0.Add("[JsonProperty(\"" + GeneralHelper.ToJsonPropertyFormat(p.Key, Style) + "\")]");// + "\", DefaultValueHandling = DefaultValueHandling.Ignore)]");
                    s0.Add("public " + p.Value + " " + p.Key + "VM { get; set; }");
                }
            }
            foreach (var p in EInfo.NavCollectionPropMapping)
            {
                if (!ExceptProps.Contains(p.Key))
                {
                    if (JsonIgnoreProps.Contains(p.Key))
                        s0.Add("[JsonIgnore]");
                    else
                        s0.Add("[JsonProperty(\"" + GeneralHelper.ToJsonPropertyFormat(p.Key, Style) + "\")]");// + "\", DefaultValueHandling = DefaultValueHandling.Ignore)]");
                    s0.Add("public " + p.Value + " " + p.Key + "VM { get; set; }");
                }
            }

            var c2 = new ContainerGen();
            c2.Signature = "public `entityVM`(`entity` entity) : this()";
            c2.Body.Add(new StatementGen("FromEntity(entity);"));

            var c21 = new ContainerGen();
            c21.Signature = "public `entityVM`()";
            foreach (var p in EInfo.NavCollectionPropMapping)
            {
                var type = p.Value;
                var firstBracket = type.IndexOf('<') + 1;
                type = type.Substring(firstBracket, type.IndexOf('>') - firstBracket);
                c21.Body.Add(new StatementGen("this." + p.Key + "VM = new HashSet<" + type + ">();"));
            }

            VMClassBody.Add(
                s0, new StatementGen(""),
                c2, new StatementGen(""),
                c21, new StatementGen(""));
        }

    }
}
