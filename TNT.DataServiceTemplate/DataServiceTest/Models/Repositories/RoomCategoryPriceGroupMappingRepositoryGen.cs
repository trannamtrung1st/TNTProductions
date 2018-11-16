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
	public partial interface IRoomCategoryPriceGroupMappingRepository : IBaseRepository<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingPK>
	{
	}
	
	public partial class RoomCategoryPriceGroupMappingRepository : BaseRepository<RoomCategoryPriceGroupMapping, RoomCategoryPriceGroupMappingPK>, IRoomCategoryPriceGroupMappingRepository
	{
		public RoomCategoryPriceGroupMappingRepository() : base()
		{
		}
		
		public RoomCategoryPriceGroupMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RoomCategoryPriceGroupMapping Add(RoomCategoryPriceGroupMapping entity)
		{
			
			entity = context.RoomCategoryPriceGroupMappings.Add(entity);
			return entity;
		}
		
		public override RoomCategoryPriceGroupMapping Remove(RoomCategoryPriceGroupMapping entity)
		{
			context.RoomCategoryPriceGroupMappings.Attach(entity);
			entity = context.RoomCategoryPriceGroupMappings.Remove(entity);
			return entity;
		}
		
		public override RoomCategoryPriceGroupMapping Remove(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.RoomCategoryPriceGroupMappings.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<RoomCategoryPriceGroupMapping> RemoveIf(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return context.RoomCategoryPriceGroupMappings.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<RoomCategoryPriceGroupMapping> RemoveRange(IEnumerable<RoomCategoryPriceGroupMapping> list)
		{
			return context.RoomCategoryPriceGroupMappings.RemoveRange(list);
		}
		
		public override RoomCategoryPriceGroupMapping FindById(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = context.RoomCategoryPriceGroupMappings.FirstOrDefault(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override RoomCategoryPriceGroupMapping FindActiveById(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = context.RoomCategoryPriceGroupMappings.FirstOrDefault(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FindByIdAsync(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = await context.RoomCategoryPriceGroupMappings.FirstOrDefaultAsync(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FindActiveByIdAsync(RoomCategoryPriceGroupMappingPK key)
		{
			var entity = await context.RoomCategoryPriceGroupMappings.FirstOrDefaultAsync(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
			return entity;
		}
		
		public override RoomCategoryPriceGroupMapping FindByIdInclude<TProperty>(RoomCategoryPriceGroupMappingPK key, params Expression<Func<RoomCategoryPriceGroupMapping, TProperty>>[] members)
		{
			IQueryable<RoomCategoryPriceGroupMapping> dbSet = context.RoomCategoryPriceGroupMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FindByIdIncludeAsync<TProperty>(RoomCategoryPriceGroupMappingPK key, params Expression<Func<RoomCategoryPriceGroupMapping, TProperty>>[] members)
		{
			IQueryable<RoomCategoryPriceGroupMapping> dbSet = context.RoomCategoryPriceGroupMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CategoryID == key.CategoryID && e.PriceGroupID == key.PriceGroupID);
		}
		
		public override RoomCategoryPriceGroupMapping Activate(RoomCategoryPriceGroupMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategoryPriceGroupMapping Activate(RoomCategoryPriceGroupMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategoryPriceGroupMapping Deactivate(RoomCategoryPriceGroupMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override RoomCategoryPriceGroupMapping Deactivate(RoomCategoryPriceGroupMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<RoomCategoryPriceGroupMapping> GetActive()
		{
			return context.RoomCategoryPriceGroupMappings;
		}
		
		public override IQueryable<RoomCategoryPriceGroupMapping> GetActive(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return context.RoomCategoryPriceGroupMappings.Where(expr);
		}
		
		public override RoomCategoryPriceGroupMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override RoomCategoryPriceGroupMapping FirstOrDefault(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> FirstOrDefaultAsync(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override RoomCategoryPriceGroupMapping SingleOrDefault(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<RoomCategoryPriceGroupMapping> SingleOrDefaultAsync(Expression<Func<RoomCategoryPriceGroupMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override RoomCategoryPriceGroupMapping Update(RoomCategoryPriceGroupMapping entity)
		{
			entity = context.RoomCategoryPriceGroupMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
