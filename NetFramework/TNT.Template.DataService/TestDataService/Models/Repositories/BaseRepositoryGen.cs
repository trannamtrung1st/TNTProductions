using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TestDataService.Models;
using TNT.IoC.Container;
using TNT.IoC.Attributes;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TestDataService.Models.Repositories
{
	public partial interface IRepository
	{
	}
	public partial interface IBaseRepository<E, K> : IRepository
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
		
		void Reload(E entity);
		E Create(E entity);
		IEnumerable<E> CreateRange(IEnumerable<E> entities);
		E Update(E entity);
		IEnumerable<E> UpdateRange(IEnumerable<E> entities);
		E Update(E entity, Action<E> patchAction);
		void Attach(E entity);
		E Remove(E entity);
		E Remove(K key);
		IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		IEnumerable<E> RemoveRange(IEnumerable<E> list);
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		IQueryable<E> Get();
		IQueryable<E> Get(Expression<Func<E, bool>> expr);
		E FirstOrDefault();
		E FirstOrDefault(Expression<Func<E, bool>> expr);
		Task<E> FirstOrDefaultAsync();
		Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);
		E SingleOrDefault(Expression<Func<E, bool>> expr);
		Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr);
		DbRawSqlQuery<E> SqlQuery(string sql, params object[] parameters);
		DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters);
	}
	
	public abstract partial class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
	{
		protected DbContext context;
		protected DbSet<E> dbSet;
		protected IUnitOfWork uow;
		
		public BaseRepository(IUnitOfWork uow)
		{
			this.uow = uow;
			this.context = uow.Context;
			this.dbSet = context.Set<E>();
		}
		
		public BaseRepository(DbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<E>();
		}
		
		public int SaveChanges()
		{
			return context.SaveChanges();
		}
		
		public async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}
		
		public DbRawSqlQuery<E> SqlQuery(string sql, params object[] parameters)
		{
			return context.Database.SqlQuery<E>(sql, parameters);
		}
		
		public DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters)
		{
			return context.Database.SqlQuery<T>(sql, parameters);
		}
		
		public void Reload(E entity)
		{
			context.Entry(entity).Reload();
		}
		
		public E Create(E entity)
		{
			entity = dbSet.Add(entity);
			return entity;
		}
		
		public IEnumerable<E> CreateRange(IEnumerable<E> entities)
		{
			return dbSet.AddRange(entities);
		}
		
		public E Remove(E entity)
		{
			entity = dbSet.Remove(entity);
			return entity;
		}
		
		public E Remove(K key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = dbSet.Remove(entity);
			return entity;
		}
		
		public IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr)
		{
			return dbSet.RemoveRange(dbSet.Where(expr).ToList());
		}
		
		public IEnumerable<E> RemoveRange(IEnumerable<E> list)
		{
			return dbSet.RemoveRange(list);
		}
		
		public E Update(E entity)
		{
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		
		public IEnumerable<E> UpdateRange(IEnumerable<E> entities)
		{
			foreach (var e in entities)
				context.Entry(e).State = EntityState.Modified;
			return entities;
		}
		
		public E Update(E entity, Action<E> patchAction)
		{
			dbSet.Attach(entity);
			patchAction.Invoke(entity);
			return entity;
		}
		
		public void Attach(E entity)
		{
			dbSet.Attach(entity);
		}
		
		public IQueryable<E> Get()
		{
			return dbSet;
		}
		
		public IQueryable<E> Get(Expression<Func<E, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		
		public E FirstOrDefault()
		{
			return dbSet.FirstOrDefault();
		}
		
		public E FirstOrDefault(Expression<Func<E, bool>> expr)
		{
			return dbSet.FirstOrDefault(expr);
		}
		
		public async Task<E> FirstOrDefaultAsync()
		{
			return await dbSet.FirstOrDefaultAsync();
		}
		
		public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await dbSet.FirstOrDefaultAsync(expr);
		}
		
		public E SingleOrDefault(Expression<Func<E, bool>> expr)
		{
			return dbSet.SingleOrDefault(expr);
		}
		
		public async Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await dbSet.SingleOrDefaultAsync(expr);
		}
		
		/*
		********************* ABSTRACT AREA *********************
		*/
		
		public abstract E FindById(K key);
		public abstract Task<E> FindByIdAsync(K key);
		
	}
}
