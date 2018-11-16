using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Domains
{
    public class BaseDomainGen : FileGen
    {
        private DataInfo Data { get; set; }
        public BaseDomainGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add(
                Data.ProjectName + ".Models.Services",
                Data.ProjectName + ".ViewModels",
                Data.ProjectName + ".Managers",
                Data.ProjectName + ".Utilities",
                Data.ProjectName + ".Models",
                Data.ProjectName + ".Global",
                "System.Linq.Expressions",
                "TNT.IoContainer.Wrapper");

            //GENERATE
            GenerateNamespace();
            //GenerateIBaseDomain();
            GenerateBaseDomain();
            GenerateBaseDomainBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Models.Domains";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        ////generate IBaseDomain
        //private ContainerGen IBaseDomain { get; set; }
        //private BodyGen IBaseDomainBody { get; set; }
        //public void GenerateIBaseDomain()
        //{
        //    IBaseDomain = new ContainerGen();
        //    IBaseDomain.Signature = "public partial interface IBaseDomain<E, VM, K>";
        //    IBaseDomainBody = IBaseDomain.Body;

        //    IBaseDomainBody.Add(
        //        new StatementGen(
        //            "E Add(E entity);",
        //            //"Task<E> AddAsync(E entity);",
        //            "E Update(E entity);",
        //            //"Task<E> UpdateAsync(E entity);",
        //            "E Remove(E entity);",
        //            //"Task<E> RemoveAsync(E entity);",
        //            "E Remove(K key);",
        //            "IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);",
        //            "IEnumerable<E> RemoveRange(IEnumerable<E> list);",
        //            //"Task<E> RemoveAsync(K key);",
        //            "E FindById(K key);",
        //            "Task<E> FindByIdAsync(K key);",
        //            "E Activate(E entity);",
        //            "E Activate(K key);",
        //            "E Deactivate(E entity);",
        //            "E Deactivate(K key);",
        //            "IEnumerable<E> GetActive();",
        //            //"Task<IEnumerable<E>> GetActiveAsync();",
        //            "IEnumerable<E> GetActive(Expression<Func<E, bool>> expr);",
        //            //"Task<IEnumerable<E>> GetActiveAsync(Expression<Func<E, bool>> expr);",
        //            "E FirstOrDefault(Expression<Func<E, bool>> expr);",
        //            "Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);"
        //        ));

        //    NamespaceBody.Add(IBaseDomain, new StatementGen(""));
        //}

        //generate BaseDomain
        private ContainerGen BaseDomain { get; set; }
        private BodyGen BaseDomainBody { get; set; }
        public void GenerateBaseDomain()
        {
            BaseDomain = new ContainerGen();
            BaseDomain.Signature = "public abstract partial class BaseDomain";/*<E, VM, K, S> : IBaseDomain<E, VM, K> where S: class, IBaseService<E, VM, K> where E: class, IBaseEntity<VM> where VM: class";*/
            BaseDomainBody = BaseDomain.Body;

            NamespaceBody.Add(BaseDomain);
        }

        public void GenerateBaseDomainBody()
        {
            var c0 = new ContainerGen();
            c0.Signature = "public BaseDomain()";
            c0.Body.Add(new StatementGen(
                "_uow = G.TContainer.ResolveRequestScope<IUnitOfWork>();"));
            //"baseService = _uow.Service<S>();"));

            var c1 = new ContainerGen();
            c1.Signature = "public BaseDomain(IUnitOfWork uow)";
            c1.Body.Add(new StatementGen(
                "_uow = uow;"));
            //"baseService = _uow.Service<S>();"));

            var s2 = new StatementGen(
                "private IUnitOfWork _uow;");
            var m2 = new StatementGen(
                "protected IUnitOfWork UoW",
                "{",
                "\tget",
                "\t{",
                "\t\treturn _uow;",
                "\t}",
                "}");
            //var s3 = new StatementGen(
            //    "private S baseService;");
            //var m3 = new StatementGen(
            //    "protected S BaseService",
            //    "{",
            //    "\tget",
            //    "\t{",
            //    "\t\treturn baseService;",
            //    "\t}",
            //    "}");

            //var m4 = new ContainerGen();
            //m4.Signature = "public E Add(E entity)";
            //m4.Body.Add(new StatementGen(
            //    "return baseService.Add(entity);"));

            ////var m5 = new ContainerGen();
            ////m5.Signature = "public async Task<E> AddAsync(E entity)";
            ////m5.Body.Add(new StatementGen(
            ////    "return (await baseService.AddAsync(entity));"));

            //var m6 = new ContainerGen();
            //m6.Signature = "public E Update(E entity)";
            //m6.Body.Add(new StatementGen(
            //    "return baseService.Update(entity);"));

            ////var m7 = new ContainerGen();
            ////m7.Signature = "public async Task<E> UpdateAsync(E entity)";
            ////m7.Body.Add(new StatementGen(
            ////    "return (await baseService.UpdateAsync(entity));"));

            //var m8 = new ContainerGen();
            //m8.Signature = "public E Remove(E entity)";
            //m8.Body.Add(new StatementGen(
            //    "return baseService.Remove(entity);"));

            ////var m9 = new ContainerGen();
            ////m9.Signature = "public async Task<E> RemoveAsync(E entity)";
            ////m9.Body.Add(new StatementGen(
            ////    "return (await baseService.RemoveAsync(entity));"));

            //var m10 = new ContainerGen();
            //m10.Signature = "public E Remove(K key)";
            //m10.Body.Add(new StatementGen(
            //    "var entity = baseService.Remove(key);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));

            //var m101 = new ContainerGen();
            //m101.Signature = "public IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr)";
            //m101.Body.Add(new StatementGen(
            //    "return baseService.RemoveIf(expr);"));

            //var m102 = new ContainerGen();
            //m102.Signature = "public IEnumerable<E> RemoveRange(IEnumerable<E> list)";
            //m102.Body.Add(new StatementGen(
            //    "return baseService.RemoveRange(list);"));

            ////var m11 = new ContainerGen();
            ////m11.Signature = "public async Task<E> RemoveAsync(K key)";
            ////m11.Body.Add(new StatementGen(
            ////    "var entity = await baseService.RemoveAsync(key);",
            ////    "if (entity != null)",
            ////    "\treturn entity;",
            ////    "return null;"));

            //var m12 = new ContainerGen();
            //m12.Signature = "public E FindById(K key)";
            //m12.Body.Add(new StatementGen(
            //    "var entity = baseService.FindById(key);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));

            //var m13 = new ContainerGen();
            //m13.Signature = "public async Task<E> FindByIdAsync(K key)";
            //m13.Body.Add(new StatementGen(
            //    "var entity = await baseService.FindByIdAsync(key);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));

            //var m141 = new ContainerGen();
            //m141.Signature = "public E Activate(E entity)";
            //m141.Body.Add(new StatementGen(
            //    "return baseService.Activate(entity);"));

            //var m1411 = new ContainerGen();
            //m1411.Signature = "public E Activate(K key)";
            //m1411.Body.Add(new StatementGen(
            //    "var entity = baseService.Activate(key);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));

            //var m142 = new ContainerGen();
            //m142.Signature = "public E Deactivate(E entity)";
            //m142.Body.Add(new StatementGen(
            //    "return baseService.Deactivate(entity);"));

            //var m1422 = new ContainerGen();
            //m1422.Signature = "public E Deactivate(K key)";
            //m1422.Body.Add(new StatementGen(
            //    "var entity = baseService.Deactivate(key);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));

            //var m14 = new ContainerGen();
            //m14.Signature = "public IEnumerable<E> GetActive()";
            //m14.Body.Add(new StatementGen(
            //    "return baseService.GetActive().AsEnumerable();"));

            //var m15 = new ContainerGen();
            //m15.Signature = "public IEnumerable<E> GetActive(Expression<Func<E, bool>> expr)";
            //m15.Body.Add(new StatementGen(
            //    "return baseService.GetActive(expr).AsEnumerable();"));

            ////var m16 = new ContainerGen();
            ////m16.Signature = "public async Task<IEnumerable<E>> GetActiveAsync()";
            ////m16.Body.Add(new StatementGen(
            ////    "return await Task.Run(() =>",
            ////    "{",
            ////    "\treturn GetActive();",
            ////    "});"));

            ////var m17 = new ContainerGen();
            ////m17.Signature = "public async Task<IEnumerable<E>> GetActiveAsync(Expression<Func<E, bool>> expr)";
            ////m17.Body.Add(new StatementGen(
            ////    "return await Task.Run(() =>",
            ////    "{",
            ////    "\treturn GetActive(expr);",
            ////    "});"));

            //var m18 = new ContainerGen();
            //m18.Signature = "public E FirstOrDefault(Expression<Func<E, bool>> expr)";
            //m18.Body.Add(new StatementGen(
            //    "var entity = baseService.FirstOrDefault(expr);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));

            //var m19 = new ContainerGen();
            //m19.Signature = "public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)";
            //m19.Body.Add(new StatementGen(
            //    "var entity = await baseService.FirstOrDefaultAsync(expr);",
            //    "if (entity != null)",
            //    "\treturn entity;",
            //    "return null;"));


            if (Data.RequestScope)
            {
                BaseDomainBody.Add(c0, new StatementGen(""));
            }

            BaseDomainBody.Add(
                c1, new StatementGen(""),
                s2, m2, new StatementGen("")
                //s3, m3, new StatementGen(""),
                //m4, new StatementGen(""),
                ////m5, new StatementGen(""),
                //m6, new StatementGen(""),
                ////m7, new StatementGen(""),
                //m8, new StatementGen(""),
                ////m9, new StatementGen(""),
                //m10, new StatementGen(""),
                //m101, new StatementGen(""),
                //m102, new StatementGen(""),
                ////m11, new StatementGen(""),
                //m12, new StatementGen(""),
                //m13, new StatementGen(""),
                //m141, new StatementGen(""),
                //m1411, new StatementGen(""),
                //m142, new StatementGen(""),
                //m1422, new StatementGen(""),
                //m14, new StatementGen(""),
                //m15, new StatementGen(""),
                ////m16, new StatementGen(""),
                ////m17, new StatementGen(""),
                //m18, new StatementGen(""),
                //m19, new StatementGen("")
                );
        }

    }
}
