using System;
using System.Collections.Generic;
using System.Text;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.Generators;

namespace TNT.Core.Template.DataService.MongoDB.Models.Repositories
{
    public class RepositoryGen : FileGen
    {
        private Info Info { get; set; }
        public RepositoryGen(Info info)
        {
            Info = info;
            Directive.Add("System.Linq.Expressions", "MongoDB.Driver.Linq"
                , "MongoDB.Driver"
                , $"{info.ProjectName}.Models.Configs");

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
            Namespace.Signature = "namespace " + Info.ProjectName + ".Models.Repositories";
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
                    "E Create(E entity);",
                    "Task<E> CreateAsync(E entity);",
                    "IEnumerable<E> Create(IEnumerable<E> entities);",
                    "Task<IEnumerable<E>> CreateAsync(IEnumerable<E> entities);",
                    "E Create(IClientSessionHandle handle, E entity);",
                    "Task<E> CreateAsync(IClientSessionHandle handle, E entity);",
                    "IEnumerable<E> Create(IClientSessionHandle handle, IEnumerable<E> entities);",
                    "Task<IEnumerable<E>> CreateAsync(IClientSessionHandle handle, IEnumerable<E> entities);",
                    "DeleteResult Remove(K id);",
                    "DeleteResult RemoveIf(Expression<Func<E, bool>> expr);",
                    "DeleteResult Remove(IClientSessionHandle handle, K id);",
                    "DeleteResult RemoveIf(IClientSessionHandle handle, Expression<Func<E, bool>> expr);",
                    "Task<DeleteResult> RemoveAsync(K id);",
                    "Task<DeleteResult> RemoveIfAsync(Expression<Func<E, bool>> expr);",
                    "Task<DeleteResult> RemoveAsync(IClientSessionHandle handle, K id);",
                    "Task<DeleteResult> RemoveIfAsync(IClientSessionHandle handle, Expression<Func<E, bool>> expr);",
                    "ReplaceOneResult Replace(E entity);",
                    "Task<ReplaceOneResult> ReplaceAsync(E entity);",
                    "ReplaceOneResult Replace(IClientSessionHandle handle, E entity);",
                    "Task<ReplaceOneResult> ReplaceAsync(IClientSessionHandle handle, E entity);",
                    "IMongoQueryable<E> AsQueryable();",
                    "IFindFluent<E, E> Get();",
                    "IFindFluent<E, E> Get(Expression<Func<E, bool>> expr);",
                    "Task<IAsyncCursor<E>> GetAsync();",
                    "Task<IAsyncCursor<E>> GetAsync(Expression<Func<E, bool>> expr);"
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
            var s1 = new StatementGen(
                "protected readonly IMongoClient _client;",
                "protected readonly IMongoDatabase _database;",
                "protected readonly IMongoCollection<E> _collection;");

            var c2 = new ContainerGen();
            c2.Signature = "public BaseRepository(IMongoDbSettings settings)";
            c2.Body.Add(new StatementGen(
                "_client = new MongoClient(settings.ConnectionString);",
                "_database = _client.GetDatabase(settings.DatabaseName);",
                "_collection = _database.GetCollection<E>(nameof(E));"));

            var s3 = new StatementGen("#region Create");

            var m4 = new ContainerGen();
            m4.Signature = "public E Create(E entity)";
            m4.Body.Add(new StatementGen(
                "_collection.InsertOne(entity);",
                "return entity;"
                ));

            var m5 = new ContainerGen();
            m5.Signature = "public async Task<E> CreateAsync(E entity)";
            m5.Body.Add(new StatementGen(
                "await _collection.InsertOneAsync(entity);",
                "return entity;"
                ));

            var m6 = new ContainerGen();
            m6.Signature = "public IEnumerable<E> Create(IEnumerable<E> entities)";
            m6.Body.Add(new StatementGen(
                "_collection.InsertMany(entities);",
                "return entities;"
                ));

            var m7 = new ContainerGen();
            m7.Signature = "public async Task<IEnumerable<E>> CreateAsync(IEnumerable<E> entities)";
            m7.Body.Add(new StatementGen(
                "await _collection.InsertManyAsync(entities);",
                "return entities;"
                ));

            var m8 = new ContainerGen();
            m8.Signature = "public E Create(IClientSessionHandle handle, E entity)";
            m8.Body.Add(new StatementGen(
                "_collection.InsertOne(handle, entity);",
                "return entity;"
                ));

            var m9 = new ContainerGen();
            m9.Signature = "public async Task<E> CreateAsync(IClientSessionHandle handle, E entity)";
            m9.Body.Add(new StatementGen(
                "await _collection.InsertOneAsync(handle, entity);",
                "return entity;"
                ));

            var m10 = new ContainerGen();
            m10.Signature = "public IEnumerable<E> Create(IClientSessionHandle handle, IEnumerable<E> entities)";
            m10.Body.Add(new StatementGen(
                "_collection.InsertMany(handle, entities);",
                "return entities;"
                ));

            var m11 = new ContainerGen();
            m11.Signature = "public async Task<IEnumerable<E>> CreateAsync(IClientSessionHandle handle, IEnumerable<E> entities)";
            m11.Body.Add(new StatementGen(
                "await _collection.InsertManyAsync(handle, entities);",
                "return entities;"
                ));

            var s12 = new StatementGen("#endregion");

            var s13 = new StatementGen("#region Delete");

            var s14 = new StatementGen("public abstract DeleteResult Remove(K id);");

            var m15 = new ContainerGen();
            m15.Signature = "public DeleteResult RemoveIf(Expression<Func<E, bool>> expr)";
            m15.Body.Add(new StatementGen(
                "return _collection.DeleteMany(expr);"
                ));

            var s16 = new StatementGen("public abstract DeleteResult Remove(IClientSessionHandle handle, K id);");

            var m17 = new ContainerGen();
            m17.Signature = "public DeleteResult RemoveIf(IClientSessionHandle handle, Expression<Func<E, bool>> expr)";
            m17.Body.Add(new StatementGen(
                "return _collection.DeleteMany(handle, expr);"
                ));

            var s18 = new StatementGen("public abstract Task<DeleteResult> RemoveAsync(K id);");

            var m19 = new ContainerGen();
            m19.Signature = "public async Task<DeleteResult> RemoveIfAsync(Expression<Func<E, bool>> expr)";
            m19.Body.Add(new StatementGen(
                "return await _collection.DeleteManyAsync(expr);"
                ));

            var s20 = new StatementGen("public abstract Task<DeleteResult> RemoveAsync(IClientSessionHandle handle, K id);");

            var m21 = new ContainerGen();
            m21.Signature = "public async Task<DeleteResult> RemoveIfAsync(IClientSessionHandle handle, Expression<Func<E, bool>> expr)";
            m21.Body.Add(new StatementGen(
                "return await _collection.DeleteManyAsync(handle, expr);"
                ));

            var s22 = new StatementGen("#endregion");
            var s23 = new StatementGen("#region Replace");
            var s24 = new StatementGen("public abstract ReplaceOneResult Replace(E entity);");
            var s25 = new StatementGen("public abstract Task<ReplaceOneResult> ReplaceAsync(E entity);");
            var s26 = new StatementGen("public abstract ReplaceOneResult Replace(IClientSessionHandle handle, E entity);");
            var s27 = new StatementGen("public abstract Task<ReplaceOneResult> ReplaceAsync(IClientSessionHandle handle, E entity);");
            var s28 = new StatementGen("#endregion");

            var s29 = new StatementGen("#region Read");

            var m30 = new ContainerGen();
            m30.Signature = "public IMongoQueryable<E> AsQueryable()";
            m30.Body.Add(new StatementGen(
                "return _collection.AsQueryable();"
                ));
            var m31 = new ContainerGen();
            m31.Signature = "public IFindFluent<E, E> Get()";
            m31.Body.Add(new StatementGen(
                "return _collection.Find(Builders<E>.Filter.Empty);"
                ));
            var m32 = new ContainerGen();
            m32.Signature = "public IFindFluent<E, E> Get(Expression<Func<E, bool>> expr)";
            m32.Body.Add(new StatementGen(
                "return _collection.Find(expr);"
                ));
            var m33 = new ContainerGen();
            m33.Signature = "public async Task<IAsyncCursor<E>> GetAsync()";
            m33.Body.Add(new StatementGen(
                "return await _collection.FindAsync<E>(Builders<E>.Filter.Empty);"
                ));

            var m34 = new ContainerGen();
            m34.Signature = "public async Task<IAsyncCursor<E>> GetAsync(Expression<Func<E, bool>> expr)";
            m34.Body.Add(new StatementGen(
                "return await _collection.FindAsync<E>(expr);"
                ));

            var s35 = new StatementGen("#endregion");

            var c36 = new CommentGen("********************* ABSTRACT AREA *********************", CommentType.BLOCK);

            var s37 = new StatementGen(
                "public abstract E FindById(K id);",
                "public abstract Task<E> FindByIdAsync(K id);");

            BaseRepositoryBody.Add(
                s1, new StatementGen(""),
                c2, new StatementGen(""),
                s3, new StatementGen(""),
                m4, new StatementGen(""),
                m5, new StatementGen(""),
                m6, new StatementGen(""),
                m7, new StatementGen(""),
                m8, new StatementGen(""),
                m9, new StatementGen(""),
                m10, new StatementGen(""),
                m11, new StatementGen(""),
                s12, new StatementGen(""),
                s13, new StatementGen(""),
                s14, new StatementGen(""),
                m15, new StatementGen(""),
                s16, new StatementGen(""),
                m17, new StatementGen(""),
                s18, new StatementGen(""),
                m19, new StatementGen(""),
                s20, new StatementGen(""),
                m21, new StatementGen(""),
                s22, new StatementGen(""),
                s23, new StatementGen(""),
                s24, new StatementGen(""),
                s25, new StatementGen(""),
                s26, new StatementGen(""),
                s27, new StatementGen(""),
                s28, new StatementGen(""),
                s29, new StatementGen(""),
                m30, new StatementGen(""),
                m31, new StatementGen(""),
                m32, new StatementGen(""),
                m33, new StatementGen(""),
                m34, new StatementGen(""),
                s35, new StatementGen(""),
                c36, new StatementGen(""),
                s37, new StatementGen(""));

        }

    }
}
