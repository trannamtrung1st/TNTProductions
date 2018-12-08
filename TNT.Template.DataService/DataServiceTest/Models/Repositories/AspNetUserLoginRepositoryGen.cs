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
	public partial interface IAspNetUserLoginRepository : IBaseRepository<AspNetUserLogin, AspNetUserLoginPK>
	{
	}
	
	public partial class AspNetUserLoginRepository : BaseRepository<AspNetUserLogin, AspNetUserLoginPK>, IAspNetUserLoginRepository
	{
		public AspNetUserLoginRepository(DbContext context) : base(context)
		{
		}
		
		public AspNetUserLoginRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetUserLogin FindById(AspNetUserLoginPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override AspNetUserLogin FindActiveById(AspNetUserLoginPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override async Task<AspNetUserLogin> FindByIdAsync(AspNetUserLoginPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override async Task<AspNetUserLogin> FindActiveByIdAsync(AspNetUserLoginPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override AspNetUserLogin Activate(AspNetUserLogin entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserLogin Activate(AspNetUserLoginPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserLogin Deactivate(AspNetUserLogin entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override AspNetUserLogin Deactivate(AspNetUserLoginPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<AspNetUserLogin> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<AspNetUserLogin> GetActive(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
