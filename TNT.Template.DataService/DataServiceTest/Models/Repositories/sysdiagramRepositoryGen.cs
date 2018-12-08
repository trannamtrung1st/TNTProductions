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
	public partial interface IsysdiagramRepository : IBaseRepository<sysdiagram, int>
	{
	}
	
	public partial class sysdiagramRepository : BaseRepository<sysdiagram, int>, IsysdiagramRepository
	{
		public sysdiagramRepository(DbContext context) : base(context)
		{
		}
		
		public sysdiagramRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override sysdiagram FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override sysdiagram FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override async Task<sysdiagram> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override async Task<sysdiagram> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.diagram_id == key);
			return entity;
		}
		
		public override sysdiagram Activate(sysdiagram entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override sysdiagram Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override sysdiagram Deactivate(sysdiagram entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override sysdiagram Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<sysdiagram> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<sysdiagram> GetActive(Expression<Func<sysdiagram, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
