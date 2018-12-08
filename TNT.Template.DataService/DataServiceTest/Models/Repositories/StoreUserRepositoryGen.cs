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
	public partial interface IStoreUserRepository : IBaseRepository<StoreUser, StoreUserPK>
	{
	}
	
	public partial class StoreUserRepository : BaseRepository<StoreUser, StoreUserPK>, IStoreUserRepository
	{
		public StoreUserRepository(DbContext context) : base(context)
		{
		}
		
		public StoreUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreUser FindById(StoreUserPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override StoreUser FindActiveById(StoreUserPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override async Task<StoreUser> FindByIdAsync(StoreUserPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override async Task<StoreUser> FindActiveByIdAsync(StoreUserPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override StoreUser Activate(StoreUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreUser Activate(StoreUserPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreUser Deactivate(StoreUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreUser Deactivate(StoreUserPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<StoreUser> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<StoreUser> GetActive(Expression<Func<StoreUser, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
