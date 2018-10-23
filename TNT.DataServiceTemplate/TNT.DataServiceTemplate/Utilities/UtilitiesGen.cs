﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Utilities
{
    public class UtilitiesGen : FileGen
    {
        private DataInfo Data;
        public UtilitiesGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add(
                Data.ProjectName + ".Models",
                Data.ProjectName + ".ViewModels");

            //GENERATE
            GenerateNamespace();
            GenerateGeneralExtension();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Utilities";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate Global
        private ContainerGen GeneralExtension { get; set; }
        private BodyGen GeneralExtensionBody { get; set; }
        public void GenerateGeneralExtension()
        {
            GeneralExtension = new ContainerGen();
            GeneralExtension.Signature = "public static class DefaultUtilities";
            GeneralExtensionBody = GeneralExtension.Body;

            var m1 = new ContainerGen();
            m1.Signature = "public static List<VM> ToListVM<E, VM>(this IEnumerable<E> list) where E: IEntity";
            m1.Body.Add(new StatementGen("return list.Select(e => e.To<VM>()).ToList();"));

            var m2 = new ContainerGen();
            m2.Signature = "public static List<E> ToListEntities<VM, E>(this IEnumerable<VM> list) where VM: IViewModel";
            m2.Body.Add(new StatementGen("return list.Select(vm => vm.To<E>()).ToList();"));

            GeneralExtensionBody.Add(
                m1, new StatementGen(""),
                m2, new StatementGen(""));
            NamespaceBody.Add(GeneralExtension);
        }
    }
}