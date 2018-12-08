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
	public partial interface IAspNetUserClaimRepository : IBaseRepository<AspNetUserClaim, int>
	{
	}
	
	public partial class AspNetUserClaimRepository : BaseRepository<AspNetUserClaim, int>, IAspNetUserClaimRepository
	{
		public AspNetUserClaimRepository(DbContext context) : base(context)
		{
		}
		
		public AspNetUserClaimRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetUserClaim FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUserClaim FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUserClaim> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AspNetUserClaim> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override AspNetUserClaim Activate(AspNetUserClaim entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserClaim Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserClaim Deactivate(AspNetUserClaim entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserClaim Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetUserClaim> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<AspNetUserClaim> GetActive(Expression<Func<AspNetUserClaim, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
