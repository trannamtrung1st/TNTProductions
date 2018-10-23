using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Domains
{
    public class EntityDomainGen : FileGen
    {

        private EntityInfo EInfo { get; set; }
        public EntityDomainGen(EntityInfo eInfo)
        {
            EInfo = eInfo;
            var dt = EInfo.Data;
            Directive.Add(
                dt.ProjectName + ".ViewModels", dt.ProjectName + ".Models.Services",
                dt.ProjectName + ".Managers",
                dt.ProjectName + ".Models");
            ResolveMapping.Add("service", "I" + EInfo.EntityName + "Service");
            ResolveMapping.Add("context", EInfo.Data.ContextName);
            ResolveMapping.Add("entity", EInfo.EntityName);
            ResolveMapping.Add("entityVM", EInfo.VMClass);
            ResolveMapping.Add("entityPK", EInfo.PKClass);

            //GENERATE
            GenerateNamespace();
            GenerateEntityDomain();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + EInfo.Data.ProjectName + ".Models.Domains";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate EntityDomain
        private ContainerGen EntityDomain { get; set; }
        private BodyGen EntityDomainBody { get; set; }
        public void GenerateEntityDomain()
        {
            EntityDomain = new ContainerGen();
            EntityDomain.Signature = "public partial class `entity`Domain : BaseDomain<Models.`entity`, `entity`ViewModel, `entityPK`, `service`>";
            EntityDomainBody = EntityDomain.Body;

            var c0 = new ContainerGen();
            c0.Signature = "public `entity`Domain() : base()";
            EntityDomainBody.Add(c0);

            var c1 = new ContainerGen();
            c1.Signature = "public `entity`Domain(IUnitOfWork uow) : base(uow)";
            EntityDomainBody.Add(c1);

            NamespaceBody.Add(EntityDomain, new StatementGen(""));
        }

    }
}
