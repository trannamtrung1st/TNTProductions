using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Core.Template.DataService.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.Models.Repositories
{
    public class RepositoryGen : FileGen
    {
        private ContextInfo Data { get; set; }
        public RepositoryGen(ContextInfo dt)
        {
            Data = dt;
            Directive.Add("System.Linq.Expressions", dt.ContextNamespace
                , "Microsoft.EntityFrameworkCore"
                , "Microsoft.EntityFrameworkCore.ChangeTracking");
            ResolveMapping["context"] = dt.ContextName;

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
            IBaseRepository.Signature = "public partial interface IBaseRepository<E, K> : IRepository where E : class";
            IBaseRepositoryBody = IBaseRepository.Body;

            IBaseRepositoryBody.Add(
                new StatementGen(
                    "int SaveChanges();",
                    "Task<int> SaveChangesAsync();",
                    "",
                    "void Reload(E entity);",
                    "EntityEntry<E> Create(E entity);",
                    "void CreateRange(IEnumerable<E> entities);",
                    "EntityEntry<E> Update(E entity);",
                    "void UpdateRange(IEnumerable<E> entities);",
                    "EntityEntry<E> Update(E entity, Action<E> patchAction);",
                    "EntityEntry<E> Attach(E entity);",
                    "EntityEntry<E> Remove(E entity);",
                    "EntityEntry<E> Remove(K key);",
                    "void RemoveIf(Expression<Func<E, bool>> expr);",
                    "void RemoveRange(IEnumerable<E> list);",
                    "E FindById(K key);",
                    "Task<E> FindByIdAsync(K key);",
                    "IQueryable<E> AsNoTracking();",
                    "DbSet<E> Get();",
                    "IQueryable<E> Get(Expression<Func<E, bool>> expr);",
                    "E FirstOrDefault();",
                    "E FirstOrDefault(Expression<Func<E, bool>> expr);",
                    "Task<E> FirstOrDefaultAsync();",
                    "Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);",
                    "E SingleOrDefault(Expression<Func<E, bool>> expr);",
                    "Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr);"
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
                "protected DbSet<E> dbSet;",
                "protected IUnitOfWork uow;");

            var c4 = new ContainerGen();
            c4.Signature = "public BaseRepository(IUnitOfWork uow)";
            c4.Body.Add(new StatementGen(
                "this.uow = uow;",
                "this.context = uow.Context;",
                "this.dbSet = context.Set<E>();"));

            var c5 = new ContainerGen();
            c5.Signature = "public BaseRepository(DbContext context)";
            c5.Body.Add(new StatementGen(
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

            var m91 = new ContainerGen();
            m91.Signature = "public void Reload(E entity)";
            m91.Body.Add(new StatementGen(
                "context.Entry(entity).Reload();"));

            var m10 = new ContainerGen();
            m10.Signature = "public EntityEntry<E> Create(E entity)";
            m10.Body.Add(new StatementGen(
                "return dbSet.Add(entity);"));

            var m101 = new ContainerGen();
            m101.Signature = "public void CreateRange(IEnumerable<E> entities)";
            m101.Body.Add(new StatementGen(
                "dbSet.AddRange(entities);"));

            var m11 = new ContainerGen();
            m11.Signature = "public EntityEntry<E> Remove(E entity)";
            m11.Body.Add(new StatementGen(
                "return dbSet.Remove(entity);"));

            var m12 = new ContainerGen();
            m12.Signature = "public EntityEntry<E> Remove(K key)";
            m12.Body.Add(new StatementGen(
                "var entity = FindById(key);",
                "if (entity!=null)",
                "\treturn dbSet.Remove(entity);",
                "return null;"));

            var m13 = new ContainerGen();
            m13.Signature = "public void RemoveIf(Expression<Func<E, bool>> expr)";
            m13.Body.Add(new StatementGen(
                "dbSet.RemoveRange(dbSet.Where(expr).ToList());"));

            var m14 = new ContainerGen();
            m14.Signature = "public void RemoveRange(IEnumerable<E> list)";
            m14.Body.Add(new StatementGen(
                "dbSet.RemoveRange(list);"));

            var m141 = new ContainerGen();
            m141.Signature = "public EntityEntry<E> Update(E entity)";
            m141.Body.Add(new StatementGen(
                "var entry = context.Entry(entity);",
                "entry.State = EntityState.Modified;",
                "return entry;"));

            var m1421 = new ContainerGen();
            m1421.Signature = "public EntityEntry<E> Update(E entity, Action<E> patchAction)";
            m1421.Body.Add(new StatementGen(
                "var entry = dbSet.Attach(entity);",
                "patchAction.Invoke(entity);",
                "return entry;"));

            var m1411 = new ContainerGen();
            m1411.Signature = "public void UpdateRange(IEnumerable<E> entities)";
            m1411.Body.Add(new StatementGen(
                "foreach (var e in entities)",
                "\tcontext.Entry(e).State = EntityState.Modified;"));

            var m1412 = new ContainerGen();
            m1412.Signature = "public EntityEntry<E> Attach(E entity)";
            m1412.Body.Add(new StatementGen(
                "return dbSet.Attach(entity);"));

            var mm1 = new ContainerGen();
            mm1.Signature = "public IQueryable<E> AsNoTracking()";
            mm1.Body.Add(new StatementGen("return dbSet.AsNoTracking();"));

            var m142 = new ContainerGen();
            m142.Signature = "public DbSet<E> Get()";
            m142.Body.Add(new StatementGen("return dbSet;"));

            var m143 = new ContainerGen();
            m143.Signature = "public IQueryable<E> Get(Expression<Func<E, bool>> expr)";
            m143.Body.Add(new StatementGen("return dbSet.Where(expr);"));

            var m15 = new ContainerGen();
            m15.Signature = "public E FirstOrDefault()";
            m15.Body.Add(new StatementGen("return dbSet.FirstOrDefault();"));

            var m151 = new ContainerGen();
            m151.Signature = "public E FirstOrDefault(Expression<Func<E, bool>> expr)";
            m151.Body.Add(new StatementGen("return dbSet.FirstOrDefault(expr);"));

            var m16 = new ContainerGen();
            m16.Signature = "public async Task<E> FirstOrDefaultAsync()";
            m16.Body.Add(new StatementGen("return await dbSet.FirstOrDefaultAsync();"));

            var m161 = new ContainerGen();
            m161.Signature = "public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)";
            m161.Body.Add(new StatementGen("return await dbSet.FirstOrDefaultAsync(expr);"));

            var m17 = new ContainerGen();
            m17.Signature = "public E SingleOrDefault(Expression<Func<E, bool>> expr)";
            m17.Body.Add(new StatementGen("return dbSet.SingleOrDefault(expr);"));

            var m18 = new ContainerGen();
            m18.Signature = "public async Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr)";
            m18.Body.Add(new StatementGen("return await dbSet.SingleOrDefaultAsync(expr);"));

            var cm10 = new CommentGen(type: CommentType.BLOCK);
            cm10.Add("******************** ABSTRACT AREA *********************");

            var s11 = new StatementGen(
                "public abstract E FindById(K key);",
                "public abstract Task<E> FindByIdAsync(K key);");

            BaseRepositoryBody.Add(
                s12, new StatementGen(""),
                c4, new StatementGen(""));
            if (Data.DIContainer == DIContainer.TContainer)
                BaseRepositoryBody.Add(c5, new StatementGen(""));
            BaseRepositoryBody.Add(
                m31, new StatementGen(""),
                m32, new StatementGen(""),
                m91, new StatementGen(""),
                m10, new StatementGen(""),
                m101, new StatementGen(""),
                m11, new StatementGen(""),
                m12, new StatementGen(""),
                m13, new StatementGen(""),
                m14, new StatementGen(""),
                m141, new StatementGen(""),
                m1411, new StatementGen(""),
                m1421, new StatementGen(""),
                m1412, new StatementGen(""),
                mm1, new StatementGen(""),
                m142, new StatementGen(""),
                m143, new StatementGen(""),
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
