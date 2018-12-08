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
	public partial interface IPosFileRepository : IBaseRepository<PosFile, int>
	{
	}
	
	public partial class PosFileRepository : BaseRepository<PosFile, int>, IPosFileRepository
	{
		public PosFileRepository(DbContext context) : base(context)
		{
		}
		
		public PosFileRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override PosFile FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override PosFile FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosFile> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<PosFile> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override PosFile Activate(PosFile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosFile Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosFile Deactivate(PosFile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override PosFile Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<PosFile> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<PosFile> GetActive(Expression<Func<PosFile, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
