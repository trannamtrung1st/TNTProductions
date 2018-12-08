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
		public PriceGroupRepository(DbContext context) : base(context)
		{
		}
		
		public PriceGroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PriceGroup FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override PriceGroup FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override async Task<PriceGroup> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PriceGroupID == key);
			return entity;
		}
		
		public override async Task<PriceGroup> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PriceGroupID == key);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<PriceGroup> GetActive(Expression<Func<PriceGroup, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
