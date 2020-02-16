using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Models
{
    public class UnitOfWorkGen : FileGen
    {
        private ContextInfo Data { get; set; }
        private string Container { get; set; }
        public UnitOfWorkGen(ContextInfo dt)
        {
            Data = dt;
            Directive.Add(
                "Microsoft.EntityFrameworkCore.Storage",
                "Microsoft.EntityFrameworkCore",
                Data.ProjectName + ".Global", Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".Domains",
                Data.ContextNamespace);
            ResolveMapping["context"] = Data.ContextName;

            Container = "IServiceProvider";
            Directive.Add("Microsoft.Extensions.DependencyInjection");

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
            IUnitOfWork.Signature = "public partial interface IUnitOfWork";
            IUnitOfWorkBody = IUnitOfWork.Body;

            var s1 = new StatementGen(
                //Container + " Scope { get; }",
                //"DbContext Context { get; }",
                //"DbSet<E> Set<E>() where E : class;",
                //"S Repository<S>() where S : class, IRepository;",
                //"D Domain<D>() where D : BaseDomain;",
                "T GetService<T>();",
                "int SaveChanges();",
                "Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));",
                "IDbContextTransaction BeginTransaction();");

            IUnitOfWorkBody.Add(
                s1, new StatementGen(""));

            NamespaceBody.Add(IUnitOfWork);
        }

        //generate UnitOfWork
        private ContainerGen UnitOfWork { get; set; }
        private BodyGen UnitOfWorkBody { get; set; }
        public void GenerateUnitOfWork()
        {
            UnitOfWork = new ContainerGen();
            UnitOfWork.Signature = "public partial class UnitOfWork: IUnitOfWork";
            UnitOfWorkBody = UnitOfWork.Body;

            var s1 = new StatementGen(
                "protected readonly " + Container + " scope;",
                "protected readonly DbContext context;"
                );

            var c21 = new ContainerGen();
            c21.Signature = "public UnitOfWork(" + Container + " scope, DbContext context)";
            c21.Body.Add(new StatementGen(
                "this.scope = scope;",
                "this.context = context;"
                ));

            var method = "GetService";

            //var m3 = new ContainerGen();
            //m3.Signature = "public S Repository<S>() where S : class, IRepository";
            //m3.Body.Add(new StatementGen(
            //    "var repository = Scope." + method + "<S>();",
            //    "return repository;"
            //));
            //var m4 = new ContainerGen();
            //m4.Signature = "public D Domain<D>() where D : BaseDomain";
            //m4.Body.Add(new StatementGen(
            //    "var domain = Scope." + method + "<D>();",
            //    "return domain;"
            //));

            var m3 = new ContainerGen();
            m3.Signature = "public T GetService<T>()";
            m3.Body.Add(new StatementGen(
                "return scope." + method + "<T>();"
            ));

            var m6 = new ContainerGen();
            m6.Signature = "public IDbContextTransaction BeginTransaction()";
            m6.Body.Add(new StatementGen(
                "var trans = this.context.Database.BeginTransaction();",
                "return trans;"));

            var m7 = new ContainerGen();
            m7.Signature = "public int SaveChanges()";
            m7.Body.Add(new StatementGen(
                "return this.context.SaveChanges();"));

            var m8 = new ContainerGen();
            m8.Signature = "public async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))";
            m8.Body.Add(new StatementGen(
                "return await this.context.SaveChangesAsync(cancellationToken);"));

            UnitOfWorkBody.Add(
                c21, new StatementGen(""),
                s1, new StatementGen(""),
                m3, new StatementGen(""),
                //m4, new StatementGen(""),
                m6, new StatementGen(""),
                m7, new StatementGen(""),
                m8, new StatementGen("")
                );

            NamespaceBody.Add(UnitOfWork);
        }

    }
}
