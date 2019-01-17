using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Models
{
    public class UnitOfWorkGen : FileGen
    {
        private DataInfo Data { get; set; }
        public UnitOfWorkGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add("TNT.IoC.Wrapper", "TNT.IoC.Container",
                "System.Web",
                "System.Data.Entity",
                Data.ProjectName + ".Global", Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".Models");
            ResolveMapping["context"] = Data.ContextName;

            //GENERATE
            GenerateNamespace();
            GenerateIUnitOfWork();
            GenerateUnitOfWork();
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

        //generate IUnitOfWork
        private ContainerGen IUnitOfWork { get; set; }
        private BodyGen IUnitOfWorkBody { get; set; }
        public void GenerateIUnitOfWork()
        {
            IUnitOfWork = new ContainerGen();
            IUnitOfWork.Signature = "public partial interface IUnitOfWork : IDisposable";
            IUnitOfWorkBody = IUnitOfWork.Body;

            var s1 = new StatementGen(
                "ITContainer Scope { get; }",
                "DbContext Context { get; }",
                "DbSet<E> Set<E>() where E : class;",
                "S Repository<S>() where S : class, IRepository;",
                "int SaveChanges();",
                "Task<int> SaveChangesAsync();",
                "DbContextTransaction BeginTransaction();");

            IUnitOfWorkBody.Add(
                s1, new StatementGen("")
                );

            NamespaceBody.Add(IUnitOfWork);
        }

        //generate UnitOfWork
        private ContainerGen UnitOfWork { get; set; }
        private BodyGen UnitOfWorkBody { get; set; }
        public void GenerateUnitOfWork()
        {
            UnitOfWork = new ContainerGen();
            UnitOfWork.Signature = "public partial class UnitOfWork : `context`, IUnitOfWork";
            UnitOfWorkBody = UnitOfWork.Body;

            var s1 = new StatementGen(
                "public ITContainer Scope { get; }",
                "public DbContext Context { get; }");

            var c21 = new ContainerGen();
            c21.Signature = "public UnitOfWork(ITContainer scope)";
            c21.Body.Add(new StatementGen(
                "Scope = scope;",
                "Context = this;"));

            var m3 = new ContainerGen();
            m3.Signature = "public S Repository<S>() where S : class, IRepository";
            m3.Body.Add(new StatementGen(
                "var repository = Scope.Resolve<S>();",
                "return repository;"
            ));

            var m6 = new ContainerGen();
            m6.Signature = "public DbContextTransaction BeginTransaction()";
            m6.Body.Add(new StatementGen(
                "var trans = this.Database.BeginTransaction();",
                "return trans;"));

            UnitOfWorkBody.Add(
                c21, new StatementGen(""),
                s1, new StatementGen(""),
                m3, new StatementGen(""),
                m6, new StatementGen("")
                );

            NamespaceBody.Add(UnitOfWork);
        }

    }
}
