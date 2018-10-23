using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using TNT.IoContainer.Container;

namespace DataServiceTest.Models.Repositories
{
	public partial interface IRepository: IReusable
	{
	}
	public partial interface IBaseRepository<E, K> : IRepository
	{
		bool AutoSave { get; set; }
		
		E Add(E entity);
		Task<E> AddAsync(E entity);
		E Update(E entity);
		Task < E > UpdateAsync(E entity);
		E Delete(E entity);
		Task<E> DeleteAsync(E entity);
		E Delete(K key);
		Task<E> DeleteAsync(K key);
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
		E SqlQuery(string sql, params object[] parameters);
		Task<E> SqlQueryAsync(string sql, params object[] parameters);
		T SqlQuery<T>(string sql, params object[] parameters);
		Task<T> SqlQueryAsync<T>(string sql, params object[] parameters);
	}
	
	public abstract partial class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
	{
		protected passioTestEntities context;
		public bool AutoSave { get; set; }
		
		public BaseRepository(IUnitOfWork uow)
		{
			this.context = uow.Context;
		}
		
		public BaseRepository()
		{
		}
		
		#region SqlQuery
		public E SqlQuery(string sql, params object[] parameters)
		{
			return context.Database.SqlQuery<E>(sql, parameters).FirstOrDefault();
		}
		
		public async Task<E> SqlQueryAsync(string sql, params object[] parameters)
		{
			return await context.Database.SqlQuery<E>(sql, parameters).FirstOrDefaultAsync();
		}
		
		public T SqlQuery<T>(string sql, params object[] parameters)
		{
			return context.Database.SqlQuery<T>(sql, parameters).FirstOrDefault();
		}
		
		public async Task<T> SqlQueryAsync<T>(string sql, params object[] parameters)
		{
			return await context.Database.SqlQuery<T>(sql, parameters).FirstOrDefaultAsync();
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
		public abstract Task<E> AddAsync(E entity);
		public abstract E Update(E entity);
		public abstract Task<E> UpdateAsync(E entity);
		public abstract E Delete(E entity);
		public abstract Task<E> DeleteAsync(E entity);
		public abstract E Delete(K key);
		public abstract Task<E> DeleteAsync(K key);
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
