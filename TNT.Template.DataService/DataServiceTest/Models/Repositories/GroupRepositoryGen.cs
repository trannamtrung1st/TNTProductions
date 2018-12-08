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
	public partial interface IGroupRepository : IBaseRepository<Group, int>
	{
	}
	
	public partial class GroupRepository : BaseRepository<Group, int>, IGroupRepository
	{
		public GroupRepository(DbContext context) : base(context)
		{
		}
		
		public GroupRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Group FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.GroupId == key);
			return entity;
		}
		
		public override Group FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.GroupId == key);
			return entity;
		}
		
		public override async Task<Group> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.GroupId == key);
			return entity;
		}
		
		public override async Task<Group> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.GroupId == key);
			return entity;
		}
		
		public override Group Activate(Group entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Group Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Group Deactivate(Group entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Group Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Group> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<Group> GetActive(Expression<Func<Group, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
