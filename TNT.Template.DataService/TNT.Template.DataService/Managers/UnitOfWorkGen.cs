using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Managers
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
            ResolveMapping.Add("context", Data.ContextName);

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
            Namespace.Signature = "namespace " + Data.ProjectName + ".Managers";
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
                "ITContainer Scope { get; set; }",
                "DbContext Context { get; set; }",
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
            UnitOfWork.Signature = "public partial class UnitOfWork : IUnitOfWork";
            UnitOfWorkBody = UnitOfWork.Body;

            var s1 = new StatementGen(
                "public ITContainer Scope { get; set; }",
                "public DbContext Context { get; set; }",
                "private IDictionary<Type, object> ResourcePool { get; set; }");

            var c2 = new ContainerGen();
            c2.Signature = "public UnitOfWork()";
            c2.Body.Add(new StatementGen(
                "Scope = G.TContainer.RequestScope;",
                "Context = new `context`();",
                "ResourcePool = new Dictionary<Type, object>();"));

            var c21 = new ContainerGen();
            c21.Signature = "public UnitOfWork(ITContainer scope)";
            c21.Body.Add(new StatementGen(
                "Scope = scope;",
                "Context = new `context`();",
                "ResourcePool = new Dictionary<Type, object>();"));

            var m3 = new ContainerGen();
            m3.Signature = "public S Repository<S>() where S : class, IRepository";
            m3.Body.Add(new StatementGen(
                "var type = typeof(S);",
                "if (ResourcePool.ContainsKey(type))",
                "\treturn (S)ResourcePool[type];",
                "var repository = Scope.Resolve<S>(Args.Array(this));",
                "ResourcePool.Add(type, repository);",
                "return repository;"
            ));

            var m4 = new ContainerGen();
            m4.Signature = "public int SaveChanges()";
            m4.Body.Add(new StatementGen(
                "return Context.SaveChanges();"));

            var m5 = new ContainerGen();
            m5.Signature = "public async Task<int> SaveChangesAsync()";
            m5.Body.Add(new StatementGen(
                "return await Context.SaveChangesAsync();"));

            var m6 = new ContainerGen();
            m6.Signature = "public DbContextTransaction BeginTransaction()";
            m6.Body.Add(new StatementGen(
                "var trans = Context.Database.BeginTransaction();",
                "return trans;"));

            var s7 = new StatementGen(
                "#region IDisposable Support",
                "protected bool disposedValue = false;");

            var m8 = new ContainerGen();
            m8.Signature = "protected virtual void Dispose(bool disposing)";
            m8.Body.Add(new StatementGen(
                "if (!disposedValue)",
                "{"),
                new StatementGen(true,
                "if (disposing)",
                "{",
                "}", "",
                "disposedValue = true;",
                "Context.Dispose();"),
                new StatementGen("}"));

            var m9 = new ContainerGen();
            m9.Signature = "public void Dispose()";
            m9.Body.Add(new StatementGen(
                "Dispose(true);",
                "GC.SuppressFinalize(this);"));
            var s10 = new StatementGen("#endregion");

            var m11 = new ContainerGen();
            m11.Signature = "~UnitOfWork()";
            m11.Body.Add(new StatementGen("Dispose(false);"));

            if (Data.RequestScope)
            {
                UnitOfWorkBody.Add(c2, new StatementGen(""));
            }

            UnitOfWorkBody.Add(
                c21, new StatementGen(""),
                s1, new StatementGen(""),
                m3, new StatementGen(""),
                m4, new StatementGen(""),
                m5, new StatementGen(""),
                m6, new StatementGen(""),
                s7, new StatementGen(""),
                m8, new StatementGen(""),
                m9, new StatementGen(""),
                s10, new StatementGen(""),
                m11, new StatementGen("")
                );

            NamespaceBody.Add(UnitOfWork);
        }

    }
}
