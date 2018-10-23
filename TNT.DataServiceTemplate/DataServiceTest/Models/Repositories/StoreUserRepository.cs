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
	public partial interface IStoreUserRepository : IBaseRepository<StoreUser, StoreUserPK>
	{
	}
	
	public partial class StoreUserRepository : BaseRepository<StoreUser, StoreUserPK>, IStoreUserRepository
	{
		public StoreUserRepository() : base()
		{
		}
		
		public StoreUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override StoreUser Add(StoreUser entity)
		{
			
			entity = context.StoreUsers.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreUser> AddAsync(StoreUser entity)
		{
			
			entity = context.StoreUsers.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreUser Delete(StoreUser entity)
		{
			context.StoreUsers.Attach(entity);
			entity = context.StoreUsers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreUser> DeleteAsync(StoreUser entity)
		{
			context.StoreUsers.Attach(entity);
			entity = context.StoreUsers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreUser Delete(StoreUserPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreUsers.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreUser> DeleteAsync(StoreUserPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.StoreUsers.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override StoreUser FindById(StoreUserPK key)
		{
			var entity = context.StoreUsers.FirstOrDefault(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override StoreUser FindActiveById(StoreUserPK key)
		{
			var entity = context.StoreUsers.FirstOrDefault(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override async Task<StoreUser> FindByIdAsync(StoreUserPK key)
		{
			var entity = await context.StoreUsers.FirstOrDefaultAsync(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override async Task<StoreUser> FindActiveByIdAsync(StoreUserPK key)
		{
			var entity = await context.StoreUsers.FirstOrDefaultAsync(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
			return entity;
		}
		
		public override StoreUser FindByIdInclude<TProperty>(StoreUserPK key, params Expression<Func<StoreUser, TProperty>>[] members)
		{
			IQueryable<StoreUser> dbSet = context.StoreUsers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
		}
		
		public override async Task<StoreUser> FindByIdIncludeAsync<TProperty>(StoreUserPK key, params Expression<Func<StoreUser, TProperty>>[] members)
		{
			IQueryable<StoreUser> dbSet = context.StoreUsers;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Username == key.Username && e.StoreId == key.StoreId);
		}
		
		public override StoreUser Activate(StoreUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreUser Activate(StoreUserPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreUser Deactivate(StoreUser entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override StoreUser Deactivate(StoreUserPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<StoreUser> GetActive()
		{
			return context.StoreUsers;
		}
		
		public override IQueryable<StoreUser> GetActive(Expression<Func<StoreUser, bool>> expr)
		{
			return context.StoreUsers.Where(expr);
		}
		
		public override StoreUser FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override StoreUser FirstOrDefault(Expression<Func<StoreUser, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<StoreUser> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<StoreUser> FirstOrDefaultAsync(Expression<Func<StoreUser, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override StoreUser SingleOrDefault(Expression<Func<StoreUser, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<StoreUser> SingleOrDefaultAsync(Expression<Func<StoreUser, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override StoreUser Update(StoreUser entity)
		{
			entity = context.StoreUsers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<StoreUser> UpdateAsync(StoreUser entity)
		{
			entity = context.StoreUsers.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
