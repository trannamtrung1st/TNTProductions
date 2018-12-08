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
	public partial interface IPriceAdditionRepository : IBaseRepository<PriceAddition, int>
	{
	}
	
	public partial class PriceAdditionRepository : BaseRepository<PriceAddition, int>, IPriceAdditionRepository
	{
		public PriceAdditionRepository(DbContext context) : base(context)
		{
		}
		
		public PriceAdditionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PriceAddition FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override PriceAddition FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override async Task<PriceAddition> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override async Task<PriceAddition> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.AdditionPriceID == key);
			return entity;
		}
		
		public override PriceAddition Activate(PriceAddition entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceAddition Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceAddition Deactivate(PriceAddition entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PriceAddition Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PriceAddition> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PriceAddition> GetActive(Expression<Func<PriceAddition, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
