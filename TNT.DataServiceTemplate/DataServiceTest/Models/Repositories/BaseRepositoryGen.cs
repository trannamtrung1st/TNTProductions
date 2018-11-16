using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using TNT.IoContainer.Container;
using System.Data.Entity.Infrastructure;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IRepository: IReusable
	{
	}
	public partial interface IBaseRepository<E, K> : IRepository
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
		
		E Add(E entity);
		E Update(E entity);
		E Remove(E entity);
		E Remove(K key);
		IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		IEnumerable<E> RemoveRange(IEnumerable<E> list);
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		E FindActiveById(K key);
		Task<E> FindActiveByIdAsync(K key);
		E FindByIdInclude<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);
		Task<E> FindByIdIncludeAsync<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);
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
		protected passioTestEntities context;
		
		public BaseRepository(IUnitOfWork uow)
		{
			this.context = uow.Context;
		}
		
		public BaseRepository()
		{
		}
		
		public int SaveChanges()
		{
			return context.SaveChanges();
		}
		
		public async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}
		
		#region SqlQuery
		public DbRawSqlQuery<E> SqlQuery(string sql, params object[] parameters)
		{
			return context.Database.SqlQuery<E>(sql, parameters);
		}
		
		public DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parameters)
		{
			return context.Database.SqlQuery<T>(sql, parameters);
		}
		#endregion
		
		public void ReInit(params object[] initParams)
		{
			//params order: 0/ uow
			context = ((IUnitOfWork)initParams[0]).Context;
		}
		
		/*
		********************* ABSTRACT AREA *********************
		*/
		
		public abstract E Add(E entity);
		public abstract E Update(E entity);
		public abstract E Remove(E entity);
		public abstract E Remove(K key);
		public abstract IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		public abstract IEnumerable<E> RemoveRange(IEnumerable<E> list);
		public abstract E FindById(K key);
		public abstract Task<E> FindByIdAsync(K key);
		public abstract E FindActiveById(K key);
		public abstract Task<E> FindActiveByIdAsync(K key);
		public abstract E FindByIdInclude<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);
		public abstract Task<E> FindByIdIncludeAsync<TProperty>(K key, params Expression<Func<E, TProperty>>[] members);
		public abstract E Activate(E entity);
		public abstract E Activate(K key);
		public abstract E Deactivate(E entity);
		public abstract E Deactivate(K key);
		public abstract IQueryable<E> GetActive();
		public abstract IQueryable<E> GetActive(Expression<Func<E, bool>> expr);
		public abstract E FirstOrDefault();
		public abstract E FirstOrDefault(Expression<Func<E, bool>> expr);
		public abstract Task<E> FirstOrDefaultAsync();
		public abstract Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);
		public abstract E SingleOrDefault(Expression<Func<E, bool>> expr);
		public abstract Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr);
		
	}
}
