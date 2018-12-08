using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Promoter.DataService.Models;
using Promoter.DataService.Managers;
using TNT.IoContainer.Container;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Promoter.DataService.Models.Repositories
{
	public partial interface IRepository
	{
	}
	public partial interface IBaseRepository<E, K> : IRepository
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
		
		void Reload(E entity);
		E Add(E entity);
		IEnumerable<E> AddRange(IEnumerable<E> entities);
		E Update(E entity);
		E Remove(E entity);
		E Remove(K key);
		IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		IEnumerable<E> RemoveRange(IEnumerable<E> list);
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		E FindActiveById(K key);
		Task<E> FindActiveByIdAsync(K key);
		E Activate(E entity);
		E Activate(K key);
		E Deactivate(E entity);
		E Deactivate(K key);
		IQueryable<E> GetActive();
		IQueryable<E> GetActive(Expression<Func<E, bool>> expr);
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
		
		public BaseRepository(IUnitOfWork uow)
		{
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
		
		public E Add(E entity)
		{
			entity = dbSet.Add(entity);
			return entity;
		}
		
		public IEnumerable<E> AddRange(IEnumerable<E> entities)
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
			return dbSet.RemoveRange(GetActive(expr).ToList());
		}
		
		public IEnumerable<E> RemoveRange(IEnumerable<E> list)
		{
			return dbSet.RemoveRange(list);
		}
		
		public E Update(E entity)
		{
			entity = dbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		
		public E FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public E FirstOrDefault(Expression<Func<E, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public async Task<E> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public E SingleOrDefault(Expression<Func<E, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public async Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		/*
		********************* ABSTRACT AREA *********************
		*/
		
		public abstract E FindById(K key);
		public abstract Task<E> FindByIdAsync(K key);
		public abstract E FindActiveById(K key);
		public abstract Task<E> FindActiveByIdAsync(K key);
		public abstract E Activate(E entity);
		public abstract E Activate(K key);
		public abstract E Deactivate(E entity);
		public abstract E Deactivate(K key);
		public abstract IQueryable<E> GetActive();
		public abstract IQueryable<E> GetActive(Expression<Func<E, bool>> expr);
		
	}
}
