using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models.Domains
{
    public class BaseDomainGen : FileGen
    {
        private Info Info { get; set; }

        public BaseDomainGen(Info info)
        {
            Info = info;
            Directive.Add(
                "MongoDB.Driver",
                "Microsoft.Extensions.DependencyInjection",
                Info.ProjectName + ".Models.Configs");

            //GENERATE
            GenerateNamespace();
            GenerateBaseDomain();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Info.ProjectName + ".Models.Domains";
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

            var s1 = new StatementGen(
                "protected readonly IMongoClient _client;",
                "protected readonly IMongoDatabase _database;",
                "protected readonly IServiceProvider _serviceProvider;"
                );

            var c2 = new ContainerGen();
            c2.Signature = "public BaseDomain(IServiceProvider provider, IMongoDbSettings settings)";
            c2.Body.Add(new StatementGen(
                "_serviceProvider = provider;",
                "_client = new MongoClient(settings.ConnectionString);",
                "_database = _client.GetDatabase(settings.DatabaseName);"));

            var m3 = new ContainerGen();
            m3.Signature = "protected T Service<T>()";
            m3.Body.Add(new StatementGen(
                "return _serviceProvider.GetRequiredService<T>();"));

            BaseDomainBody.Add(
                s1, new StatementGen(""),
                c2, new StatementGen(""),
                m3, new StatementGen("")
                );

            NamespaceBody.Add(BaseDomain);
        }

    }
}
