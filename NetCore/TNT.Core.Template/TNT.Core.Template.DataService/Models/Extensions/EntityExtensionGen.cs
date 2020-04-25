using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Models.Extensions
{
    public class EntityExtensionGen : FileGen
    {

        private EntityInfo EInfo { get; set; }

        public EntityExtensionGen(EntityInfo eInfo)
        {
            EInfo = eInfo;

            ResolveMapping["entity"] = EInfo.EntityName;
            ResolveMapping["entityNml"] = EInfo.NormalizedName;
            ResolveMapping["entityPK"] = EInfo.PKClass;
            ResolveMapping["entityVM"] = EInfo.VMClass;

            Directive.Add(EInfo.Data.ProjectName + ".ViewModels",
                EInfo.Data.ContextNamespace,
                EInfo.Data.ProjectName + ".Global");
            if (EInfo.RelatedReferences != null)
                foreach (var d in EInfo.RelatedReferences)
                    Directive.Add(d);
            //GENERATE
            GenerateNamespace();
            GenerateEntityPKClass();
            GenerateExtensionNamespace();
            GenerateEntityExtension();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Data.ContextNamespace;
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

        //generate extension namespace
        public ContainerGen ENamespace { get; set; }
        private BodyGen ENamespaceBody { get; set; }
        public void GenerateExtensionNamespace()
        {
            ENamespace = new ContainerGen();
            ENamespace.ResolveMapping = ResolveMapping;
            ENamespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models.Extensions";
            ENamespaceBody = ENamespace.Body;

        }

        //generate EExtension
        private ContainerGen EntityExtension { get; set; }
        private BodyGen EntityExtensionBody { get; set; }
        public void GenerateEntityExtension()
        {
            EntityExtension = new ContainerGen();
            EntityExtension.Signature = "public static partial class `entityNml`Extension";
            EntityExtensionBody = EntityExtension.Body;

            var m1 = new ContainerGen();
            m1.Signature = "public static `entity` Id(this IQueryable<`entity`> query, `entityPK` key)";
            m1.Body.Add(
                new StatementGen("return query.FirstOrDefault("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            var m2 = new ContainerGen();
            m2.Signature = "public static `entity` Id(this IEnumerable<`entity`> query, `entityPK` key)";
            m2.Body.Add(
                new StatementGen("return query.FirstOrDefault("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            var m7 = new ContainerGen();
            m7.Signature = "public static bool Existed(this IQueryable<`entity`> query, `entityPK` key)";
            m7.Body.Add(
                new StatementGen("return query.Any("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            EntityExtensionBody.Add(
                m1, new StatementGen(""),
                m2, new StatementGen(""),
                m7, new StatementGen(""));

            ENamespaceBody.Add(EntityExtension);
        }

        private string GetKeyCompareExpr()
        {
            var expr = "\te =>";
            if (EInfo.PKPropMapping.Count == 1)
            {
                var name = EInfo.PKPropMapping.Keys.ToList()[0];
                expr += " e." + name + " == key";
            }
            else
            {
                foreach (var prop in EInfo.PKPropMapping)
                {
                    var name = prop.Key;
                    var type = prop.Value;
                    expr += " e." + name + " == key." + name + " &&";
                }
                expr = expr.Remove(expr.Length - 3);
            }
            return expr;
        }
    }

}
