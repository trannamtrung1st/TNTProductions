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
            ResolveMapping["entityPK"] = EInfo.PKClass;
            ResolveMapping["entityVM"] = EInfo.VMClass;

            Directive.Add(EInfo.Data.ProjectName + ".ViewModels",
                EInfo.Data.ProjectName + ".Global");
            //GENERATE
            GenerateNamespace();
            GenerateEntityPKClass();
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
            ENamespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models.Extensions";
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
            m1.Signature = "public static `entity` Id(this IQueryable<`entity`> query, `entityPK` key)";
            m1.Body.Add(
                new StatementGen("return query.FirstOrDefault("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            var m2 = new ContainerGen();
            m2.Signature = "public static `entity` Id(this IEnumerable<`entity`> query, `entityPK` key)";
            m2.Body.Add(
                new StatementGen("return query.FirstOrDefault("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            var m3 = new ContainerGen();
            m3.Signature = "public static IQueryable<`entity`> Active(this IQueryable<`entity`> query)";
            var getActive = "return query" + (EInfo.Data.ActiveCol ? ".Where(e => e.Active == true);" : ".Where(e => e.Deactive == false);");
            m3.Body.Add(new StatementGen(getActive));

            var m4 = new ContainerGen();
            m4.Signature = "public static IQueryable<`entity`> NotActive(this IQueryable<`entity`> query)";
            m4.Body.Add(new StatementGen(
                "return query" + (EInfo.Data.ActiveCol ? ".Where(e => e.Active == false);" : ".Where(e => e.Deactive == true);")));

            var m5 = new ContainerGen();
            m5.Signature = "public static IEnumerable<`entity`> Active(this IEnumerable<`entity`> query)";
            m5.Body.Add(new StatementGen(
                "return query" + (EInfo.Data.ActiveCol ? ".Where(e => e.Active == true);" : ".Where(e => e.Deactive == false);")));

            var m6 = new ContainerGen();
            m6.Signature = "public static IEnumerable<`entity`> NotActive(this IEnumerable<`entity`> query)";
            m6.Body.Add(new StatementGen(
                "return query" + (EInfo.Data.ActiveCol ? ".Where(e => e.Active == false);" : ".Where(e => e.Deactive == true);")));

            var m7 = new ContainerGen();
            m7.Signature = "public static bool Existed(this IQueryable<`entity`> query, `entityPK` key)";
            m7.Body.Add(
                new StatementGen("return query.Any("),
                new StatementGen(GetKeyCompareExpr() + ");"));

            EntityExtensionBody.Add(
                m1, new StatementGen(""),
                m2, new StatementGen(""),
                m7, new StatementGen(""));

            if (EInfo.Activable)
            {
                EntityExtensionBody.Add(
                m3, new StatementGen(""),
                m4, new StatementGen(""),
                m5, new StatementGen(""),
                m6, new StatementGen(""));
            }

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
