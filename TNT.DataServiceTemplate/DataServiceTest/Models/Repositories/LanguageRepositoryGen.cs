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
	public partial interface ILanguageRepository : IBaseRepository<Language, int>
	{
	}
	
	public partial class LanguageRepository : BaseRepository<Language, int>, ILanguageRepository
	{
		public LanguageRepository() : base()
		{
		}
		
		public LanguageRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Language Add(Language entity)
		{
			entity.Active = true;
			entity = context.Languages.Add(entity);
			return entity;
		}
		
		public override Language Remove(Language entity)
		{
			context.Languages.Attach(entity);
			entity = context.Languages.Remove(entity);
			return entity;
		}
		
		public override Language Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Languages.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Language> RemoveIf(Expression<Func<Language, bool>> expr)
		{
			return context.Languages.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Language> RemoveRange(IEnumerable<Language> list)
		{
			return context.Languages.RemoveRange(list);
		}
		
		public override Language FindById(int key)
		{
			var entity = context.Languages.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Language FindActiveById(int key)
		{
			var entity = context.Languages.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Language> FindByIdAsync(int key)
		{
			var entity = await context.Languages.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Language> FindActiveByIdAsync(int key)
		{
			var entity = await context.Languages.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Language FindByIdInclude<TProperty>(int key, params Expression<Func<Language, TProperty>>[] members)
		{
			IQueryable<Language> dbSet = context.Languages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Language> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Language, TProperty>>[] members)
		{
			IQueryable<Language> dbSet = context.Languages;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Language Activate(Language entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Language Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Language Deactivate(Language entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Language Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Language> GetActive()
		{
			return context.Languages.Where(e => e.Active);
		}
		
		public override IQueryable<Language> GetActive(Expression<Func<Language, bool>> expr)
		{
			return context.Languages.Where(e => e.Active).Where(expr);
		}
		
		public override Language FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Language FirstOrDefault(Expression<Func<Language, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Language> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Language> FirstOrDefaultAsync(Expression<Func<Language, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Language SingleOrDefault(Expression<Func<Language, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Language> SingleOrDefaultAsync(Expression<Func<Language, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Language Update(Language entity)
		{
			entity = context.Languages.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
