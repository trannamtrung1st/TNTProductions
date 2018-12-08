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
	public partial interface IPosRepository : IBaseRepository<Pos, int>
	{
	}
	
	public partial class PosRepository : BaseRepository<Pos, int>, IPosRepository
	{
		public PosRepository(DbContext context) : base(context)
		{
		}
		
		public PosRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Pos FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PosId == key);
			return entity;
		}
		
		public override Pos FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.PosId == key);
			return entity;
		}
		
		public override async Task<Pos> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PosId == key);
			return entity;
		}
		
		public override async Task<Pos> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.PosId == key);
			return entity;
		}
		
		public override Pos Activate(Pos entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Pos Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Pos Deactivate(Pos entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Pos Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Pos> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Pos> GetActive(Expression<Func<Pos, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
