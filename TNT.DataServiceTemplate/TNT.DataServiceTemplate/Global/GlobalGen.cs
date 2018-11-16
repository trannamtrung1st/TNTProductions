﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Global
{
    public class GlobalGen : FileGen
    {
        private DataInfo Data;
        public GlobalGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add("TNT.IoContainer.Container", "AutoMapper",
                "System.Web",
                Data.ProjectName + ".Models",
                Data.ProjectName + ".Models.Repositories",
                Data.ProjectName + ".Models.Services",
                Data.ProjectName + ".Managers",
                Data.ProjectName + ".ViewModels");

            //GENERATE
            GenerateNamespace();
            GenerateGlobal();
            GenerateInitMethod();
            //GenerateHttpApp();
            GenerateMapperConfig();
            GenerateInitMapper();
            GenerateInitContainer();
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
                    "public static IMapper Mapper;",
                    "public static ITContainer TContainer;",
                    "private static ITContainerBuilder Builder = new TContainerBuilder();"
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
            foreach (var e in Data.Entities)
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

        private void GenerateInitMethod()
        {
            var initMethod = new ContainerGen();
            initMethod.Signature = "private static void DefaultConfigure()";

            initMethod.Body.Add(
                new StatementGen("ConfigureAutomapper();"),
                new StatementGen("ConfigureIoContainer();")
                );

            GlobalClassBody.Add(initMethod, new StatementGen(""));
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

        private void GenerateInitContainer()
        {
            var method = new ContainerGen();
            method.Signature = "private static void ConfigureIoContainer()";

            var s2 = new StatementGen("//IoContainer",
                Data.RequestScope ? "Builder.RegisterRequestScopeHandlerModule();" : null,
                "Builder.RegisterType<IUnitOfWork, UnitOfWork>();");

            foreach (var e in Data.Entities)
            {
                s2.Add("Builder.RegisterType<I" + e.EntityName + "Repository, " + e.EntityName + "Repository>();");
            }

            foreach (var e in Data.Entities)
            {
                if (Data.ServicePool)
                    s2.Add("Builder.RegisterToPool<I" + e.EntityName + "Service, " + e.EntityName + "Service>(10, 100);");
                else
                    s2.Add("Builder.RegisterType<I" + e.EntityName + "Service, " + e.EntityName + "Service>();");
            }

            s2.Add("G.TContainer = Builder.Build();");
            method.Body.Add(s2);
            GlobalClassBody.Add(method, new StatementGen(""));

        }

    }
}
