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
	public partial interface IPriceGroupRepository : IBaseRepository<PriceGroup, int>
	{
	}
	
	public partial class PriceGroupRepository : BaseRepository<PriceGroup, int>, IPriceGroupRepository
	{
		public PriceGroupRepository() : base()
		{
		}
		
		public PriceGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PriceGroup Add(PriceGroup entity)
		{
			
			entity = context.PriceGroups.Add(entity);
			return entity;
		}
		
		public override PriceGroup Remove(PriceGroup entity)
		{
			context.PriceGroups.Attach(entity);
			entity = context.PriceGroups.Remove(entity);
			return entity;
		}
		
		public override PriceGroup Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.PriceGroups.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<PriceGroup> RemoveIf(Expression<Func<PriceGroup, bool>> expr)
		{
			return context.PriceGroups.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<PriceGroup> RemoveRange(IEnumerable<PriceGroup> list)
		{
			return context.PriceGroups.RemoveRange(list);
		}
		
		public override PriceGroup FindById(int key)
		{
			var entity = context.PriceGroups.FirstOrDefault(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override PriceGroup FindActiveById(int key)
		{
			var entity = context.PriceGroups.FirstOrDefault(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override async Task<PriceGroup> FindByIdAsync(int key)
		{
			var entity = await context.PriceGroups.FirstOrDefaultAsync(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override async Task<PriceGroup> FindActiveByIdAsync(int key)
		{
			var entity = await context.PriceGroups.FirstOrDefaultAsync(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override PriceGroup FindByIdInclude<TProperty>(int key, params Expression<Func<PriceGroup, TProperty>>[] members)
		{
			IQueryable<PriceGroup> dbSet = context.PriceGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.PriceGroupID == key);
		}
		
		public override async Task<PriceGroup> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<PriceGroup, TProperty>>[] members)
		{
			IQueryable<PriceGroup> dbSet = context.PriceGroups;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.PriceGroupID == key);
		}
		
		public override PriceGroup Activate(PriceGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceGroup Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceGroup Deactivate(PriceGroup entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceGroup Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PriceGroup> GetActive()
		{
			return context.PriceGroups;
		}
		
		public override IQueryable<PriceGroup> GetActive(Expression<Func<PriceGroup, bool>> expr)
		{
			return context.PriceGroups.Where(expr);
		}
		
		public override PriceGroup FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override PriceGroup FirstOrDefault(Expression<Func<PriceGroup, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<PriceGroup> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<PriceGroup> FirstOrDefaultAsync(Expression<Func<PriceGroup, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override PriceGroup SingleOrDefault(Expression<Func<PriceGroup, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<PriceGroup> SingleOrDefaultAsync(Expression<Func<PriceGroup, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override PriceGroup Update(PriceGroup entity)
		{
			entity = context.PriceGroups.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
