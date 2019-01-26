using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Models.Domains
{
    public class BaseDomainGen : FileGen
    {
        private DataInfo Data { get; set; }
        public BaseDomainGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add(
                Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".ViewModels",
                Data.ProjectName + ".Models",
                Data.ProjectName + ".Global",
                "System.Data.Entity",
                "System.Linq.Expressions",
                "TNT.IoC.Container");
            ResolveMapping["context"] = dt.ContextName;

            //GENERATE
            GenerateNamespace();
            GenerateBaseDomain();
            GenerateBaseDomainBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Models.Domains";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate BaseDomain
        private ContainerGen BaseDomain { get; set; }
        private BodyGen BaseDomainBody { get; set; }
        public void GenerateBaseDomain()
        {
            BaseDomain = new ContainerGen();
            BaseDomain.Signature = "public abstract partial class BaseDomain";
            BaseDomainBody = BaseDomain.Body;

            NamespaceBody.Add(BaseDomain);
        }

        public void GenerateBaseDomainBody()
        {
            var c0 = new ContainerGen();
            c0.Signature = "public BaseDomain()";
            c0.Body.Add(new StatementGen(
                "this.uow = TContainer.RequestScope.ResolveScopeInstance<IUnitOfWork>();",
                "this.context = uow.Context;"));

            var c01 = new ContainerGen();
            c01.Signature = "public BaseDomain(DbContext context)";
            c01.Body.Add(new StatementGen(
                "this.context = context;"));

            var s1 = new StatementGen(
                "protected DbContext context;");

            var c1 = new ContainerGen();
            c1.Signature = "public BaseDomain(IUnitOfWork uow)";
            c1.Body.Add(new StatementGen(
                "this.uow = uow;",
                "this.context = uow.Context;"));

            var s2 = new StatementGen(
                "protected IUnitOfWork uow;");

            var s3 = new StatementGen("public IUnitOfWork UoW { get { return uow; } }");
            var s4 = new StatementGen("public DbContext Context { get { return context; } }");

            if (Data.RequestScope)
            {
                BaseDomainBody.Add(c0, new StatementGen(""));
            }

            BaseDomainBody.Add(
                s2, new StatementGen(""),
                c1, new StatementGen(""),
                s1, new StatementGen(""),
                c01, new StatementGen(""),
                s3, new StatementGen(""),
                s4, new StatementGen("")
                );
        }

    }
}
