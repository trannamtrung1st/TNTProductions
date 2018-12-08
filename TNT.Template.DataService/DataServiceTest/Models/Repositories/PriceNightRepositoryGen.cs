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
	public partial interface IPriceNightRepository : IBaseRepository<PriceNight, int>
	{
	}
	
	public partial class PriceNightRepository : BaseRepository<PriceNight, int>, IPriceNightRepository
	{
		public PriceNightRepository(DbContext context) : base(context)
		{
		}
		
		public PriceNightRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PriceNight FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override PriceNight FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override async Task<PriceNight> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override async Task<PriceNight> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RoomPriceID == key);
			return entity;
		}
		
		public override PriceNight Activate(PriceNight entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceNight Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceNight Deactivate(PriceNight entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceNight Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PriceNight> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PriceNight> GetActive(Expression<Func<PriceNight, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
