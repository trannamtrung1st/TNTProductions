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
	public partial interface ILanguageValueRepository : IBaseRepository<LanguageValue, int>
	{
	}
	
	public partial class LanguageValueRepository : BaseRepository<LanguageValue, int>, ILanguageValueRepository
	{
		public LanguageValueRepository() : base()
		{
		}
		
		public LanguageValueRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override LanguageValue Add(LanguageValue entity)
		{
			entity.Active = true;
			entity = context.LanguageValues.Add(entity);
			return entity;
		}
		
		public override LanguageValue Remove(LanguageValue entity)
		{
			context.LanguageValues.Attach(entity);
			entity = context.LanguageValues.Remove(entity);
			return entity;
		}
		
		public override LanguageValue Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.LanguageValues.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<LanguageValue> RemoveIf(Expression<Func<LanguageValue, bool>> expr)
		{
			return context.LanguageValues.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<LanguageValue> RemoveRange(IEnumerable<LanguageValue> list)
		{
			return context.LanguageValues.RemoveRange(list);
		}
		
		public override LanguageValue FindById(int key)
		{
			var entity = context.LanguageValues.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override LanguageValue FindActiveById(int key)
		{
			var entity = context.LanguageValues.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<LanguageValue> FindByIdAsync(int key)
		{
			var entity = await context.LanguageValues.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<LanguageValue> FindActiveByIdAsync(int key)
		{
			var entity = await context.LanguageValues.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override LanguageValue FindByIdInclude<TProperty>(int key, params Expression<Func<LanguageValue, TProperty>>[] members)
		{
			IQueryable<LanguageValue> dbSet = context.LanguageValues;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<LanguageValue> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<LanguageValue, TProperty>>[] members)
		{
			IQueryable<LanguageValue> dbSet = context.LanguageValues;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override LanguageValue Activate(LanguageValue entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override LanguageValue Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override LanguageValue Deactivate(LanguageValue entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override LanguageValue Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<LanguageValue> GetActive()
		{
			return context.LanguageValues.Where(e => e.Active);
		}
		
		public override IQueryable<LanguageValue> GetActive(Expression<Func<LanguageValue, bool>> expr)
		{
			return context.LanguageValues.Where(e => e.Active).Where(expr);
		}
		
		public override LanguageValue FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override LanguageValue FirstOrDefault(Expression<Func<LanguageValue, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<LanguageValue> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<LanguageValue> FirstOrDefaultAsync(Expression<Func<LanguageValue, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override LanguageValue SingleOrDefault(Expression<Func<LanguageValue, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<LanguageValue> SingleOrDefaultAsync(Expression<Func<LanguageValue, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override LanguageValue Update(LanguageValue entity)
		{
			entity = context.LanguageValues.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
