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
	public partial interface IAccountRepository : IBaseRepository<Account, int>
	{
	}
	
	public partial class AccountRepository : BaseRepository<Account, int>, IAccountRepository
	{
		public AccountRepository(DbContext context) : base(context)
		{
		}
		
		public AccountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Account FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.AccountID == key);
			return entity;
		}
		
		public override Account FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.AccountID == key);
			return entity;
		}
		
		public override async Task<Account> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.AccountID == key);
			return entity;
		}
		
		public override async Task<Account> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.AccountID == key);
			return entity;
		}
		
		public override Account Activate(Account entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Account Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Account Deactivate(Account entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Account Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Account> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Account> GetActive(Expression<Func<Account, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
