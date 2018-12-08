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
	public partial interface ICostRepository : IBaseRepository<Cost, int>
	{
	}
	
	public partial class CostRepository : BaseRepository<Cost, int>, ICostRepository
	{
		public CostRepository(DbContext context) : base(context)
		{
		}
		
		public CostRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Cost FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CostID == key);
			return entity;
		}
		
		public override Cost FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.CostID == key);
			return entity;
		}
		
		public override async Task<Cost> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CostID == key);
			return entity;
		}
		
		public override async Task<Cost> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.CostID == key);
			return entity;
		}
		
		public override Cost Activate(Cost entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Cost Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Cost Deactivate(Cost entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Cost Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Cost> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Cost> GetActive(Expression<Func<Cost, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
