using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Extensions
{
    public class EntityGen : FileGen
    {

        private DataInfo Data { get; set; }
        public EntityGen(DataInfo dt)
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
            Namespace.Signature = "namespace " + Data.ProjectName + ".Models";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IBaseEntity
        private ContainerGen IBaseEntity { get; set; }
        private BodyGen IBaseEntityBody { get; set; }
        public void GenerateIEntity()
        {
            var IEntity = new ContainerGen();
            IEntity.Signature = "public partial interface IEntity";
            IEntity.Body.Add(
                new StatementGen(
                    "IVM To<IVM>();",
                    "void CopyTo(object dest);"
                ));
            NamespaceBody.Add(IEntity, new StatementGen(""));

            IBaseEntity = new ContainerGen();
            IBaseEntity.Signature = "public partial interface IBaseEntity<VM>: IEntity";
            IBaseEntityBody = IBaseEntity.Body;

            IBaseEntityBody.Add(
                new StatementGen(
                    "VM ToViewModel();"
                ));

            NamespaceBody.Add(IBaseEntity, new StatementGen(""));
        }

        //generate BaseEntity
        private ContainerGen BaseEntity { get; set; }
        private BodyGen BaseEntityBody { get; set; }
        public void GenerateBaseEntity()
        {
            var baseEntity = new ContainerGen();
            baseEntity.Signature = "public abstract partial class BaseEntity<VM> : IBaseEntity<VM>";

            var m1 = new StatementGen("public abstract VM ToViewModel();");

            var m2 = new ContainerGen();
            m2.Signature = "public virtual IVM To<IVM>()";
            m2.Body.Add(new StatementGen(
                "return G.Mapper.Map<IVM>(this);"));

            var m3 = new ContainerGen();
            m3.Signature = "public virtual void CopyTo(object dest)";
            m3.Body.Add(new StatementGen(
                "G.Mapper.Map(this, dest);"));

            baseEntity.Body.Add(
                m1, new StatementGen(""),
                m2, new StatementGen(""),
                m3, new StatementGen(""));

            NamespaceBody.Add(baseEntity, new StatementGen(""));
        }

    }
}
