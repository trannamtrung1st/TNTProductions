using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.DataServiceTemplate.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.DataServiceTemplate.Models.Repositories
{
    public class RepositoryGen : FileGen
    {
        private DataInfo Data { get; set; }
        public RepositoryGen(DataInfo dt)
        {
            Data = dt;
            Directive.Add("System.Linq.Expressions", dt.ProjectName + ".Models"
                , dt.ProjectName + ".Managers"
                , "TNT.IoContainer.Container"
                , "System.Data.Entity.Infrastructure");
            ResolveMapping.Add("context", dt.ContextName);

            //GENERATE
            GenerateNamespace();
            GenerateIBaseRepository();
            GenerateBaseRepository();
            GenerateBaseRepositoryBody();
        }

        //generate namespace
        private ContainerGen Namespace { get; set; }
        private BodyGen NamespaceBody { get; set; }
        public void GenerateNamespace()
        {
            Namespace = new ContainerGen();
            Namespace.Signature = "namespace " + Data.ProjectName + ".Models.Repositories";
            NamespaceBody = Namespace.Body;

            Content = Namespace;
        }

        //generate IBaseRepository<E, K> : IReusable
        private ContainerGen IBaseRepository { get; set; }
        private BodyGen IBaseRepositoryBody { get; set; }
        public void GenerateIBaseRepository()
        {
            var IRepository = new ContainerGen();
            IRepository.Signature = "public partial interface IRepository: IReusable";
            NamespaceBody.Add(IRepository);

            IBaseRepository = new ContainerGen();
            IBaseRepository.Signature = "public partial interface IBaseRepository<E, K> : IRepository";
            IBaseRepositoryBody = IBaseRepository.Body;

            IBaseRepositoryBody.Add(
                new StatementGen(
                    "bool AutoSave { get; set; }",
                    "",
                    "E Add(E entity);",
                    "Task<E> AddAsync(E entity);",
                    "E Update(E entity);",
                    "Task < E > UpdateAsync(E entity);",
                    "E Delete(E entity);",
                    "Task<E> DeleteAsync(E entity);",
                    "E Delete(K key);",
                    "Task<E> DeleteAsync(K key);",
                    "E FindById(K key);",
                    "Task<E> FindByIdAsync(K key);",
                    "E FindActiveById(K key);",
                    "Task<E> FindActiveByIdAsync(K key);",
                    "E FindByIdInclude<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                    "Task<E> FindByIdIncludeAsync<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                    "E Activate(E entity);",
                    "E Activate(K key);",
                    "E Deactivate(E entity);",
                    "E Deactivate(K key);",
                    "IQueryable<E> GetActive();",
                    "IQueryable<E> GetActive(Expression<Func<E, bool>> expr);",
                    "E FirstOrDefault();",
                    "E FirstOrDefault(Expression<Func<E, bool>> expr);",
                    "Task<E> FirstOrDefaultAsync();",
                    "Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);",
                    "E SingleOrDefault(Expression<Func<E, bool>> expr);",
                    "Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr);",
                    "DbRawSqlQuery<E> SqlQuery(string sql, params object[] parameters);",
                    "DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters);"
                ));

            NamespaceBody.Add(IBaseRepository, new StatementGen(""));
        }

        //generate BaseRepository class

        private ContainerGen BaseRepository { get; set; }
        private BodyGen BaseRepositoryBody { get; set; }
        public void GenerateBaseRepository()
        {
            BaseRepository = new ContainerGen();
            BaseRepository.Signature =
                "public abstract partial class BaseRepository<E, K> : IBaseRepository<E, K> where E : class";
            BaseRepositoryBody = BaseRepository.Body;

            NamespaceBody.Add(BaseRepository);
        }

        public void GenerateBaseRepositoryBody()
        {
            var s12 = new StatementGen(
                "protected `context` context;",
                "public bool AutoSave { get; set; }");

            var c3 = new ContainerGen();
            c3.Signature = "public BaseRepository(IUnitOfWork uow)";
            c3.Body.Add(new StatementGen(
                //"AutoSave = true;",
                "this.context = uow.Context;"));

            var c4 = new ContainerGen();
            c4.Signature = "public BaseRepository()";
            //c4.Body.Add(new StatementGen(
            //    "AutoSave = true;"));

            var m5 = new ContainerGen();
            m5.Signature = "public DbRawSqlQuery<E> SqlQuery(string sql, params object[] parameters)";
            m5.Body.Add(new StatementGen("return context.Database.SqlQuery<E>(sql, parameters);"));

            var m7 = new ContainerGen();
            m7.Signature = "public DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters)";
            m7.Body.Add(new StatementGen("return context.Database.SqlQuery<T>(sql, parameters);"));

            var m9 = new ContainerGen();
            m9.Signature = "public void ReInit(params object[] initParams)";
            m9.Body.Add(new StatementGen(
                "//params order: 0/ uow",
                "context = ((IUnitOfWork)initParams[0]).Context;"));
            //"AutoSave = true;"));

            var cm10 = new CommentGen(type: CommentType.BLOCK);
            cm10.Add("******************** ABSTRACT AREA *********************");

            var s11 = new StatementGen(
                "public abstract E Add(E entity);",
                "public abstract Task<E> AddAsync(E entity);",
                "public abstract E Update(E entity);",
                "public abstract Task<E> UpdateAsync(E entity);",
                "public abstract E Delete(E entity);",
                "public abstract Task<E> DeleteAsync(E entity);",
                "public abstract E Delete(K key);",
                "public abstract Task<E> DeleteAsync(K key);",
                "public abstract E FindById(K key);",
                "public abstract Task<E> FindByIdAsync(K key);",
                "public abstract E FindActiveById(K key);",
                "public abstract Task<E> FindActiveByIdAsync(K key);",
                "public abstract E FindByIdInclude<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                "public abstract Task<E> FindByIdIncludeAsync<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                "public abstract E Activate(E entity);",
                "public abstract E Activate(K key);",
                "public abstract E Deactivate(E entity);",
                "public abstract E Deactivate(K key);",
                "public abstract IQueryable<E> GetActive();",
                "public abstract IQueryable<E> GetActive(Expression<Func<E, bool>> expr);",
                "public abstract E FirstOrDefault();",
                "public abstract E FirstOrDefault(Expression<Func<E, bool>> expr);",
                "public abstract Task<E> FirstOrDefaultAsync();",
                "public abstract Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);",
                "public abstract E SingleOrDefault(Expression<Func<E, bool>> expr);",
                "public abstract Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr);");

            BaseRepositoryBody.Add(
                s12, new StatementGen(""),
                c3, new StatementGen(""),
                c4, new StatementGen("", "#region SqlQuery"),
                m5, new StatementGen(""),
                m7, new StatementGen("#endregion", ""),
                m9, new StatementGen(""),
                cm10, new StatementGen(""),
                s11, new StatementGen("")
                );

        }

    }
}
