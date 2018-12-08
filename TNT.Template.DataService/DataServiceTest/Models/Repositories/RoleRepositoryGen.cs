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
	public partial interface IRoleRepository : IBaseRepository<Role, System.Guid>
	{
	}
	
	public partial class RoleRepository : BaseRepository<Role, System.Guid>, IRoleRepository
	{
		public RoleRepository(DbContext context) : base(context)
		{
		}
		
		public RoleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Role FindById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RoleId == key);
			return entity;
		}
		
		public override Role FindActiveById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.RoleId == key);
			return entity;
		}
		
		public override async Task<Role> FindByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RoleId == key);
			return entity;
		}
		
		public override async Task<Role> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.RoleId == key);
			return entity;
		}
		
		public override Role Activate(Role entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Role Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Role Deactivate(Role entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Role Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Role> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Role> GetActive(Expression<Func<Role, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
