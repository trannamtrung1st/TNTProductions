using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models
{
    public class BaseEntityGen : FileGen
    {
        private Info Info { get; set; }

        public BaseEntityGen(Info info)
        {
            Info = info;
            Directive.Add(
                Info.ProjectName + ".Global");

            //GENERATE
            GenerateNamespace();
            GenerateIBaseEntity();
            GenerateBaseEntity();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Info.ProjectName + ".Models";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IBaseEntity
        private ContainerGen IBaseEntity { get; set; }
        private BodyGen IBaseEntityBody { get; set; }
        public void GenerateIBaseEntity()
        {
            IBaseEntity = new ContainerGen();
            IBaseEntity.Signature = "public partial interface IBaseEntity";
            IBaseEntityBody = IBaseEntity.Body;

            var s1 = new StatementGen("E To<E>();",
                "void CopyTo(object dest);");

            IBaseEntityBody.Add(
                s1, new StatementGen(""));

            NamespaceBody.Add(IBaseEntity);
        }

        //generate BaseEntity
        private ContainerGen BaseEntity { get; set; }
        private BodyGen BaseEntityBody { get; set; }
        public void GenerateBaseEntity()
        {
            BaseEntity = new ContainerGen();
            BaseEntity.Signature = "public abstract partial class BaseEntity : IBaseEntity";
            BaseEntityBody = BaseEntity.Body;

            var m1 = new ContainerGen();
            m1.Signature = "public virtual E To<E>()";
            m1.Body.Add(new StatementGen(
                "return G.Mapper.Map<E>(this);"));


            var m2 = new ContainerGen();
            m2.Signature = "public virtual void CopyTo(object dest)";
            m2.Body.Add(new StatementGen(
                "G.Mapper.Map(this, dest);"));

            BaseEntityBody.Add(
                m1, new StatementGen(""),
                m2, new StatementGen("")
                );

            NamespaceBody.Add(BaseEntity);
        }

    }
}
