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
	public partial interface IWardRepository : IBaseRepository<Ward, int>
	{
	}
	
	public partial class WardRepository : BaseRepository<Ward, int>, IWardRepository
	{
		public WardRepository(DbContext context) : base(context)
		{
		}
		
		public WardRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Ward FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.WardCode == key);
			return entity;
		}
		
		public override Ward FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.WardCode == key);
			return entity;
		}
		
		public override async Task<Ward> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.WardCode == key);
			return entity;
		}
		
		public override async Task<Ward> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.WardCode == key);
			return entity;
		}
		
		public override Ward Activate(Ward entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Ward Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Ward Deactivate(Ward entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Ward Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Ward> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Ward> GetActive(Expression<Func<Ward, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
