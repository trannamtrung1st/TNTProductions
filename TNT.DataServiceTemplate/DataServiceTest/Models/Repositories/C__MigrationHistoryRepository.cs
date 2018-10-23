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
	public partial interface IC__MigrationHistoryRepository : IBaseRepository<C__MigrationHistory, C__MigrationHistoryPK>
	{
	}
	
	public partial class C__MigrationHistoryRepository : BaseRepository<C__MigrationHistory, C__MigrationHistoryPK>, IC__MigrationHistoryRepository
	{
		public C__MigrationHistoryRepository() : base()
		{
		}
		
		public C__MigrationHistoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override C__MigrationHistory Add(C__MigrationHistory entity)
		{
			
			entity = context.C__MigrationHistory.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C__MigrationHistory> AddAsync(C__MigrationHistory entity)
		{
			
			entity = context.C__MigrationHistory.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override C__MigrationHistory Delete(C__MigrationHistory entity)
		{
			context.C__MigrationHistory.Attach(entity);
			entity = context.C__MigrationHistory.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C__MigrationHistory> DeleteAsync(C__MigrationHistory entity)
		{
			context.C__MigrationHistory.Attach(entity);
			entity = context.C__MigrationHistory.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override C__MigrationHistory Delete(C__MigrationHistoryPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.C__MigrationHistory.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C__MigrationHistory> DeleteAsync(C__MigrationHistoryPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.C__MigrationHistory.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override C__MigrationHistory FindById(C__MigrationHistoryPK key)
		{
			var entity = context.C__MigrationHistory.FirstOrDefault(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override C__MigrationHistory FindActiveById(C__MigrationHistoryPK key)
		{
			var entity = context.C__MigrationHistory.FirstOrDefault(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override async Task<C__MigrationHistory> FindByIdAsync(C__MigrationHistoryPK key)
		{
			var entity = await context.C__MigrationHistory.FirstOrDefaultAsync(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override async Task<C__MigrationHistory> FindActiveByIdAsync(C__MigrationHistoryPK key)
		{
			var entity = await context.C__MigrationHistory.FirstOrDefaultAsync(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override C__MigrationHistory FindByIdInclude<TProperty>(C__MigrationHistoryPK key, params Expression<Func<C__MigrationHistory, TProperty>>[] members)
		{
			IQueryable<C__MigrationHistory> dbSet = context.C__MigrationHistory;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
		}
		
		public override async Task<C__MigrationHistory> FindByIdIncludeAsync<TProperty>(C__MigrationHistoryPK key, params Expression<Func<C__MigrationHistory, TProperty>>[] members)
		{
			IQueryable<C__MigrationHistory> dbSet = context.C__MigrationHistory;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
		}
		
		public override C__MigrationHistory Activate(C__MigrationHistory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override C__MigrationHistory Activate(C__MigrationHistoryPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override C__MigrationHistory Deactivate(C__MigrationHistory entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override C__MigrationHistory Deactivate(C__MigrationHistoryPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<C__MigrationHistory> GetActive()
		{
			return context.C__MigrationHistory;
		}
		
		public override IQueryable<C__MigrationHistory> GetActive(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return context.C__MigrationHistory.Where(expr);
		}
		
		public override C__MigrationHistory FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override C__MigrationHistory FirstOrDefault(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<C__MigrationHistory> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<C__MigrationHistory> FirstOrDefaultAsync(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override C__MigrationHistory SingleOrDefault(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<C__MigrationHistory> SingleOrDefaultAsync(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override C__MigrationHistory Update(C__MigrationHistory entity)
		{
			entity = context.C__MigrationHistory.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C__MigrationHistory> UpdateAsync(C__MigrationHistory entity)
		{
			entity = context.C__MigrationHistory.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
