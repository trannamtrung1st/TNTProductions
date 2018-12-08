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
	public partial interface IPosConfigRepository : IBaseRepository<PosConfig, int>
	{
	}
	
	public partial class PosConfigRepository : BaseRepository<PosConfig, int>, IPosConfigRepository
	{
		public PosConfigRepository(DbContext context) : base(context)
		{
		}
		
		public PosConfigRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PosConfig FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PosConfig FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosConfig> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosConfig> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PosConfig Activate(PosConfig entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosConfig Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosConfig Deactivate(PosConfig entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosConfig Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PosConfig> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PosConfig> GetActive(Expression<Func<PosConfig, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
