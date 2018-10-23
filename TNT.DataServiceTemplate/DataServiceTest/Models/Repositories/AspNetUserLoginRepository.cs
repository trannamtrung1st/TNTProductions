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
		public AspNetUserLoginRepository() : base()
		{
		}
		
		public AspNetUserLoginRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AspNetUserLogin Add(AspNetUserLogin entity)
		{
			
			entity = context.AspNetUserLogins.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetUserLogin> AddAsync(AspNetUserLogin entity)
		{
			
			entity = context.AspNetUserLogins.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AspNetUserLogin Delete(AspNetUserLogin entity)
		{
			context.AspNetUserLogins.Attach(entity);
			entity = context.AspNetUserLogins.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetUserLogin> DeleteAsync(AspNetUserLogin entity)
		{
			context.AspNetUserLogins.Attach(entity);
			entity = context.AspNetUserLogins.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AspNetUserLogin Delete(AspNetUserLoginPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AspNetUserLogins.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetUserLogin> DeleteAsync(AspNetUserLoginPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AspNetUserLogins.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AspNetUserLogin FindById(AspNetUserLoginPK key)
		{
			var entity = context.AspNetUserLogins.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override AspNetUserLogin FindActiveById(AspNetUserLoginPK key)
		{
			var entity = context.AspNetUserLogins.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override async Task<AspNetUserLogin> FindByIdAsync(AspNetUserLoginPK key)
		{
			var entity = await context.AspNetUserLogins.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override async Task<AspNetUserLogin> FindActiveByIdAsync(AspNetUserLoginPK key)
		{
			var entity = await context.AspNetUserLogins.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
			return entity;
		}
		
		public override AspNetUserLogin FindByIdInclude<TProperty>(AspNetUserLoginPK key, params Expression<Func<AspNetUserLogin, TProperty>>[] members)
		{
			IQueryable<AspNetUserLogin> dbSet = context.AspNetUserLogins;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
		}
		
		public override async Task<AspNetUserLogin> FindByIdIncludeAsync<TProperty>(AspNetUserLoginPK key, params Expression<Func<AspNetUserLogin, TProperty>>[] members)
		{
			IQueryable<AspNetUserLogin> dbSet = context.AspNetUserLogins;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.LoginProvider == key.LoginProvider && e.ProviderKey == key.ProviderKey && e.UserId == key.UserId);
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
			return context.AspNetUserLogins;
		}
		
		public override IQueryable<AspNetUserLogin> GetActive(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return context.AspNetUserLogins.Where(expr);
		}
		
		public override AspNetUserLogin FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AspNetUserLogin FirstOrDefault(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AspNetUserLogin> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AspNetUserLogin> FirstOrDefaultAsync(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AspNetUserLogin SingleOrDefault(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AspNetUserLogin> SingleOrDefaultAsync(Expression<Func<AspNetUserLogin, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AspNetUserLogin Update(AspNetUserLogin entity)
		{
			entity = context.AspNetUserLogins.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AspNetUserLogin> UpdateAsync(AspNetUserLogin entity)
		{
			entity = context.AspNetUserLogins.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
