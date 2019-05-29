using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Models.Extensions
{
    public class EntityGen : FileGen
    {

        private ContextInfo Data { get; set; }
        public EntityGen(ContextInfo dt)
        {
            Data = dt;
            Directive.Add(dt.ProjectName + ".Global");
            //GENERATE
            GenerateNamespace();
            GenerateIEntity();
            GenerateBaseEntity();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ContextNamespace;
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IBaseEntity
        public void GenerateIEntity()
        {
            var IEntity = new ContainerGen();
            IEntity.Signature = "public partial interface IBaseEntity";
            IEntity.Body.Add(
                new StatementGen(
                    "E To<E>();",
                    "void CopyTo(object dest);"
                ));
            NamespaceBody.Add(IEntity, new StatementGen(""));
        }

        //generate BaseEntity
        private ContainerGen BaseEntity { get; set; }
        private BodyGen BaseEntityBody { get; set; }
        public void GenerateBaseEntity()
        {
            var baseEntity = new ContainerGen();
            baseEntity.Signature = "public abstract partial class BaseEntity : IBaseEntity";

            var m2 = new ContainerGen();
            m2.Signature = "public virtual E To<E>()";
            m2.Body.Add(new StatementGen(
                "return G.Mapper.Map<E>(this);"));

            var m3 = new ContainerGen();
            m3.Signature = "public virtual void CopyTo(object dest)";
            m3.Body.Add(new StatementGen(
                "G.Mapper.Map(this, dest);"));

            baseEntity.Body.Add(
                m2, new StatementGen(""),
                m3, new StatementGen(""));

            NamespaceBody.Add(baseEntity, new StatementGen(""));
        }

    }
}
