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
	public partial interface IPosRepository : IBaseRepository<Pos, int>
	{
	}
	
	public partial class PosRepository : BaseRepository<Pos, int>, IPosRepository
	{
		public PosRepository() : base()
		{
		}
		
		public PosRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Pos Add(Pos entity)
		{
			
			entity = context.Pos.Add(entity);
			return entity;
		}
		
		public override Pos Remove(Pos entity)
		{
			context.Pos.Attach(entity);
			entity = context.Pos.Remove(entity);
			return entity;
		}
		
		public override Pos Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Pos.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Pos> RemoveIf(Expression<Func<Pos, bool>> expr)
		{
			return context.Pos.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Pos> RemoveRange(IEnumerable<Pos> list)
		{
			return context.Pos.RemoveRange(list);
		}
		
		public override Pos FindById(int key)
		{
			var entity = context.Pos.FirstOrDefault(
				e => e.PosId == key);
			return entity;
		}
		
		public override Pos FindActiveById(int key)
		{
			var entity = context.Pos.FirstOrDefault(
				e => e.PosId == key);
			return entity;
		}
		
		public override async Task<Pos> FindByIdAsync(int key)
		{
			var entity = await context.Pos.FirstOrDefaultAsync(
				e => e.PosId == key);
			return entity;
		}
		
		public override async Task<Pos> FindActiveByIdAsync(int key)
		{
			var entity = await context.Pos.FirstOrDefaultAsync(
				e => e.PosId == key);
			return entity;
		}
		
		public override Pos FindByIdInclude<TProperty>(int key, params Expression<Func<Pos, TProperty>>[] members)
		{
			IQueryable<Pos> dbSet = context.Pos;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PosId == key);
		}
		
		public override async Task<Pos> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Pos, TProperty>>[] members)
		{
			IQueryable<Pos> dbSet = context.Pos;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PosId == key);
		}
		
		public override Pos Activate(Pos entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Pos Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Pos Deactivate(Pos entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Pos Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Pos> GetActive()
		{
			return context.Pos;
		}
		
		public override IQueryable<Pos> GetActive(Expression<Func<Pos, bool>> expr)
		{
			return context.Pos.Where(expr);
		}
		
		public override Pos FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Pos FirstOrDefault(Expression<Func<Pos, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Pos> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Pos> FirstOrDefaultAsync(Expression<Func<Pos, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Pos SingleOrDefault(Expression<Func<Pos, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Pos> SingleOrDefaultAsync(Expression<Func<Pos, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Pos Update(Pos entity)
		{
			entity = context.Pos.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
