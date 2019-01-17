﻿using System;
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
        public UnitOfWorkGen(ContextInfo dt)
        {
            Data = dt;
            Directive.Add("TNT.Core.IoC.Wrapper", "TNT.Core.IoC.Container",
                "Microsoft.EntityFrameworkCore.Storage",
                "Microsoft.EntityFrameworkCore",
                Data.ProjectName + ".Global", Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".Models.Domains",
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
                "D Domain<D>() where D : BaseDomain;",
                "int SaveChanges();",
                "Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));",
                "IDbContextTransaction BeginTransaction();");

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
            var m4 = new ContainerGen();
            m4.Signature = "public D Domain<D>() where D : BaseDomain";
            m4.Body.Add(new StatementGen(
                "var domain = Scope.Resolve<D>();",
                "return domain;"
            ));

            var m6 = new ContainerGen();
            m6.Signature = "public IDbContextTransaction BeginTransaction()";
            m6.Body.Add(new StatementGen(
                "var trans = this.Database.BeginTransaction();",
                "return trans;"));

            UnitOfWorkBody.Add(
                c21, new StatementGen(""),
                s1, new StatementGen(""),
                m3, new StatementGen(""),
                m4, new StatementGen(""),
                m6, new StatementGen("")
                );

            NamespaceBody.Add(UnitOfWork);
        }

    }
}
