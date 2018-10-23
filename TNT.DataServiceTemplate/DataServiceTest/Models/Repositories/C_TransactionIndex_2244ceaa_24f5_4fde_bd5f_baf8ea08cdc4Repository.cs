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
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository() : base()
		{
		}
		
		public C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4Repository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Add(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			
			entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> AddAsync(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			
			entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Delete(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Attach(entity);
			entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> DeleteAsync(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Attach(entity);
			entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Delete(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> DeleteAsync(System.Guid key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FindById(System.Guid key)
		{
			var entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FindActiveById(System.Guid key)
		{
			var entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FindByIdAsync(System.Guid key)
		{
			var entity = await context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FindActiveByIdAsync(System.Guid key)
		{
			var entity = await context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FindByIdInclude<TProperty>(System.Guid key, params Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, TProperty>>[] members)
		{
			IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> dbSet = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FindByIdIncludeAsync<TProperty>(System.Guid key, params Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, TProperty>>[] members)
		{
			IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> dbSet = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
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
			return context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4;
		}
		
		public override IQueryable<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> GetActive(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Where(expr);
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 FirstOrDefault(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> FirstOrDefaultAsync(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 SingleOrDefault(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> SingleOrDefaultAsync(Expression<Func<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 Update(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4> UpdateAsync(C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4 entity)
		{
			entity = context.C_TransactionIndex_2244ceaa_24f5_4fde_bd5f_baf8ea08cdc4.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
