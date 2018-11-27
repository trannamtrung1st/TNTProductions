using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceTest.Models;
using DataServiceTest.Managers;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataServiceTest.Models.Repositories
{
	public partial interface ILanguageKeyRepository : IBaseRepository<LanguageKey, int>
	{
	}
	
	public partial class LanguageKeyRepository : BaseRepository<LanguageKey, int>, ILanguageKeyRepository
	{
		public LanguageKeyRepository() : base()
		{
		}
		
		public LanguageKeyRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override LanguageKey Add(LanguageKey entity)
		{
			entity.Active = true;
			entity = context.LanguageKeys.Add(entity);
			return entity;
		}
		
		public override LanguageKey Remove(LanguageKey entity)
		{
			context.LanguageKeys.Attach(entity);
			entity = context.LanguageKeys.Remove(entity);
			return entity;
		}
		
		public override LanguageKey Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.LanguageKeys.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<LanguageKey> RemoveIf(Expression<Func<LanguageKey, bool>> expr)
		{
			return context.LanguageKeys.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<LanguageKey> RemoveRange(IEnumerable<LanguageKey> list)
		{
			return context.LanguageKeys.RemoveRange(list);
		}
		
		public override LanguageKey FindById(int key)
		{
			var entity = context.LanguageKeys.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override LanguageKey FindActiveById(int key)
		{
			var entity = context.LanguageKeys.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<LanguageKey> FindByIdAsync(int key)
		{
			var entity = await context.LanguageKeys.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<LanguageKey> FindActiveByIdAsync(int key)
		{
			var entity = await context.LanguageKeys.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override LanguageKey FindByIdInclude<TProperty>(int key, params Expression<Func<LanguageKey, TProperty>>[] members)
		{
			IQueryable<LanguageKey> dbSet = context.LanguageKeys;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<LanguageKey> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<LanguageKey, TProperty>>[] members)
		{
			IQueryable<LanguageKey> dbSet = context.LanguageKeys;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override LanguageKey Activate(LanguageKey entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override LanguageKey Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override LanguageKey Deactivate(LanguageKey entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override LanguageKey Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<LanguageKey> GetActive()
		{
			return context.LanguageKeys.Where(e => e.Active);
		}
		
		public override IQueryable<LanguageKey> GetActive(Expression<Func<LanguageKey, bool>> expr)
		{
			return context.LanguageKeys.Where(e => e.Active).Where(expr);
		}
		
		public override LanguageKey FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override LanguageKey FirstOrDefault(Expression<Func<LanguageKey, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<LanguageKey> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<LanguageKey> FirstOrDefaultAsync(Expression<Func<LanguageKey, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override LanguageKey SingleOrDefault(Expression<Func<LanguageKey, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<LanguageKey> SingleOrDefaultAsync(Expression<Func<LanguageKey, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override LanguageKey Update(LanguageKey entity)
		{
			entity = context.LanguageKeys.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
