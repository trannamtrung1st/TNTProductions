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
	public partial interface IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository : IBaseRepository<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, System.Guid>
	{
	}
	
	public partial class C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository : BaseRepository<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, System.Guid>, IC_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository
	{
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository(DbContext context) : base(context)
		{
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FindById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FindActiveById(System.Guid key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FindByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Activate(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Activate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Deactivate(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Deactivate(System.Guid key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> GetActive(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
