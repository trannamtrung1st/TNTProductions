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
	public partial interface IUserRepository : IBaseRepository<User, System.Guid>
	{
	}
	
	public partial class UserRepository : BaseRepository<User, System.Guid>, IUserRepository
	{
		public UserRepository(DbContext context) : base(context)
		{
		}
		
		public UserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override User FindById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override User FindActiveById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<User> FindByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<User> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override User Activate(User entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override User Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override User Deactivate(User entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override User Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<User> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<User> GetActive(Expression<Func<User, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
