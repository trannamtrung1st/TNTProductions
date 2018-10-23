using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Services
{
    public class ServiceGen : FileGen
    {
        private DataInfo Data { get; set; }
        public ServiceGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add("System.Linq.Expressions", "TNT.IoContainer.Container");
            //GENERATE
            GenerateNamespace();
            GenerateIBaseService();
            GenerateBaseService();
            GenerateBaseServiceBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Models.Services";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IBaseService
        private ContainerGen IBaseService { get; set; }
        private BodyGen IBaseServiceBody { get; set; }
        public void GenerateIBaseService()
        {
            var IService = new ContainerGen();
            IService.Signature = "public partial interface IService" + (Data.ServicePool ? ": IResource" : "");
            NamespaceBody.Add(IService);

            IBaseService = new ContainerGen();
            IBaseService.Signature = "public partial interface IBaseService<E, VM, K> : IService";
            IBaseServiceBody = IBaseService.Body;

            IBaseServiceBody.Add(
                new StatementGen(
                    "bool AutoSave { get; set; }",
                    "",
                    "E Add(E entity);",
                    "Task<E> AddAsync(E entity);",
                    "E Update(E entity);",
                    "Task<E> UpdateAsync(E entity);",
                    "E Delete(E entity);",
                    "Task<E> DeleteAsync(E entity);",
                    "E Delete(K key);",
                    "Task<E> DeleteAsync(K key);",
                    "E FindById(K key);",
                    "Task<E> FindByIdAsync(K key);",
                    "E Activate(E entity);",
                    "E Activate(K key);",
                    "E Deactivate(E entity);",
                    "E Deactivate(K key);",
                    "IQueryable<E> GetActive();",
                    "IQueryable<E> GetActive(Expression<Func<E, bool>> expr);",
                    "E FirstOrDefault();",
                    "E FirstOrDefault(Expression<Func<E, bool>> expr);",
                    "Task<E> FirstOrDefaultAsync();",
                    "Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);"

                ));

            NamespaceBody.Add(IBaseService, new StatementGen(""));
        }

        //generate BaseService class
        private ContainerGen BaseService { get; set; }
        private BodyGen BaseServiceBody { get; set; }
        public void GenerateBaseService()
        {
            BaseService = new ContainerGen();
            BaseService.Signature =
                "public abstract partial class BaseService : " + (Data.ServicePool ? "Resource, " : "") + "IService";
            BaseServiceBody = BaseService.Body;

            NamespaceBody.Add(BaseService);
        }

        public void GenerateBaseServiceBody()
        {
            var s1 = new StatementGen(
                "public abstract bool AutoSave { get; set; }");

            BaseServiceBody.Add(
                s1, new StatementGen(""));

        }

    }
}
