using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Services
{
    public class EntityServiceGen : FileGen
    {

        private EntityInfo EInfo { get; set; }
        public EntityServiceGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            var dt = EInfo.Data;
            Directive.Add("System.Linq.Expressions",
                dt.ProjectName + ".Utilities",
                dt.ProjectName + ".Managers",
                dt.ProjectName + ".Models.Repositories",
                dt.ProjectName + ".Global", "TNT.IoContainer.Wrapper");
            ResolveMapping.Add("context", EInfo.Data.ContextName);
            ResolveMapping.Add("entity", EInfo.EntityName);
            ResolveMapping.Add("entityPK", EInfo.PKClass);

            //GENERATE
            GenerateNamespace();
            GenerateIEntityService();
            GenerateEntityService();
            GenerateEntityServiceBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models.Services";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IEntityService
        private ContainerGen IEntityService { get; set; }
        private BodyGen IEntityServiceBody { get; set; }
        public void GenerateIEntityService()
        {
            IEntityService = new ContainerGen();
            IEntityService.Signature = "public partial interface I`entity`Service : IBaseService<`entity`, `entityPK`>";
            IEntityServiceBody = IEntityService.Body;

            NamespaceBody.Add(IEntityService, new StatementGen(""));
        }

        //generate EntityService class
        private ContainerGen EntityService { get; set; }
        private BodyGen EntityServiceBody { get; set; }
        public void GenerateEntityService()
        {
            EntityService = new ContainerGen();
            EntityService.Signature =
                "public partial class `entity`Service : BaseService<`entity`, `entityPK`>, I`entity`Service";
            EntityServiceBody = EntityService.Body;

            NamespaceBody.Add(EntityService);
        }

        public void GenerateEntityServiceBody()
        {
            var c2 = new ContainerGen();
            c2.Signature = "public `entity`Service(IUnitOfWork uow)";
            c2.Body.Add(new StatementGen(
                "repository = uow.Scope.Resolve<I`entity`Repository>(uow);"));

            var c21 = new ContainerGen();
            c21.Signature = "public `entity`Service(`context` context)";
            c21.Body.Add(new StatementGen("repository = G.TContainer.Resolve<I`entity`Repository>(context);"));


            var c18 = new ContainerGen();
            c18.Signature = "public `entity`Service()";
            c18.Body.Add(new StatementGen("repository = G.TContainer.Resolve<I`entity`Repository>();"));

            var cm19 = new CommentGen();
            cm19.Add("params order: 0/ uow");
            var m20 = new ContainerGen();
            m20.Signature = "public override void ReInit(params object[] initParams)";
            m20.Body.Add(new StatementGen(
                "base.ReInit(initParams);",
                "repository.ReInit(initParams);"));

            var d21 = new ContainerGen();
            d21.Signature = "~`entity`Service()";
            d21.Body.Add(new StatementGen("Dispose(false);"));

            EntityServiceBody.Add(
                c2, new StatementGen(""),
                c21, new StatementGen(""));

            if (EInfo.Data.ServicePool)
            {
                EntityServiceBody.Add(new StatementGen("", "#region Implement for Resource Pooling"),
                c18, new StatementGen(""),
                cm19, new StatementGen(""),
                m20, new StatementGen(""),
                d21, new StatementGen("#endregion"));
            }
        }

    }
}
