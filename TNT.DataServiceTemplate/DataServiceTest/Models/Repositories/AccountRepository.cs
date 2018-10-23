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
		public AccountRepository() : base()
		{
		}
		
		public AccountRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Account Add(Account entity)
		{
			
			entity = context.Accounts.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Account> AddAsync(Account entity)
		{
			
			entity = context.Accounts.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Account Delete(Account entity)
		{
			context.Accounts.Attach(entity);
			entity = context.Accounts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Account> DeleteAsync(Account entity)
		{
			context.Accounts.Attach(entity);
			entity = context.Accounts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Account Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Accounts.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Account> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Accounts.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Account FindById(int key)
		{
			var entity = context.Accounts.FirstOrDefault(
				e => e.AccountID == key);
			return entity;
		}
		
		public override Account FindActiveById(int key)
		{
			var entity = context.Accounts.FirstOrDefault(
				e => e.AccountID == key);
			return entity;
		}
		
		public override async Task<Account> FindByIdAsync(int key)
		{
			var entity = await context.Accounts.FirstOrDefaultAsync(
				e => e.AccountID == key);
			return entity;
		}
		
		public override async Task<Account> FindActiveByIdAsync(int key)
		{
			var entity = await context.Accounts.FirstOrDefaultAsync(
				e => e.AccountID == key);
			return entity;
		}
		
		public override Account FindByIdInclude<TProperty>(int key, params Expression<Func<Account, TProperty>>[] members)
		{
			IQueryable<Account> dbSet = context.Accounts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.AccountID == key);
		}
		
		public override async Task<Account> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Account, TProperty>>[] members)
		{
			IQueryable<Account> dbSet = context.Accounts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.AccountID == key);
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
			return context.Accounts;
		}
		
		public override IQueryable<Account> GetActive(Expression<Func<Account, bool>> expr)
		{
			return context.Accounts.Where(expr);
		}
		
		public override Account FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Account FirstOrDefault(Expression<Func<Account, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Account> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Account> FirstOrDefaultAsync(Expression<Func<Account, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Account SingleOrDefault(Expression<Func<Account, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Account> SingleOrDefaultAsync(Expression<Func<Account, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Account Update(Account entity)
		{
			entity = context.Accounts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Account> UpdateAsync(Account entity)
		{
			entity = context.Accounts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
