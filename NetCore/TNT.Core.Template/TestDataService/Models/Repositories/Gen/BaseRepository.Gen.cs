using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using TestDataService.Models.Configs;

namespace TestDataService.Models.Repositories
{
	public partial interface IRepository
	{
	}
	public partial interface IBaseRepository<E, K> : IRepository where E : class
	{
		E Create(E entity);
		Task<E> CreateAsync(E entity);
		IEnumerable<E> Create(IEnumerable<E> entities);
		Task<IEnumerable<E>> CreateAsync(IEnumerable<E> entities);
		E Create(IClientSessionHandle handle, E entity);
		Task<E> CreateAsync(IClientSessionHandle handle, E entity);
		IEnumerable<E> Create(IClientSessionHandle handle, IEnumerable<E> entities);
		Task<IEnumerable<E>> CreateAsync(IClientSessionHandle handle, IEnumerable<E> entities);
		E Remove(K id);
		DeleteResult RemoveIf(Expression<Func<E, bool>> expr);
		E Remove(IClientSessionHandle handle, K id);
		DeleteResult RemoveIf(IClientSessionHandle handle, Expression<Func<E, bool>> expr);
		Task<E> RemoveAsync(K id);
		Task<DeleteResult> RemoveIfAsync(Expression<Func<E, bool>> expr);
		Task<E> RemoveAsync(IClientSessionHandle handle, K id);
		Task<DeleteResult> RemoveIfAsync(IClientSessionHandle handle, Expression<Func<E, bool>> expr);
		E Replace(E entity);
		Task<E> ReplaceAsync(E entity);
		E Replace(IClientSessionHandle handle, E entity);
		Task<E> ReplaceAsync(IClientSessionHandle handle, E entity);
		IMongoQueryable<E> AsQueryable();
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		IFindFluent<E, E> Get();
		IFindFluent<E, E> Get(Expression<Func<E, bool>> expr);
		Task<IAsyncCursor<E>> GetAsync();
		Task<IAsyncCursor<E>> GetAsync(Expression<Func<E, bool>> expr);
	}
	
	public abstract partial class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
	{
		protected readonly IMongoClient _client;
		protected readonly IMongoDatabase _database;
		protected readonly IMongoCollection<E> _collection;
		
		public BaseRepository(IMongoDbSettings settings)
		{
			_client = new MongoClient(settings.ConnectionString);
			_database = _client.GetDatabase(settings.DatabaseName);
			_collection = _database.GetCollection<E>(typeof(E).Name);
		}
		
		#region Create
		
		public E Create(E entity)
		{
			_collection.InsertOne(entity);
			return entity;
		}
		
		public async Task<E> CreateAsync(E entity)
		{
			await _collection.InsertOneAsync(entity);
			return entity;
		}
		
		public IEnumerable<E> Create(IEnumerable<E> entities)
		{
			_collection.InsertMany(entities);
			return entities;
		}
		
		public async Task<IEnumerable<E>> CreateAsync(IEnumerable<E> entities)
		{
			await _collection.InsertManyAsync(entities);
			return entities;
		}
		
		public E Create(IClientSessionHandle handle, E entity)
		{
			_collection.InsertOne(handle, entity);
			return entity;
		}
		
		public async Task<E> CreateAsync(IClientSessionHandle handle, E entity)
		{
			await _collection.InsertOneAsync(handle, entity);
			return entity;
		}
		
		public IEnumerable<E> Create(IClientSessionHandle handle, IEnumerable<E> entities)
		{
			_collection.InsertMany(handle, entities);
			return entities;
		}
		
		public async Task<IEnumerable<E>> CreateAsync(IClientSessionHandle handle, IEnumerable<E> entities)
		{
			await _collection.InsertManyAsync(handle, entities);
			return entities;
		}
		
		#endregion
		
		#region Delete
		
		public abstract E Remove(K id);
		
		public DeleteResult RemoveIf(Expression<Func<E, bool>> expr)
		{
			return _collection.DeleteMany(expr);
		}
		
		public abstract E Remove(IClientSessionHandle handle, K id);
		
		public DeleteResult RemoveIf(IClientSessionHandle handle, Expression<Func<E, bool>> expr)
		{
			return _collection.DeleteMany(handle, expr);
		}
		
		public abstract Task<E> RemoveAsync(K id);
		
		public async Task<DeleteResult> RemoveIfAsync(Expression<Func<E, bool>> expr)
		{
			return await _collection.DeleteManyAsync(expr);
		}
		
		public abstract Task<E> RemoveAsync(IClientSessionHandle handle, K id);
		
		public async Task<DeleteResult> RemoveIfAsync(IClientSessionHandle handle, Expression<Func<E, bool>> expr)
		{
			return await _collection.DeleteManyAsync(handle, expr);
		}
		
		#endregion
		
		#region Replace
		
		public abstract E Replace(E entity);
		
		public abstract Task<E> ReplaceAsync(E entity);
		
		public abstract E Replace(IClientSessionHandle handle, E entity);
		
		public abstract Task<E> ReplaceAsync(IClientSessionHandle handle, E entity);
		
		#endregion
		
		#region Read
		
		public IMongoQueryable<E> AsQueryable()
		{
			return _collection.AsQueryable();
		}
		
		public IFindFluent<E, E> Get()
		{
			return _collection.Find(Builders<E>.Filter.Empty);
		}
		
		public IFindFluent<E, E> Get(Expression<Func<E, bool>> expr)
		{
			return _collection.Find(expr);
		}
		
		public async Task<IAsyncCursor<E>> GetAsync()
		{
			return await _collection.FindAsync<E>(Builders<E>.Filter.Empty);
		}
		
		public async Task<IAsyncCursor<E>> GetAsync(Expression<Func<E, bool>> expr)
		{
			return await _collection.FindAsync<E>(expr);
		}
		
		#endregion
		
		/*
		********************** ABSTRACT AREA *********************
		*/
		
		public abstract E FindById(K id);
		public abstract Task<E> FindByIdAsync(K id);
		
	}
}
