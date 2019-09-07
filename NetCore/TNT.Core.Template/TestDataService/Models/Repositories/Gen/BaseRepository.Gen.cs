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
		void RemoveIf(Expression<Func<E, bool>> expr);
		void RemoveRange(IEnumerable<E> list);
		E FindById(K key);
		Task<E> FindByIdAsync(K key);
		IQueryable<E> AsNoTracking();
		DbSet<E> Get();
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
		
		public void Reload(E entity)
		{
			context.Entry(entity).Reload();
		}
		
		public EntityEntry<E> Create(E entity)
		{
			return dbSet.Add(entity);
		}
		
		public void CreateRange(IEnumerable<E> entities)
		{
			dbSet.AddRange(entities);
		}
		
		public EntityEntry<E> Remove(E entity)
		{
			return dbSet.Remove(entity);
		}
		
		public EntityEntry<E> Remove(K key)
		{
			var entity = FindById(key);
			if (entity!=null)
				return dbSet.Remove(entity);
			return null;
		}
		
		public void RemoveIf(Expression<Func<E, bool>> expr)
		{
			dbSet.RemoveRange(dbSet.Where(expr).ToList());
		}
		
		public void RemoveRange(IEnumerable<E> list)
		{
			dbSet.RemoveRange(list);
		}
		
		public EntityEntry<E> Update(E entity)
		{
			var entry = context.Entry(entity);
			entry.State = EntityState.Modified;
			return entry;
		}
		
		public void UpdateRange(IEnumerable<E> entities)
		{
			foreach (var e in entities)
				context.Entry(e).State = EntityState.Modified;
		}
		
		public EntityEntry<E> Update(E entity, Action<E> patchAction)
		{
			var entry = dbSet.Attach(entity);
			patchAction.Invoke(entity);
			return entry;
		}
		
		public EntityEntry<E> Attach(E entity)
		{
			return dbSet.Attach(entity);
		}
		
		public IQueryable<E> AsNoTracking()
		{
			return dbSet.AsNoTracking();
		}
		
		public DbSet<E> Get()
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
