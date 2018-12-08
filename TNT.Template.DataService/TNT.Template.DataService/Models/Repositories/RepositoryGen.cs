using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Template.DataService.Data;
using TNT.TemplateAPI.Generators;

namespace TNT.Template.DataService.Models.Repositories
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
                , "System.Data.Entity"
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

        private ContainerGen IBaseRepository { get; set; }
        private BodyGen IBaseRepositoryBody { get; set; }
        public void GenerateIBaseRepository()
        {
            var IRepository = new ContainerGen();
            IRepository.Signature = "public partial interface IRepository";
            NamespaceBody.Add(IRepository);

            IBaseRepository = new ContainerGen();
            IBaseRepository.Signature = "public partial interface IBaseRepository<E, K> : IRepository";
            IBaseRepositoryBody = IBaseRepository.Body;

            IBaseRepositoryBody.Add(
                new StatementGen(
                    //"bool AutoSave { get; set; }",
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
                    "E FindActiveById(K key);",
                    "Task<E> FindActiveByIdAsync(K key);",
                    //"E FindByIdInclude<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                    //"Task<E> FindByIdIncludeAsync<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
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
                "protected DbContext context;",
                "protected DbSet<E> dbSet;");

            var c3 = new ContainerGen();
            c3.Signature = "public BaseRepository(IUnitOfWork uow)";
            c3.Body.Add(new StatementGen(
                "this.context = uow.Context;",
                "this.dbSet = context.Set<E>();"));

            var c4 = new ContainerGen();
            c4.Signature = "public BaseRepository(DbContext context)";
            c4.Body.Add(new StatementGen(
                "this.context = context;",
                "this.dbSet = context.Set<E>();"));

            var m31 = new ContainerGen();
            m31.Signature = "public int SaveChanges()";
            m31.Body.Add(new StatementGen(
                "return context.SaveChanges();"));

            var m32 = new ContainerGen();
            m32.Signature = "public async Task<int> SaveChangesAsync()";
            m32.Body.Add(new StatementGen(
                "return await context.SaveChangesAsync();"));

            var m5 = new ContainerGen();
            m5.Signature = "public DbRawSqlQuery<E> SqlQuery(string sql, params object[] parameters)";
            m5.Body.Add(new StatementGen("return context.Database.SqlQuery<E>(sql, parameters);"));

            var m7 = new ContainerGen();
            m7.Signature = "public DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters)";
            m7.Body.Add(new StatementGen("return context.Database.SqlQuery<T>(sql, parameters);"));

            var m91 = new ContainerGen();
            m91.Signature = "public void Reload(E entity)";
            m91.Body.Add(new StatementGen(
                "context.Entry(entity).Reload();"));

            var m10 = new ContainerGen();
            m10.Signature = "public E Add(E entity)";
            m10.Body.Add(new StatementGen(
                "entity = dbSet.Add(entity);",
                "return entity;"));

            var m101 = new ContainerGen();
            m101.Signature = "public IEnumerable<E> AddRange(IEnumerable<E> entities)";
            m101.Body.Add(new StatementGen(
                "return dbSet.AddRange(entities);"));

            var m11 = new ContainerGen();
            m11.Signature = "public E Remove(E entity)";
            m11.Body.Add(new StatementGen(
                "entity = dbSet.Remove(entity);",
                "return entity;"));

            var m12 = new ContainerGen();
            m12.Signature = "public E Remove(K key)";
            m12.Body.Add(new StatementGen(
                "var entity = FindById(key);",
                "if (entity!=null)",
                "\tentity = dbSet.Remove(entity);",
                "return entity;"));

            var m13 = new ContainerGen();
            m13.Signature = "public IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr)";
            m13.Body.Add(new StatementGen(
                "return dbSet.RemoveRange(GetActive(expr).ToList());"));

            var m14 = new ContainerGen();
            m14.Signature = "public IEnumerable<E> RemoveRange(IEnumerable<E> list)";
            m14.Body.Add(new StatementGen(
                "return dbSet.RemoveRange(list);"));

            var m141 = new ContainerGen();
            m141.Signature = "public E Update(E entity)";
            m141.Body.Add(new StatementGen(
                "entity = dbSet.Attach(entity);",
                "context.Entry(entity).State = EntityState.Modified;",
                "return entity;"));

            var m15 = new ContainerGen();
            m15.Signature = "public E FirstOrDefault()";
            m15.Body.Add(new StatementGen("return GetActive().FirstOrDefault();"));

            var m151 = new ContainerGen();
            m151.Signature = "public E FirstOrDefault(Expression<Func<E, bool>> expr)";
            m151.Body.Add(new StatementGen("return GetActive().FirstOrDefault(expr);"));

            var m16 = new ContainerGen();
            m16.Signature = "public async Task<E> FirstOrDefaultAsync()";
            m16.Body.Add(new StatementGen("return await GetActive().FirstOrDefaultAsync();"));

            var m161 = new ContainerGen();
            m161.Signature = "public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)";
            m161.Body.Add(new StatementGen("return await GetActive().FirstOrDefaultAsync(expr);"));

            var m17 = new ContainerGen();
            m17.Signature = "public E SingleOrDefault(Expression<Func<E, bool>> expr)";
            m17.Body.Add(new StatementGen("return GetActive().SingleOrDefault(expr);"));

            var m18 = new ContainerGen();
            m18.Signature = "public async Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr)";
            m18.Body.Add(new StatementGen("return await GetActive().SingleOrDefaultAsync(expr);"));

            var cm10 = new CommentGen(type: CommentType.BLOCK);
            cm10.Add("******************** ABSTRACT AREA *********************");

            var s11 = new StatementGen(
                "public abstract E FindById(K key);",
                "public abstract Task<E> FindByIdAsync(K key);",
                "public abstract E FindActiveById(K key);",
                "public abstract Task<E> FindActiveByIdAsync(K key);",
                //"public abstract E FindByIdInclude<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                //"public abstract Task<E> FindByIdIncludeAsync<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);",
                "public abstract E Activate(E entity);",
                "public abstract E Activate(K key);",
                "public abstract E Deactivate(E entity);",
                "public abstract E Deactivate(K key);",
                "public abstract IQueryable<E> GetActive();",
                "public abstract IQueryable<E> GetActive(Expression<Func<E, bool>> expr);");

            BaseRepositoryBody.Add(
                s12, new StatementGen(""),
                c3, new StatementGen(""),
                c4, new StatementGen(""),
                m31, new StatementGen(""),
                m32, new StatementGen(""),
                m5, new StatementGen(""),
                m7, new StatementGen(""),
                m91, new StatementGen(""),
                m10, new StatementGen(""),
                m101, new StatementGen(""),
                m11, new StatementGen(""),
                m12, new StatementGen(""),
                m13, new StatementGen(""),
                m14, new StatementGen(""),
                m141, new StatementGen(""),
                m15, new StatementGen(""),
                m151, new StatementGen(""),
                m16, new StatementGen(""),
                m161, new StatementGen(""),
                m17, new StatementGen(""),
                m18, new StatementGen(""),
                cm10, new StatementGen(""),
                s11, new StatementGen("")
                );

        }

    }
}
