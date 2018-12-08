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
		public StoreGroupRepository(DbContext context) : base(context)
		{
		}
		
		public StoreGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreGroup FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.GroupID == key);
			return entity;
		}
		
		public override StoreGroup FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.GroupID == key);
			return entity;
		}
		
		public override async Task<StoreGroup> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.GroupID == key);
			return entity;
		}
		
		public override async Task<StoreGroup> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.GroupID == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<StoreGroup> GetActive(Expression<Func<StoreGroup, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
