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
	public partial interface IStoreGroupRepository : IBaseRepository<StoreGroup, int>
	{
	}
	
	public partial class StoreGroupRepository : BaseRepository<StoreGroup, int>, IStoreGroupRepository
	{
		public StoreGroupRepository() : base()
		{
		}
		
		public StoreGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreGroup Add(StoreGroup entity)
		{
			
			entity = context.StoreGroups.Add(entity);
			return entity;
		}
		
		public override StoreGroup Remove(StoreGroup entity)
		{
			context.StoreGroups.Attach(entity);
			entity = context.StoreGroups.Remove(entity);
			return entity;
		}
		
		public override StoreGroup Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreGroups.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<StoreGroup> RemoveIf(Expression<Func<StoreGroup, bool>> expr)
		{
			return context.StoreGroups.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<StoreGroup> RemoveRange(IEnumerable<StoreGroup> list)
		{
			return context.StoreGroups.RemoveRange(list);
		}
		
		public override StoreGroup FindById(int key)
		{
			var entity = context.StoreGroups.FirstOrDefault(
				e => e.GroupID == key);
			return entity;
		}
		
		public override StoreGroup FindActiveById(int key)
		{
			var entity = context.StoreGroups.FirstOrDefault(
				e => e.GroupID == key);
			return entity;
		}
		
		public override async Task<StoreGroup> FindByIdAsync(int key)
		{
			var entity = await context.StoreGroups.FirstOrDefaultAsync(
				e => e.GroupID == key);
			return entity;
		}
		
		public override async Task<StoreGroup> FindActiveByIdAsync(int key)
		{
			var entity = await context.StoreGroups.FirstOrDefaultAsync(
				e => e.GroupID == key);
			return entity;
		}
		
		public override StoreGroup FindByIdInclude<TProperty>(int key, params Expression<Func<StoreGroup, TProperty>>[] members)
		{
			IQueryable<StoreGroup> dbSet = context.StoreGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.GroupID == key);
		}
		
		public override async Task<StoreGroup> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<StoreGroup, TProperty>>[] members)
		{
			IQueryable<StoreGroup> dbSet = context.StoreGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.GroupID == key);
		}
		
		public override StoreGroup Activate(StoreGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreGroup Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreGroup Deactivate(StoreGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreGroup Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<StoreGroup> GetActive()
		{
			return context.StoreGroups;
		}
		
		public override IQueryable<StoreGroup> GetActive(Expression<Func<StoreGroup, bool>> expr)
		{
			return context.StoreGroups.Where(expr);
		}
		
		public override StoreGroup FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreGroup FirstOrDefault(Expression<Func<StoreGroup, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreGroup> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreGroup> FirstOrDefaultAsync(Expression<Func<StoreGroup, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreGroup SingleOrDefault(Expression<Func<StoreGroup, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreGroup> SingleOrDefaultAsync(Expression<Func<StoreGroup, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreGroup Update(StoreGroup entity)
		{
			entity = context.StoreGroups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
