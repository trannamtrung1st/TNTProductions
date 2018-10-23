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
	public partial interface ITransactionRepository : IBaseRepository<Transaction, int>
	{
	}
	
	public partial class TransactionRepository : BaseRepository<Transaction, int>, ITransactionRepository
	{
		public TransactionRepository() : base()
		{
		}
		
		public TransactionRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Transaction Add(Transaction entity)
		{
			
			entity = context.Transactions.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Transaction> AddAsync(Transaction entity)
		{
			
			entity = context.Transactions.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Transaction Delete(Transaction entity)
		{
			context.Transactions.Attach(entity);
			entity = context.Transactions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Transaction> DeleteAsync(Transaction entity)
		{
			context.Transactions.Attach(entity);
			entity = context.Transactions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Transaction Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Transactions.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Transaction> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Transactions.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Transaction FindById(int key)
		{
			var entity = context.Transactions.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Transaction FindActiveById(int key)
		{
			var entity = context.Transactions.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Transaction> FindByIdAsync(int key)
		{
			var entity = await context.Transactions.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Transaction> FindActiveByIdAsync(int key)
		{
			var entity = await context.Transactions.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override Transaction FindByIdInclude<TProperty>(int key, params Expression<Func<Transaction, TProperty>>[] members)
		{
			IQueryable<Transaction> dbSet = context.Transactions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Transaction> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Transaction, TProperty>>[] members)
		{
			IQueryable<Transaction> dbSet = context.Transactions;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
		}
		
		public override Transaction Activate(Transaction entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Transaction Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Transaction Deactivate(Transaction entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override Transaction Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<Transaction> GetActive()
		{
			return context.Transactions;
		}
		
		public override IQueryable<Transaction> GetActive(Expression<Func<Transaction, bool>> expr)
		{
			return context.Transactions.Where(expr);
		}
		
		public override Transaction FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Transaction FirstOrDefault(Expression<Func<Transaction, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Transaction> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Transaction> FirstOrDefaultAsync(Expression<Func<Transaction, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Transaction SingleOrDefault(Expression<Func<Transaction, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Transaction> SingleOrDefaultAsync(Expression<Func<Transaction, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Transaction Update(Transaction entity)
		{
			entity = context.Transactions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Transaction> UpdateAsync(Transaction entity)
		{
			entity = context.Transactions.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
