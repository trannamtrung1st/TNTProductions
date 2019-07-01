using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models.Extensions
{
    public class EntityExtensionGen : FileGen
    {

        private EntityInfo EInfo { get; set; }

        public EntityExtensionGen(EntityInfo eInfo)
        {
            EInfo = eInfo;

            ResolveMapping["entity"] = EInfo.EntityName;
            ResolveMapping["entityPK"] = EInfo.PKClass;
            ResolveMapping["entityVM"] = EInfo.VMClass;

            Directive.Add("MongoDB.Driver.Linq");
            //GENERATE
            GenerateNamespace();
            GenerateBaseEntityExtension();
            GenerateExtensionNamespace();
            GenerateEntityExtension();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Info.ProjectName + ".Models";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate BaseEExtension
        private ContainerGen BaseEntityExtension { get; set; }
        private BodyGen BaseEntityExtensionBody { get; set; }
        public void GenerateBaseEntityExtension()
        {
            BaseEntityExtension = new ContainerGen();
            BaseEntityExtension.Signature = "public partial class `entity` : BaseEntity";
            BaseEntityExtensionBody = BaseEntityExtension.Body;

            NamespaceBody.Add(BaseEntityExtension, new StatementGen(""));
        }


        //generate extension namespace
        public ContainerGen ENamespace { get; set; }
        private BodyGen ENamespaceBody { get; set; }
        public void GenerateExtensionNamespace()
        {
            ENamespace = new ContainerGen();
            ENamespace.ResolveMapping = ResolveMapping;
            ENamespace.Signature = "namespace " + EInfo.Info.ProjectName + ".Models.Extensions";
            ENamespaceBody = ENamespace.Body;

        }

        //generate EExtension
        private ContainerGen EntityExtension { get; set; }
        private BodyGen EntityExtensionBody { get; set; }
        public void GenerateEntityExtension()
        {
            EntityExtension = new ContainerGen();
            EntityExtension.Signature = "public static partial class `entity`Extension";
            EntityExtensionBody = EntityExtension.Body;

            var m1 = new ContainerGen();
            m1.Signature = "public static `entity` Id(this IMongoQueryable<`entity`> query, `entityPK` id)";
            m1.Body.Add(
                new StatementGen("return query.FirstOrDefault("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            var m2 = new ContainerGen();
            m2.Signature = "public static `entity` Id(this IEnumerable<`entity`> query, `entityPK` id)";
            m2.Body.Add(
                new StatementGen("return query.FirstOrDefault("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            var m3 = new ContainerGen();
            m3.Signature = "public static bool Existed(this IMongoQueryable<`entity`> query, `entityPK` id)";
            m3.Body.Add(
                new StatementGen("return query.Any("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            EntityExtensionBody.Add(
                m1, new StatementGen(""),
                m2, new StatementGen(""),
                m3, new StatementGen(""));

            ENamespaceBody.Add(EntityExtension);
        }

        private string GetKeyCompareExpr()
        {
            var expr = "\te =>";
            var name = EInfo.PKProp;
            expr += " e." + name + " == id";
            return expr;
        }
    }
}
