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
	public partial interface IProfileRepository : IBaseRepository<Profile, System.Guid>
	{
	}
	
	public partial class ProfileRepository : BaseRepository<Profile, System.Guid>, IProfileRepository
	{
		public ProfileRepository(DbContext context) : base(context)
		{
		}
		
		public ProfileRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Profile FindById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override Profile FindActiveById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<Profile> FindByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<Profile> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override Profile Activate(Profile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Profile Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Profile Deactivate(Profile entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Profile Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Profile> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Profile> GetActive(Expression<Func<Profile, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
