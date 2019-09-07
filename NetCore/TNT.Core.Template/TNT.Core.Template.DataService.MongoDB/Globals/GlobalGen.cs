using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Global
{
    public class GlobalGen : FileGen
    {
        private Info Info;
        public GlobalGen(Info info)
        {
            Info = info;
            Directive.Add("AutoMapper",
                "Microsoft.Extensions.DependencyInjection",
                Info.ProjectName + ".Models.Configs",
                Info.ProjectName + ".Models.Repositories");

            //GENERATE
            GenerateNamespace();
            GenerateGlobal();
            //GenerateHttpApp();
            GenerateMapperConfig();
            GenerateInitMapper();
            GenerateInitDI();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        private void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Info.ProjectName + ".Global";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate Global
        private ContainerGen GlobalClass { get; set; }
        private BodyGen GlobalClassBody { get; set; }
        private void GenerateGlobal()
        {
            GlobalClass = new ContainerGen();
            GlobalClass.Signature = "public static partial class G";
            GlobalClassBody = GlobalClass.Body;

            GlobalClassBody.Add(
                new StatementGen(
                    "public static IMapper Mapper { get; private set; }"
                ));

            NamespaceBody.Add(GlobalClass);
        }

        private void GenerateMapperConfig()
        {
            #region MapperConfig
            var mapperConfig = new StatementGen("private static List<Action<IMapperConfigurationExpression>> MapperConfigs");
            var open = new StatementGen(
                "\t= new List<Action<IMapperConfigurationExpression>>();", "//{");
            var mapConfig = new StatementGen(true, "//cfg =>", "//{");
            foreach (var e in Info.Entities)
            {
                mapConfig.Add("//\tcfg.CreateMap<" + e.EntityName + ", " + e.VMClass + ">().ReverseMap();");
            }
            var close = new StatementGen("//\t}", "//};");
            GlobalClassBody.Add(
                mapperConfig,
                open,
                mapConfig,
                close);
            #endregion
        }

        private void GenerateInitMapper()
        {
            var method = new ContainerGen();
            method.Signature = "private static void ConfigureAutomapper()";

            var s1 = new StatementGen("//AutoMapper");
            var open = new StatementGen(
                "var mapConfig = new MapperConfiguration(cfg =>", "{");
            var mapConfig = new StatementGen(true,
                "foreach (var c in MapperConfigs)",
                "{",
                "\tc.Invoke(cfg);",
                "}");
            var close = new StatementGen("});", "G.Mapper = mapConfig.CreateMapper();");

            method.Body.Add(
                s1,
                open,
                mapConfig,
                close, new StatementGen(""));
            GlobalClassBody.Add(method, new StatementGen(""));

        }

        private void GenerateInitDI()
        {
            var method = new ContainerGen();
            method.Signature = "private static void ConfigureIoC(IServiceCollection services, IMongoDbSettings settings)";

            var s2 = new StatementGen("//IoC",
                "services.AddSingleton(settings)");

            var entities = Info.Entities;
            var len = entities.Count;
            int i = 0;
            for (i = 0; i < len - 1; i++)
            {
                s2.Add("\t.AddSingleton<I" + entities[i].EntityName + "Repository, " + entities[i].EntityName + "Repository>()");
            }
            s2.Add("\t.AddSingleton<I" + entities[i].EntityName + "Repository, " + entities[i].EntityName + "Repository>();");

            method.Body.Add(s2);
            GlobalClassBody.Add(method, new StatementGen(""));
        }

    }
}
