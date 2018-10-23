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
	public partial interface ICostInventoryMappingRepository : IBaseRepository<CostInventoryMapping, CostInventoryMappingPK>
	{
	}
	
	public partial class CostInventoryMappingRepository : BaseRepository<CostInventoryMapping, CostInventoryMappingPK>, ICostInventoryMappingRepository
	{
		public CostInventoryMappingRepository() : base()
		{
		}
		
		public CostInventoryMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override CostInventoryMapping Add(CostInventoryMapping entity)
		{
			
			entity = context.CostInventoryMappings.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CostInventoryMapping> AddAsync(CostInventoryMapping entity)
		{
			
			entity = context.CostInventoryMappings.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CostInventoryMapping Delete(CostInventoryMapping entity)
		{
			context.CostInventoryMappings.Attach(entity);
			entity = context.CostInventoryMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CostInventoryMapping> DeleteAsync(CostInventoryMapping entity)
		{
			context.CostInventoryMappings.Attach(entity);
			entity = context.CostInventoryMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CostInventoryMapping Delete(CostInventoryMappingPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CostInventoryMappings.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CostInventoryMapping> DeleteAsync(CostInventoryMappingPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.CostInventoryMappings.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override CostInventoryMapping FindById(CostInventoryMappingPK key)
		{
			var entity = context.CostInventoryMappings.FirstOrDefault(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override CostInventoryMapping FindActiveById(CostInventoryMappingPK key)
		{
			var entity = context.CostInventoryMappings.FirstOrDefault(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override async Task<CostInventoryMapping> FindByIdAsync(CostInventoryMappingPK key)
		{
			var entity = await context.CostInventoryMappings.FirstOrDefaultAsync(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override async Task<CostInventoryMapping> FindActiveByIdAsync(CostInventoryMappingPK key)
		{
			var entity = await context.CostInventoryMappings.FirstOrDefaultAsync(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
			return entity;
		}
		
		public override CostInventoryMapping FindByIdInclude<TProperty>(CostInventoryMappingPK key, params Expression<Func<CostInventoryMapping, TProperty>>[] members)
		{
			IQueryable<CostInventoryMapping> dbSet = context.CostInventoryMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
		}
		
		public override async Task<CostInventoryMapping> FindByIdIncludeAsync<TProperty>(CostInventoryMappingPK key, params Expression<Func<CostInventoryMapping, TProperty>>[] members)
		{
			IQueryable<CostInventoryMapping> dbSet = context.CostInventoryMappings;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.CostID == key.CostID && e.ReceiptID == key.ReceiptID);
		}
		
		public override CostInventoryMapping Activate(CostInventoryMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CostInventoryMapping Activate(CostInventoryMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CostInventoryMapping Deactivate(CostInventoryMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override CostInventoryMapping Deactivate(CostInventoryMappingPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<CostInventoryMapping> GetActive()
		{
			return context.CostInventoryMappings;
		}
		
		public override IQueryable<CostInventoryMapping> GetActive(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return context.CostInventoryMappings.Where(expr);
		}
		
		public override CostInventoryMapping FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override CostInventoryMapping FirstOrDefault(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<CostInventoryMapping> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<CostInventoryMapping> FirstOrDefaultAsync(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override CostInventoryMapping SingleOrDefault(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<CostInventoryMapping> SingleOrDefaultAsync(Expression<Func<CostInventoryMapping, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override CostInventoryMapping Update(CostInventoryMapping entity)
		{
			entity = context.CostInventoryMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<CostInventoryMapping> UpdateAsync(CostInventoryMapping entity)
		{
			entity = context.CostInventoryMappings.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
