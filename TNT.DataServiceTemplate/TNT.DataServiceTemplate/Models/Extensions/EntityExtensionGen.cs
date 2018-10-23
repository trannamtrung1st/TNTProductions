using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Extensions
{
    public class EntityExtensionGen : FileGen
    {

        private EntityInfo EInfo { get; set; }

        public EntityExtensionGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            ResolveMapping.Add("entity", EInfo.EntityName);
            ResolveMapping.Add("entityPK", EInfo.PKClass);
            ResolveMapping.Add("entityVM", EInfo.VMClass);

            Directive.Add(EInfo.Data.ProjectName + ".ViewModels",
                EInfo.Data.ProjectName + ".Global");
            //GENERATE
            GenerateNamespace();
            GenerateEntityPKClass();
            GenerateEntityExtension();
            GenerateExtensionMethod();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        private ContainerGen EntityPKClass { get; set; }
        private BodyGen EntityPKClassBody { get; set; }
        public void GenerateEntityPKClass()
        {
            if (EInfo.PKPropMapping.Count > 1)
            {
                EntityPKClass = new ContainerGen();
                EntityPKClass.Signature = "public partial class `entityPK`";
                EntityPKClassBody = EntityPKClass.Body;

                var statements = new StatementGen();
                foreach (var kvp in EInfo.PKPropMapping)
                {
                    var propName = kvp.Key;
                    var propType = kvp.Value;
                    statements.Add("public " + propType + " " + propName + " { get; set; }");
                }

                EntityPKClassBody.Add(statements);

                NamespaceBody.Add(EntityPKClass, new StatementGen(""));
            }
        }

        //generate EExtension
        private ContainerGen EntityExtension { get; set; }
        private BodyGen EntityExtensionBody { get; set; }
        public void GenerateEntityExtension()
        {
            EntityExtension = new ContainerGen();
            EntityExtension.Signature = "public partial class `entity` : BaseEntity<`entityVM`>";
            EntityExtensionBody = EntityExtension.Body;

            NamespaceBody.Add(EntityExtension);
        }

        public void GenerateExtensionMethod()
        {
            var m1 = new ContainerGen();
            m1.Signature = "public override `entityVM` ToViewModel()";
            m1.Body.Add(new StatementGen(
                "return new `entityVM`(this);"));

            EntityExtensionBody.Add(
                m1, new StatementGen(""));
        }

    }
}
