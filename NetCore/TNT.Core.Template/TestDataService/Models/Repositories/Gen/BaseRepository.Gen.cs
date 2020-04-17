using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TestDataService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TestDataService.Models.Repositories
{
	public partial interface IRepository
	{
	}
	public partial interface IBaseRepository<E, K> : IRepository where E : class
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
		
		void Reload(E entity);
		EntityEntry<E> Create(E entity);
		void CreateRange(IEnumerable<E> entities);
		EntityEntry<E> Update(E entity);
		void UpdateRange(IEnumerable<E> entities);
		EntityEntry<E> Update(E entity, Action<E> patchAction);
		EntityEntry<E> Attach(E entity);
		EntityEntry<E> Remove(E entity);
		EntityEntry<E> Remove(K key);
		IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		void RemoveRange(IEnumerable<E> list);
		Task<int> SqlRemoveAllAsync();
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		IQueryable<E> AsNoTracking();
		IQueryable<E> Get();
		IQueryable<E> Get(Expression<Func<E, bool>> expr);
		E FirstOrDefault();
		E FirstOrDefault(Expression<Func<E, bool>> expr);
		Task<E> FirstOrDefaultAsync();
		Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr);
		E SingleOrDefault(Expression<Func<E, bool>> expr);
		Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr);
	}
	
	public abstract partial class BaseRepository<E, K> : IBaseRepository<E, K> where E : class
	{
		protected readonly DbContext context;
		protected readonly DbSet<E> dbSet;
		protected virtual IQueryable<E> QuerySet { get { return dbSet; } }
		
		public BaseRepository(DbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<E>();
			Init();
		}
		
		protected virtual void Init()
		{
		}
		
		public virtual int SaveChanges()
		{
			return context.SaveChanges();
		}
		
		public virtual async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}
		
		public virtual void Reload(E entity)
		{
			context.Entry(entity).Reload();
		}
		
		public virtual EntityEntry<E> Create(E entity)
		{
			return dbSet.Add(entity);
		}
		
		public virtual void CreateRange(IEnumerable<E> entities)
		{
			dbSet.AddRange(entities);
		}
		
		public virtual EntityEntry<E> Remove(E entity)
		{
			return dbSet.Remove(entity);
		}
		
		public virtual void RemoveRange(IEnumerable<E> list)
		{
			dbSet.RemoveRange(list);
		}
		
		public virtual EntityEntry<E> Update(E entity)
		{
			var entry = context.Entry(entity);
			entry.State = EntityState.Modified;
			return entry;
		}
		
		public virtual void UpdateRange(IEnumerable<E> entities)
		{
			foreach (var e in entities)
				context.Entry(e).State = EntityState.Modified;
		}
		
		public virtual EntityEntry<E> Update(E entity, Action<E> patchAction)
		{
			var entry = dbSet.Attach(entity);
			patchAction.Invoke(entity);
			return entry;
		}
		
		public virtual EntityEntry<E> Attach(E entity)
		{
			return dbSet.Attach(entity);
		}
		
		public virtual IQueryable<E> AsNoTracking()
		{
			return QuerySet.AsNoTracking();
		}
		
		public virtual IQueryable<E> Get()
		{
			return QuerySet;
		}
		
		public virtual IQueryable<E> Get(Expression<Func<E, bool>> expr)
		{
			return QuerySet.Where(expr);
		}
		
		public virtual E FirstOrDefault()
		{
			return QuerySet.FirstOrDefault();
		}
		
		public virtual E FirstOrDefault(Expression<Func<E, bool>> expr)
		{
			return QuerySet.FirstOrDefault(expr);
		}
		
		public virtual async Task<E> FirstOrDefaultAsync()
		{
			return await QuerySet.FirstOrDefaultAsync();
		}
		
		public virtual async Task<E> FirstOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await QuerySet.FirstOrDefaultAsync(expr);
		}
		
		public virtual E SingleOrDefault(Expression<Func<E, bool>> expr)
		{
			return QuerySet.SingleOrDefault(expr);
		}
		
		public virtual async Task<E> SingleOrDefaultAsync(Expression<Func<E, bool>> expr)
		{
			return await QuerySet.SingleOrDefaultAsync(expr);
		}
		
		/*
		********************* ABSTRACT AREA *********************
		*/
		
		public abstract E FindById(K key);
		public abstract Task<E> FindByIdAsync(K key);
		public abstract EntityEntry<E> Remove(K key);
		public abstract IEnumerable<E> RemoveIf(Expression<Func<E, bool>> expr);
		public abstract Task<int> SqlRemoveAllAsync();
		
	}
}
