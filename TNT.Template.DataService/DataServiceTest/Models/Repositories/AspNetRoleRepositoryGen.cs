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
	public partial interface IAspNetRoleRepository : IBaseRepository<AspNetRole, string>
	{
	}
	
	public partial class AspNetRoleRepository : BaseRepository<AspNetRole, string>, IAspNetRoleRepository
	{
		public AspNetRoleRepository(DbContext context) : base(context)
		{
		}
		
		public AspNetRoleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetRole FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetRole FindActiveById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRole> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetRole> FindActiveByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetRole Activate(AspNetRole entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetRole Activate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetRole Deactivate(AspNetRole entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetRole Deactivate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetRole> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<AspNetRole> GetActive(Expression<Func<AspNetRole, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
