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
	public partial interface IInventoryReceiptItemRepository : IBaseRepository<InventoryReceiptItem, InventoryReceiptItemPK>
	{
	}
	
	public partial class InventoryReceiptItemRepository : BaseRepository<InventoryReceiptItem, InventoryReceiptItemPK>, IInventoryReceiptItemRepository
	{
		public InventoryReceiptItemRepository() : base()
		{
		}
		
		public InventoryReceiptItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryReceiptItem Add(InventoryReceiptItem entity)
		{
			
			entity = context.InventoryReceiptItems.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> AddAsync(InventoryReceiptItem entity)
		{
			
			entity = context.InventoryReceiptItems.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryReceiptItem Delete(InventoryReceiptItem entity)
		{
			context.InventoryReceiptItems.Attach(entity);
			entity = context.InventoryReceiptItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> DeleteAsync(InventoryReceiptItem entity)
		{
			context.InventoryReceiptItems.Attach(entity);
			entity = context.InventoryReceiptItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryReceiptItem Delete(InventoryReceiptItemPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryReceiptItems.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> DeleteAsync(InventoryReceiptItemPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryReceiptItems.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override InventoryReceiptItem FindById(InventoryReceiptItemPK key)
		{
			var entity = context.InventoryReceiptItems.FirstOrDefault(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override InventoryReceiptItem FindActiveById(InventoryReceiptItemPK key)
		{
			var entity = context.InventoryReceiptItems.FirstOrDefault(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> FindByIdAsync(InventoryReceiptItemPK key)
		{
			var entity = await context.InventoryReceiptItems.FirstOrDefaultAsync(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> FindActiveByIdAsync(InventoryReceiptItemPK key)
		{
			var entity = await context.InventoryReceiptItems.FirstOrDefaultAsync(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
			return entity;
		}
		
		public override InventoryReceiptItem FindByIdInclude<TProperty>(InventoryReceiptItemPK key, params Expression<Func<InventoryReceiptItem, TProperty>>[] members)
		{
			IQueryable<InventoryReceiptItem> dbSet = context.InventoryReceiptItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
		}
		
		public override async Task<InventoryReceiptItem> FindByIdIncludeAsync<TProperty>(InventoryReceiptItemPK key, params Expression<Func<InventoryReceiptItem, TProperty>>[] members)
		{
			IQueryable<InventoryReceiptItem> dbSet = context.InventoryReceiptItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ReceiptID == key.ReceiptID && e.ItemID == key.ItemID && e.ExportedDate == key.ExportedDate);
		}
		
		public override InventoryReceiptItem Activate(InventoryReceiptItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceiptItem Activate(InventoryReceiptItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceiptItem Deactivate(InventoryReceiptItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceiptItem Deactivate(InventoryReceiptItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryReceiptItem> GetActive()
		{
			return context.InventoryReceiptItems;
		}
		
		public override IQueryable<InventoryReceiptItem> GetActive(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return context.InventoryReceiptItems.Where(expr);
		}
		
		public override InventoryReceiptItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryReceiptItem FirstOrDefault(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryReceiptItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryReceiptItem> FirstOrDefaultAsync(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryReceiptItem SingleOrDefault(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryReceiptItem> SingleOrDefaultAsync(Expression<Func<InventoryReceiptItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryReceiptItem Update(InventoryReceiptItem entity)
		{
			entity = context.InventoryReceiptItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<InventoryReceiptItem> UpdateAsync(InventoryReceiptItem entity)
		{
			entity = context.InventoryReceiptItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
