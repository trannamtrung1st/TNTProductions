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

    }
}
