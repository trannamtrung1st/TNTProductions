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
	public partial interface IDayModeRepository : IBaseRepository<DayMode, int>
	{
	}
	
	public partial class DayModeRepository : BaseRepository<DayMode, int>, IDayModeRepository
	{
		public DayModeRepository() : base()
		{
		}
		
		public DayModeRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DayMode Add(DayMode entity)
		{
			entity.Active = true;
			entity = context.DayModes.Add(entity);
			return entity;
		}
		
		public override DayMode Remove(DayMode entity)
		{
			context.DayModes.Attach(entity);
			entity = context.DayModes.Remove(entity);
			return entity;
		}
		
		public override DayMode Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.DayModes.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<DayMode> RemoveIf(Expression<Func<DayMode, bool>> expr)
		{
			return context.DayModes.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<DayMode> RemoveRange(IEnumerable<DayMode> list)
		{
			return context.DayModes.RemoveRange(list);
		}
		
		public override DayMode FindById(int key)
		{
			var entity = context.DayModes.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override DayMode FindActiveById(int key)
		{
			var entity = context.DayModes.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<DayMode> FindByIdAsync(int key)
		{
			var entity = await context.DayModes.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DayMode> FindActiveByIdAsync(int key)
		{
			var entity = await context.DayModes.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override DayMode FindByIdInclude<TProperty>(int key, params Expression<Func<DayMode, TProperty>>[] members)
		{
			IQueryable<DayMode> dbSet = context.DayModes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<DayMode> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<DayMode, TProperty>>[] members)
		{
			IQueryable<DayMode> dbSet = context.DayModes;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override DayMode Activate(DayMode entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override DayMode Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override DayMode Deactivate(DayMode entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override DayMode Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<DayMode> GetActive()
		{
			return context.DayModes.Where(e => e.Active);
		}
		
		public override IQueryable<DayMode> GetActive(Expression<Func<DayMode, bool>> expr)
		{
			return context.DayModes.Where(e => e.Active).Where(expr);
		}
		
		public override DayMode FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override DayMode FirstOrDefault(Expression<Func<DayMode, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<DayMode> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<DayMode> FirstOrDefaultAsync(Expression<Func<DayMode, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override DayMode SingleOrDefault(Expression<Func<DayMode, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<DayMode> SingleOrDefaultAsync(Expression<Func<DayMode, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override DayMode Update(DayMode entity)
		{
			entity = context.DayModes.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
