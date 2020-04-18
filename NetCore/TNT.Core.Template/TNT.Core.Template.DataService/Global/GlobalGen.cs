using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Global
{
    public class GlobalGen : FileGen
    {
        private ContextInfo Data;
        public GlobalGen(ContextInfo dt)
        {
            Data = dt;
            Directive.Add("AutoMapper",
                "Microsoft.EntityFrameworkCore",
                Data.ContextNamespace,
                Data.ProjectName + ".Models",
                Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".ViewModels",
                "TNT.Core.Helpers.DI");
            Directive.Add("Microsoft.Extensions.DependencyInjection");

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
            Namespace.Signature = "namespace " + Data.ProjectName + ".Global";
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
            var bodyConfig = new StatementGen(
                "//var vmType = typeof(IViewModel);",
                "//var modelTypes = AppDomain.CurrentDomain.GetAssemblies()",
                    "//\t.SelectMany(t => t.GetTypes())",
                    "//\t.Where(t => vmType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);",
                "//var maps = new Dictionary<Type, Type>();",
                "//foreach (var t in modelTypes)",
                "//{",
                    "//\tvar genArgs = t.BaseType?.GetGenericArguments().FirstOrDefault();",
                    "//\tif (genArgs != null) cfg.CreateMap(genArgs, t).ReverseMap();",
                "//}");

            var close = new StatementGen("//\t}", "//};");
            GlobalClassBody.Add(
                mapperConfig,
                open,
                mapConfig,
                bodyConfig,
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
            method.Signature = "private static void ConfigureIoC(IServiceCollection services)";

            var s2 = new StatementGen("//IoC",
                "services.AddScoped<UnitOfWork>()");
            s2.Add("\t.AddScoped<IUnitOfWork, UnitOfWork>()");
            s2.Add($"\t.AddScoped<DbContext, {Data.ContextName}>();");
            method.Body.Add(s2);

            var s3 = new StatementGen("",
                "var baseRepoType = typeof(IRepository);",
                "var repoTypes = AppDomain.CurrentDomain.GetAssemblies()",
                "\t.SelectMany(t => t.GetTypes())",
                "\t.Where(t => baseRepoType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);",
                "var maps = new Dictionary<Type, Type>();",
                "foreach (var t in repoTypes)",
                "{",
                    "\tvar iRepoType = t.GetInterface($\"I{t.Name}\");",
                    "\tif (iRepoType != null) services.AddScoped(iRepoType, t);",
                "}");
            method.Body.Add(s3);

            var s4 = new StatementGen("ServiceInjection.Register(new List<Type>(){ typeof(G) });");
            method.Body.Add(s4);

            GlobalClassBody.Add(method, new StatementGen(""));
        }

    }
}
