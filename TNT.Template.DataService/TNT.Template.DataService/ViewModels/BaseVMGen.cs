using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.ViewModels
{
    public class BaseVMGen : FileGen
    {

        public BaseVMGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add(dt.ProjectName + ".Global");
            //GENERATE
            GenerateNamespace();
            GenerateIBaseVM();
            GenerateBaseVM();
        }

        //generate namespace
        private DataInfo Data { get; set; }
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        private void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".ViewModels";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IBaseVM
        private ContainerGen IBaseVM { get; set; }
        private BodyGen IBaseVMBody { get; set; }
        private void GenerateIBaseVM()
        {
            var IViewModel = new ContainerGen();
            IViewModel.Signature = "public partial interface IViewModel";
            IViewModel.Body.Add(
                new StatementGen(
                    "void CopyFrom(object src);",
                    "void CopyTo(object dest);",
                    "ET To<ET>();"));
            NamespaceBody.Add(IViewModel, new StatementGen(""));

            IBaseVM = new ContainerGen();
            IBaseVM.Signature = "public partial interface IBaseViewModel<E>: IViewModel";
            IBaseVMBody = IBaseVM.Body;

            IBaseVMBody.Add(
                new StatementGen(
                    "void FromEntity(E entity);",
                    "E ToEntity();"
                ));

            NamespaceBody.Add(IBaseVM, new StatementGen(""));
        }

        //generate IBaseVM
        private ContainerGen BaseVM { get; set; }
        private BodyGen BaseVMBody { get; set; }
        private void GenerateBaseVM()
        {
            var BaseViewModel = new ContainerGen();
            BaseViewModel.Signature = "public abstract partial class BaseViewModel<E>: IBaseViewModel<E>";

            var c0 = new ContainerGen();
            c0.Signature = "public BaseViewModel(E entity)";
            c0.Body.Add(new StatementGen("FromEntity(entity);"));

            var c1 = new ContainerGen();
            c1.Signature = "public BaseViewModel()";

            var s1 = new StatementGen("protected E Entity { get; set; }");

            var m3 = new ContainerGen();
            m3.Signature = "public virtual void FromEntity(E entity)";
            m3.Body.Add(new StatementGen(
                "Entity = entity;",
                "G.Mapper.Map(entity, this);"));

            var m31 = new ContainerGen();
            m31.Signature = "public virtual void CopyFrom(object src)";
            m31.Body.Add(new StatementGen(
                "G.Mapper.Map(src, this);"));

            var m32 = new ContainerGen();
            m32.Signature = "public virtual void CopyTo(object dest)";
            m32.Body.Add(new StatementGen(
                "G.Mapper.Map(this, dest);"));

            var m33 = new ContainerGen();
            m33.Signature = "public virtual ET To<ET>()";
            m33.Body.Add(new StatementGen(
                "return G.Mapper.Map<ET>(this);"));

            var m4 = new ContainerGen();
            m4.Signature = "public virtual E ToEntity()";
            m4.Body.Add(new StatementGen(
                "if (Entity!=null)",
                "\treturn Entity;",
                "return G.Mapper.Map<E>(this);"));

            var m5 = new ContainerGen();
            m5.Signature = "public virtual E ToEntity(bool copyToEntity)";
            m5.Body.Add(new StatementGen(
                "if (Entity!=null)",
                "{",
                "\tif (copyToEntity) CopyTo(Entity);",
                "\treturn Entity;",
                "}",
                "return G.Mapper.Map<E>(this);"));

            BaseViewModel.Body.Add(
                c1, new StatementGen(""),
                c0, new StatementGen(""),
                s1, new StatementGen(""),
                m3, new StatementGen(""),
                m31, new StatementGen(""),
                m32, new StatementGen(""),
                m33, new StatementGen(""),
                m4, new StatementGen(""),
                m5, new StatementGen(""));

            NamespaceBody.Add(BaseViewModel, new StatementGen(""));
        }

    }
}
