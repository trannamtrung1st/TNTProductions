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
	public partial interface IsysdiagramRepository : IBaseRepository<sysdiagram, int>
	{
	}
	
	public partial class sysdiagramRepository : BaseRepository<sysdiagram, int>, IsysdiagramRepository
	{
		public sysdiagramRepository() : base()
		{
		}
		
		public sysdiagramRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override sysdiagram Add(sysdiagram entity)
		{
			
			entity = context.sysdiagrams.Add(entity);
			return entity;
		}
		
		public override sysdiagram Remove(sysdiagram entity)
		{
			context.sysdiagrams.Attach(entity);
			entity = context.sysdiagrams.Remove(entity);
			return entity;
		}
		
		public override sysdiagram Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.sysdiagrams.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<sysdiagram> RemoveIf(Expression<Func<sysdiagram, bool>> expr)
		{
			return context.sysdiagrams.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<sysdiagram> RemoveRange(IEnumerable<sysdiagram> list)
		{
			return context.sysdiagrams.RemoveRange(list);
		}
		
		public override sysdiagram FindById(int key)
		{
			var entity = context.sysdiagrams.FirstOrDefault(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override sysdiagram FindActiveById(int key)
		{
			var entity = context.sysdiagrams.FirstOrDefault(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override async Task<sysdiagram> FindByIdAsync(int key)
		{
			var entity = await context.sysdiagrams.FirstOrDefaultAsync(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override async Task<sysdiagram> FindActiveByIdAsync(int key)
		{
			var entity = await context.sysdiagrams.FirstOrDefaultAsync(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override sysdiagram FindByIdInclude<TProperty>(int key, params Expression<Func<sysdiagram, TProperty>>[] members)
		{
			IQueryable<sysdiagram> dbSet = context.sysdiagrams;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.diagram_id == key);
		}
		
		public override async Task<sysdiagram> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<sysdiagram, TProperty>>[] members)
		{
			IQueryable<sysdiagram> dbSet = context.sysdiagrams;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.diagram_id == key);
		}
		
		public override sysdiagram Activate(sysdiagram entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override sysdiagram Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override sysdiagram Deactivate(sysdiagram entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override sysdiagram Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<sysdiagram> GetActive()
		{
			return context.sysdiagrams;
		}
		
		public override IQueryable<sysdiagram> GetActive(Expression<Func<sysdiagram, bool>> expr)
		{
			return context.sysdiagrams.Where(expr);
		}
		
		public override sysdiagram FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override sysdiagram FirstOrDefault(Expression<Func<sysdiagram, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<sysdiagram> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<sysdiagram> FirstOrDefaultAsync(Expression<Func<sysdiagram, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override sysdiagram SingleOrDefault(Expression<Func<sysdiagram, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<sysdiagram> SingleOrDefaultAsync(Expression<Func<sysdiagram, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override sysdiagram Update(sysdiagram entity)
		{
			entity = context.sysdiagrams.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
