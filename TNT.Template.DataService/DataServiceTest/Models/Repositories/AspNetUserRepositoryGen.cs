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
	public partial interface IAspNetUserRepository : IBaseRepository<AspNetUser, string>
	{
	}
	
	public partial class AspNetUserRepository : BaseRepository<AspNetUser, string>, IAspNetUserRepository
	{
		public AspNetUserRepository(DbContext context) : base(context)
		{
		}
		
		public AspNetUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetUser FindById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUser FindActiveById(string key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUser> FindByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUser> FindActiveByIdAsync(string key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUser Activate(AspNetUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUser Activate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUser Deactivate(AspNetUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUser Deactivate(string key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetUser> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<AspNetUser> GetActive(Expression<Func<AspNetUser, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
