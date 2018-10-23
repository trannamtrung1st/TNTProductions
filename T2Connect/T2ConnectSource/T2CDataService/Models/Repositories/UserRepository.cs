using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace T2CDataService.Models.Repositories
{
	public partial interface IUserRepository : IBaseRepository<User, int>
	{
	}
	
	public partial class UserRepository : BaseRepository<User, int>, IUserRepository
	{
		public UserRepository() : base()
		{
		}
		
		public UserRepository(T2CEntities context) : base(context)
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
			entity = context.Users.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<User> DeleteAsync(User entity)
		{
			entity = context.Users.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override User Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Users.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<User> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Users.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override User FindById(int key)
		{
			var entity = context.Users.FirstOrDefault(
				e => e.UserId == key);
			return entity;
		}
		
		public override User FindActiveById(int key)
		{
			var entity = context.Users.FirstOrDefault(
				e => e.UserId == key && !e.Deactive);
			return entity;
		}
		
		public override async Task<User> FindByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Users.FirstOrDefault(
					e => e.UserId == key);
				return entity;
			});
		}
		
		public override async Task<User> FindActiveByIdAsync(int key)
		{
			return await Task.Run(() =>
			{
				var entity = context.Users.FirstOrDefault(
					e => e.UserId == key && !e.Deactive);
				return entity;
			});
		}
		
		public override User FindByIdInclude<TProperty>(int key, params Expression<Func<User, TProperty>>[] members)
		{
			IQueryable<User> dbSet = context.Users;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.UserId == key);
		}
		
		public override async Task<User> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<User, TProperty>>[] members)
		{
			return await Task.Run(() =>
			{
				IQueryable<User> dbSet = context.Users;
				foreach (var m in members)
				{
					dbSet = dbSet.Include(m);
				}
				
				return dbSet.FirstOrDefault(
					e => e.UserId == key);
			});
		}
		
		public override User Activate(User entity)
		{
			entity.Deactive = false; Update(entity); return entity;
		}
		
		public override User Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = false;
				Update(entity);
			}
			return entity;
		}
		
		public override User Deactivate(User entity)
		{
			entity.Deactive = true; Update(entity); return entity;
		}
		
		public override User Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Deactive = true;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<User> GetActive()
		{
			return context.Users.Where(e => !e.Deactive);
		}
		
		public override IQueryable<User> GetActive(Expression<Func<User, bool>> expr)
		{
			return context.Users.Where(e => !e.Deactive).Where(expr);
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
