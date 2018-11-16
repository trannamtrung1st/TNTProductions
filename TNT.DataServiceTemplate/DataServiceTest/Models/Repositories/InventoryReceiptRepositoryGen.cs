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
	public partial interface IInventoryReceiptRepository : IBaseRepository<InventoryReceipt, int>
	{
	}
	
	public partial class InventoryReceiptRepository : BaseRepository<InventoryReceipt, int>, IInventoryReceiptRepository
	{
		public InventoryReceiptRepository() : base()
		{
		}
		
		public InventoryReceiptRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryReceipt Add(InventoryReceipt entity)
		{
			
			entity = context.InventoryReceipts.Add(entity);
			return entity;
		}
		
		public override InventoryReceipt Remove(InventoryReceipt entity)
		{
			context.InventoryReceipts.Attach(entity);
			entity = context.InventoryReceipts.Remove(entity);
			return entity;
		}
		
		public override InventoryReceipt Remove(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryReceipts.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<InventoryReceipt> RemoveIf(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return context.InventoryReceipts.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<InventoryReceipt> RemoveRange(IEnumerable<InventoryReceipt> list)
		{
			return context.InventoryReceipts.RemoveRange(list);
		}
		
		public override InventoryReceipt FindById(int key)
		{
			var entity = context.InventoryReceipts.FirstOrDefault(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override InventoryReceipt FindActiveById(int key)
		{
			var entity = context.InventoryReceipts.FirstOrDefault(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override async Task<InventoryReceipt> FindByIdAsync(int key)
		{
			var entity = await context.InventoryReceipts.FirstOrDefaultAsync(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override async Task<InventoryReceipt> FindActiveByIdAsync(int key)
		{
			var entity = await context.InventoryReceipts.FirstOrDefaultAsync(
				e => e.ReceiptID == key);
			return entity;
		}
		
		public override InventoryReceipt FindByIdInclude<TProperty>(int key, params Expression<Func<InventoryReceipt, TProperty>>[] members)
		{
			IQueryable<InventoryReceipt> dbSet = context.InventoryReceipts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ReceiptID == key);
		}
		
		public override async Task<InventoryReceipt> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<InventoryReceipt, TProperty>>[] members)
		{
			IQueryable<InventoryReceipt> dbSet = context.InventoryReceipts;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ReceiptID == key);
		}
		
		public override InventoryReceipt Activate(InventoryReceipt entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceipt Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceipt Deactivate(InventoryReceipt entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryReceipt Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryReceipt> GetActive()
		{
			return context.InventoryReceipts;
		}
		
		public override IQueryable<InventoryReceipt> GetActive(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return context.InventoryReceipts.Where(expr);
		}
		
		public override InventoryReceipt FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryReceipt FirstOrDefault(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryReceipt> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryReceipt> FirstOrDefaultAsync(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryReceipt SingleOrDefault(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryReceipt> SingleOrDefaultAsync(Expression<Func<InventoryReceipt, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryReceipt Update(InventoryReceipt entity)
		{
			entity = context.InventoryReceipts.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
