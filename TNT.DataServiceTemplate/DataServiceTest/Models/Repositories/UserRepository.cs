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
		public UserRepository() : base()
		{
		}
		
		public UserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override User Add(User entity)
		{
			
			entity = context.Users.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<User> AddAsync(User entity)
		{
			
			entity = context.Users.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override User Delete(User entity)
		{
			context.Users.Attach(entity);
			entity = context.Users.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<User> DeleteAsync(User entity)
		{
			context.Users.Attach(entity);
			entity = context.Users.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override User Delete(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Users.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<User> DeleteAsync(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Users.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override User FindById(System.Guid key)
		{
			var entity = context.Users.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override User FindActiveById(System.Guid key)
		{
			var entity = context.Users.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<User> FindByIdAsync(System.Guid key)
		{
			var entity = await context.Users.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override async Task<User> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await context.Users.FirstOrDefaultAsync(
				e => e.UserId == key);
			return entity;
		}
		
		public override User FindByIdInclude<TProperty>(System.Guid key, params Expression<Func<User, TProperty>>[] members)
		{
			IQueryable<User> dbSet = context.Users;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.UserId == key);
		}
		
		public override async Task<User> FindByIdIncludeAsync<TProperty>(System.Guid key, params Expression<Func<User, TProperty>>[] members)
		{
			IQueryable<User> dbSet = context.Users;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.UserId == key);
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
			return context.Users;
		}
		
		public override IQueryable<User> GetActive(Expression<Func<User, bool>> expr)
		{
			return context.Users.Where(expr);
		}
		
		public override User FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override User FirstOrDefault(Expression<Func<User, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<User> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override User SingleOrDefault(Expression<Func<User, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<User> SingleOrDefaultAsync(Expression<Func<User, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override User Update(User entity)
		{
			entity = context.Users.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<User> UpdateAsync(User entity)
		{
			entity = context.Users.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
