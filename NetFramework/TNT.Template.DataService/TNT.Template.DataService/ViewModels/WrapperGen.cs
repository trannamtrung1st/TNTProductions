using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.Template.DataService.Helpers;
using TNT.TemplateAPI.Generators;
using static TNT.Template.DataService.Helpers.GeneralHelper;

namespace TNT.Template.DataService.ViewModels
{
    public class WrapperGen : FileGen
    {
        private DataInfo Data { get; set; }
        public WrapperGen(DataInfo data)
        {
            Data = data;
            //GENERATE
            GenerateNamespace();
            GenerateIandClass();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".ViewModels";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        public void GenerateIandClass()
        {
            var iWrapper = new ContainerGen();
            iWrapper.Signature = "public interface IWrapper";
            iWrapper.Body.Add(new StatementGen("object GetValue();"));

            NamespaceBody.Add(iWrapper, new StatementGen(""));
            var wrapper = new ContainerGen();
            wrapper.Signature = "public class Wrapper<T> : IWrapper";
            wrapper.Body.Add(new StatementGen(
                "public T Value { get; set; }", ""));

            var c00 = new ContainerGen();
            c00.Signature = "public Wrapper(T value)";
            c00.Body.Add(new StatementGen("Value = value;"));
            wrapper.Body.Add(c00);

            var c01 = new ContainerGen();
            c01.Signature = "public Wrapper()";
            wrapper.Body.Add(c01);

            var m1 = new ContainerGen();
            m1.Signature = "public object GetValue()";
            m1.Body.Add(new StatementGen("return Value;"));
            wrapper.Body.Add(m1);

            NamespaceBody.Add(wrapper, new StatementGen(""));

        }


    }
}
