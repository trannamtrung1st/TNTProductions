using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Models.Services
{
    public class ServiceGen : FileGen
    {
        private DataInfo Data { get; set; }
        public ServiceGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add("System.Linq.Expressions",
                dt.ProjectName + ".Utilities",
                dt.ProjectName + ".Managers",
                dt.ProjectName + ".Models.Repositories",
                dt.ProjectName + ".Global", "TNT.IoContainer.Wrapper", "TNT.IoContainer.Container");
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
            IBaseService.Signature = "public partial interface IBaseService<E, K> : IService";
            IBaseServiceBody = IBaseService.Body;

            IBaseServiceBody.Add(
                new StatementGen(
                    "int SaveChanges();",
                    "Task<int> SaveChangesAsync();",
                    "",
                    "void Reload(E entity);",
                    "E Add(E entity);",
                    "IEnumerable<E> AddRange(IEnumerable<E> entities);",
                    "E Update(E entity);",
                    "E Remove(E entity);",
                    "E Remove(K key);",
                    "IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);",
                    "IEnumerable<E> RemoveRange(IEnumerable<E> list);",
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
                "public abstract partial class BaseService<E, K> : " + (Data.ServicePool ? "Resource, " : "") + "IBaseService<E, K>";
            BaseServiceBody = BaseService.Body;

            NamespaceBody.Add(BaseService);
        }

        public void GenerateBaseServiceBody()
        {
            var s1 = new StatementGen("protected IBaseRepository<E, K> repository;");

            var m31 = new ContainerGen();
            m31.Signature = "public int SaveChanges()";
            m31.Body.Add(new StatementGen(
                "return repository.SaveChanges();"));

            var m32 = new ContainerGen();
            m32.Signature = "public async Task<int> SaveChangesAsync()";
            m32.Body.Add(new StatementGen(
                "return await repository.SaveChangesAsync();"));

            var m33 = new ContainerGen();
            m33.Signature = "public void Reload(E entity)";
            m33.Body.Add(new StatementGen(
                "repository.Reload(entity);"));

            var m4 = new ContainerGen();
            m4.Signature = "public E Add(E entity)";
            m4.Body.Add(new StatementGen(
                "return repository.Add(entity);"));

            var m41 = new ContainerGen();
            m41.Signature = "public IEnumerable<E> AddRange(IEnumerable<E> entities)";
            m41.Body.Add(new StatementGen(
                "return repository.AddRange(entities);"));

            var m6 = new ContainerGen();
            m6.Signature = "public E Update(E entity)";
            m6.Body.Add(new StatementGen(
                "return repository.Update(entity);"));

            //var m7 = new ContainerGen();
            //m7.Signature = "public async Task<E> UpdateAsync(E entity)";
            //m7.Body.Add(new StatementGen(
            //    "return await repository.UpdateAsync(entity);"));

            var m8 = new ContainerGen();
            m8.Signature = "public E Remove(E entity)";
            m8.Body.Add(new StatementGen(
                "return repository.Remove(entity);"));

            //var m9 = new ContainerGen();
            //m9.Signature = "public async Task<E> RemoveAsync(E entity)";
            //m9.Body.Add(new StatementGen(
            //    "return await repository.RemoveAsync(entity);"));

            var m10 = new ContainerGen();
            m10.Signature = "public E Remove(K key)";
            m10.Body.Add(new StatementGen(
                "return repository.Remove(key);"));

            var m101 = new ContainerGen();
            m101.Signature = "public IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr)";
            m101.Body.Add(new StatementGen(
                "return repository.RemoveIf(expr);"));

            var m102 = new ContainerGen();
            m102.Signature = "public IEnumerable<E> RemoveRange(IEnumerable<E> list)";
            m102.Body.Add(new StatementGen(
                "return repository.RemoveRange(list);"));

            //var m11 = new ContainerGen();
            //m11.Signature = "public async Task<E> RemoveAsync(K key)";
            //m11.Body.Add(new StatementGen(
            //    "return await repository.RemoveAsync(key);"));

            var m12 = new ContainerGen();
            m12.Signature = "public E FindById(K key)";
            m12.Body.Add(new StatementGen(
                "return repository.FindActiveById(key);"));

            var m13 = new ContainerGen();
            m13.Signature = "public async Task<E> FindByIdAsync(K key)";
            m13.Body.Add(new StatementGen("return await repository.FindActiveByIdAsync(key);"));

            var m141 = new ContainerGen();
            m141.Signature = "public E Activate(E entity)";
            m141.Body.Add(new StatementGen("return repository.Activate(entity);"));

            var m1411 = new ContainerGen();
            m1411.Signature = "public E Activate(K key)";
            m1411.Body.Add(new StatementGen("return repository.Activate(key);"));

            var m142 = new ContainerGen();
            m142.Signature = "public E Deactivate(E entity)";
            m142.Body.Add(new StatementGen("return repository.Deactivate(entity);"));

            var m1422 = new ContainerGen();
            m1422.Signature = "public E Deactivate(K key)";
            m1422.Body.Add(new StatementGen("return repository.Deactivate(key);"));

            var m14 = new ContainerGen();
            m14.Signature = "public IQueryable<E> GetActive()";
            m14.Body.Add(new StatementGen("return repository.GetActive();"));

            var m15 = new ContainerGen();
            m15.Signature = "public IQueryable<E> GetActive(Expression<Func<E, bool>> expr)";
            m15.Body.Add(new StatementGen("return repository.GetActive(expr);"));

            var m16 = new ContainerGen();
            m16.Signature = "public E FirstOrDefault()";
            m16.Body.Add(new StatementGen("return repository.FirstOrDefault();"));

            var m161 = new ContainerGen();
            m161.Signature = "public E FirstOrDefault(Expression<Func<E, bool>> expr)";
            m161.Body.Add(new StatementGen("return repository.FirstOrDefault(expr);"));

            var m17 = new ContainerGen();
            m17.Signature = "public async Task<E> FirstOrDefaultAsync()";
            m17.Body.Add(new StatementGen("return await repository.FirstOrDefaultAsync();"));

            var m171 = new ContainerGen();
            m171.Signature = "public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)";
            m171.Body.Add(new StatementGen("return await repository.FirstOrDefaultAsync(expr);"));

            BaseServiceBody.Add(
                s1, new StatementGen(""),
                m31, new StatementGen(""),
                m32, new StatementGen("", "#region CRUD Area"),
                m33, new StatementGen(""),
                m4, new StatementGen(""),
                m41, new StatementGen(""),
                m6, new StatementGen(""),
                m8, new StatementGen(""),
                m10, new StatementGen(""),
                m101, new StatementGen(""),
                m102, new StatementGen(""),
                m12, new StatementGen(""),
                m13, new StatementGen(""),
                m141, new StatementGen(""),
                m1411, new StatementGen(""),
                m142, new StatementGen(""),
                m1422, new StatementGen(""),
                m14, new StatementGen(""),
                m15, new StatementGen(""),
                m16, new StatementGen(""),
                m161, new StatementGen(""),
                m17, new StatementGen(""),
                m171, new StatementGen("#endregion"));
        }

    }
}
