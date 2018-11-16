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
	public partial interface IRoomCategoryRepository : IBaseRepository<RoomCategory, int>
	{
	}
	
	public partial class RoomCategoryRepository : BaseRepository<RoomCategory, int>, IRoomCategoryRepository
	{
		public RoomCategoryRepository() : base()
		{
		}
		
		public RoomCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RoomCategory Add(RoomCategory entity)
		{
			
			entity = context.RoomCategories.Add(entity);
			return entity;
		}
		
		public override RoomCategory Remove(RoomCategory entity)
		{
			context.RoomCategories.Attach(entity);
			entity = context.RoomCategories.Remove(entity);
			return entity;
		}
		
		public override RoomCategory Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RoomCategories.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<RoomCategory> RemoveIf(Expression<Func<RoomCategory, bool>> expr)
		{
			return context.RoomCategories.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<RoomCategory> RemoveRange(IEnumerable<RoomCategory> list)
		{
			return context.RoomCategories.RemoveRange(list);
		}
		
		public override RoomCategory FindById(int key)
		{
			var entity = context.RoomCategories.FirstOrDefault(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override RoomCategory FindActiveById(int key)
		{
			var entity = context.RoomCategories.FirstOrDefault(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override async Task<RoomCategory> FindByIdAsync(int key)
		{
			var entity = await context.RoomCategories.FirstOrDefaultAsync(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override async Task<RoomCategory> FindActiveByIdAsync(int key)
		{
			var entity = await context.RoomCategories.FirstOrDefaultAsync(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override RoomCategory FindByIdInclude<TProperty>(int key, params Expression<Func<RoomCategory, TProperty>>[] members)
		{
			IQueryable<RoomCategory> dbSet = context.RoomCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CategoryID == key);
		}
		
		public override async Task<RoomCategory> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<RoomCategory, TProperty>>[] members)
		{
			IQueryable<RoomCategory> dbSet = context.RoomCategories;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CategoryID == key);
		}
		
		public override RoomCategory Activate(RoomCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategory Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategory Deactivate(RoomCategory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategory Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<RoomCategory> GetActive()
		{
			return context.RoomCategories;
		}
		
		public override IQueryable<RoomCategory> GetActive(Expression<Func<RoomCategory, bool>> expr)
		{
			return context.RoomCategories.Where(expr);
		}
		
		public override RoomCategory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override RoomCategory FirstOrDefault(Expression<Func<RoomCategory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<RoomCategory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<RoomCategory> FirstOrDefaultAsync(Expression<Func<RoomCategory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override RoomCategory SingleOrDefault(Expression<Func<RoomCategory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<RoomCategory> SingleOrDefaultAsync(Expression<Func<RoomCategory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override RoomCategory Update(RoomCategory entity)
		{
			entity = context.RoomCategories.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
