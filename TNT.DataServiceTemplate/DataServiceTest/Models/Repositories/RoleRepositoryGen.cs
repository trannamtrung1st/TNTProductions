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
		public RoleRepository() : base()
		{
		}
		
		public RoleRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Role Add(Role entity)
		{
			
			entity = context.Roles.Add(entity);
			return entity;
		}
		
		public override Role Remove(Role entity)
		{
			context.Roles.Attach(entity);
			entity = context.Roles.Remove(entity);
			return entity;
		}
		
		public override Role Remove(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Roles.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<Role> RemoveIf(Expression<Func<Role, bool>> expr)
		{
			return context.Roles.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<Role> RemoveRange(IEnumerable<Role> list)
		{
			return context.Roles.RemoveRange(list);
		}
		
		public override Role FindById(System.Guid key)
		{
			var entity = context.Roles.FirstOrDefault(
				e => e.RoleId == key);
			return entity;
		}
		
		public override Role FindActiveById(System.Guid key)
		{
			var entity = context.Roles.FirstOrDefault(
				e => e.RoleId == key);
			return entity;
		}
		
		public override async Task<Role> FindByIdAsync(System.Guid key)
		{
			var entity = await context.Roles.FirstOrDefaultAsync(
				e => e.RoleId == key);
			return entity;
		}
		
		public override async Task<Role> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await context.Roles.FirstOrDefaultAsync(
				e => e.RoleId == key);
			return entity;
		}
		
		public override Role FindByIdInclude<TProperty>(System.Guid key, params Expression<Func<Role, TProperty>>[] members)
		{
			IQueryable<Role> dbSet = context.Roles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.RoleId == key);
		}
		
		public override async Task<Role> FindByIdIncludeAsync<TProperty>(System.Guid key, params Expression<Func<Role, TProperty>>[] members)
		{
			IQueryable<Role> dbSet = context.Roles;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.RoleId == key);
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
			return context.Roles;
		}
		
		public override IQueryable<Role> GetActive(Expression<Func<Role, bool>> expr)
		{
			return context.Roles.Where(expr);
		}
		
		public override Role FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Role FirstOrDefault(Expression<Func<Role, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Role> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Role> FirstOrDefaultAsync(Expression<Func<Role, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Role SingleOrDefault(Expression<Func<Role, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Role> SingleOrDefaultAsync(Expression<Func<Role, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Role Update(Role entity)
		{
			entity = context.Roles.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
