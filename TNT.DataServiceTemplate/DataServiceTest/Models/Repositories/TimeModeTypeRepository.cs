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
	public partial interface ITimeModeTypeRepository : IBaseRepository<TimeModeType, int>
	{
	}
	
	public partial class TimeModeTypeRepository : BaseRepository<TimeModeType, int>, ITimeModeTypeRepository
	{
		public TimeModeTypeRepository() : base()
		{
		}
		
		public TimeModeTypeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TimeModeType Add(TimeModeType entity)
		{
			entity.Active = true;
			entity = context.TimeModeTypes.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeType> AddAsync(TimeModeType entity)
		{
			entity.Active = true;
			entity = context.TimeModeTypes.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeModeType Delete(TimeModeType entity)
		{
			context.TimeModeTypes.Attach(entity);
			entity = context.TimeModeTypes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeType> DeleteAsync(TimeModeType entity)
		{
			context.TimeModeTypes.Attach(entity);
			entity = context.TimeModeTypes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeModeType Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TimeModeTypes.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeType> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.TimeModeTypes.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override TimeModeType FindById(int key)
		{
			var entity = context.TimeModeTypes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TimeModeType FindActiveById(int key)
		{
			var entity = context.TimeModeTypes.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<TimeModeType> FindByIdAsync(int key)
		{
			var entity = await context.TimeModeTypes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TimeModeType> FindActiveByIdAsync(int key)
		{
			var entity = await context.TimeModeTypes.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override TimeModeType FindByIdInclude<TProperty>(int key, params Expression<Func<TimeModeType, TProperty>>[] members)
		{
			IQueryable<TimeModeType> dbSet = context.TimeModeTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<TimeModeType> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<TimeModeType, TProperty>>[] members)
		{
			IQueryable<TimeModeType> dbSet = context.TimeModeTypes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override TimeModeType Activate(TimeModeType entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override TimeModeType Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override TimeModeType Deactivate(TimeModeType entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override TimeModeType Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<TimeModeType> GetActive()
		{
			return context.TimeModeTypes.Where(e => e.Active);
		}
		
		public override IQueryable<TimeModeType> GetActive(Expression<Func<TimeModeType, bool>> expr)
		{
			return context.TimeModeTypes.Where(e => e.Active).Where(expr);
		}
		
		public override TimeModeType FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override TimeModeType FirstOrDefault(Expression<Func<TimeModeType, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<TimeModeType> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<TimeModeType> FirstOrDefaultAsync(Expression<Func<TimeModeType, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override TimeModeType SingleOrDefault(Expression<Func<TimeModeType, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<TimeModeType> SingleOrDefaultAsync(Expression<Func<TimeModeType, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override TimeModeType Update(TimeModeType entity)
		{
			entity = context.TimeModeTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<TimeModeType> UpdateAsync(TimeModeType entity)
		{
			entity = context.TimeModeTypes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
