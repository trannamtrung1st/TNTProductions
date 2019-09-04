using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models
{
    public class MongoDbSettingsGen : FileGen
    {
        private Info Info { get; set; }

        public MongoDbSettingsGen(Info info)
        {
            Info = info;

            //GENERATE
            GenerateNamespace();
            GenerateIMongoDbSettings();
            GenerateMongoDbSettings();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Info.ProjectName + ".Models.Configs";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IMongoDbSettings
        private ContainerGen IMongoDbSettings { get; set; }
        private BodyGen IMongoDbSettingsBody { get; set; }
        public void GenerateIMongoDbSettings()
        {
            IMongoDbSettings = new ContainerGen();
            IMongoDbSettings.Signature = "public partial interface IMongoDbSettings";
            IMongoDbSettingsBody = IMongoDbSettings.Body;

            var s1 = new StatementGen("string ConnectionString { get; set; }",
                "string DatabaseName { get; set; }");

            IMongoDbSettingsBody.Add(
                s1, new StatementGen(""));

            NamespaceBody.Add(IMongoDbSettings);
        }

        //generate MongoDbSettings
        private ContainerGen MongoDbSettings { get; set; }
        private BodyGen MongoDbSettingsBody { get; set; }
        public void GenerateMongoDbSettings()
        {
            MongoDbSettings = new ContainerGen();
            MongoDbSettings.Signature = "public partial class MongoDbSettings : IMongoDbSettings";
            MongoDbSettingsBody = MongoDbSettings.Body;

            var s1 = new StatementGen("public string ConnectionString { get; set; }",
                "public string DatabaseName { get; set; }");

            MongoDbSettingsBody.Add(
                s1, new StatementGen(""));

            NamespaceBody.Add(MongoDbSettings);
        }

    }
}
