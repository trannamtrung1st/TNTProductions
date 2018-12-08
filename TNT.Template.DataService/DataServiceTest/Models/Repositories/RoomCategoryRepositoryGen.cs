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
		public RoomCategoryRepository(DbContext context) : base(context)
		{
		}
		
		public RoomCategoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override RoomCategory FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override RoomCategory FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override async Task<RoomCategory> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CategoryID == key);
			return entity;
		}
		
		public override async Task<RoomCategory> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CategoryID == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<RoomCategory> GetActive(Expression<Func<RoomCategory, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
