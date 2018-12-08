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
		public C__MigrationHistoryRepository(DbContext context) : base(context)
		{
		}
		
		public C__MigrationHistoryRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override C__MigrationHistory FindById(C__MigrationHistoryPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override C__MigrationHistory FindActiveById(C__MigrationHistoryPK key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override async Task<C__MigrationHistory> FindByIdAsync(C__MigrationHistoryPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
		}
		
		public override async Task<C__MigrationHistory> FindActiveByIdAsync(C__MigrationHistoryPK key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.MigrationId == key.MigrationId && e.ContextKey == key.ContextKey);
			return entity;
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
			return dbSet;
		}
		
		public override IQueryable<C__MigrationHistory> GetActive(Expression<Func<C__MigrationHistory, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
