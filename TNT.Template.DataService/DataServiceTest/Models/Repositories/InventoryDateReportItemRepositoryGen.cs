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
	public partial interface IInventoryDateReportItemRepository : IBaseRepository<InventoryDateReportItem, InventoryDateReportItemPK>
	{
	}
	
	public partial class InventoryDateReportItemRepository : BaseRepository<InventoryDateReportItem, InventoryDateReportItemPK>, IInventoryDateReportItemRepository
	{
		public InventoryDateReportItemRepository() : base()
		{
		}
		
		public InventoryDateReportItemRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryDateReportItem Add(InventoryDateReportItem entity)
		{
			
			entity = context.InventoryDateReportItems.Add(entity);
			return entity;
		}
		
		public override InventoryDateReportItem Remove(InventoryDateReportItem entity)
		{
			context.InventoryDateReportItems.Attach(entity);
			entity = context.InventoryDateReportItems.Remove(entity);
			return entity;
		}
		
		public override InventoryDateReportItem Remove(InventoryDateReportItemPK key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.InventoryDateReportItems.Remove(entity);
			return entity;
		}
		
		public override IEnumerable<InventoryDateReportItem> RemoveIf(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return context.InventoryDateReportItems.RemoveRange(GetActive(expr).ToList());
		}
		
		public override IEnumerable<InventoryDateReportItem> RemoveRange(IEnumerable<InventoryDateReportItem> list)
		{
			return context.InventoryDateReportItems.RemoveRange(list);
		}
		
		public override InventoryDateReportItem FindById(InventoryDateReportItemPK key)
		{
			var entity = context.InventoryDateReportItems.FirstOrDefault(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override InventoryDateReportItem FindActiveById(InventoryDateReportItemPK key)
		{
			var entity = context.InventoryDateReportItems.FirstOrDefault(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override async Task<InventoryDateReportItem> FindByIdAsync(InventoryDateReportItemPK key)
		{
			var entity = await context.InventoryDateReportItems.FirstOrDefaultAsync(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override async Task<InventoryDateReportItem> FindActiveByIdAsync(InventoryDateReportItemPK key)
		{
			var entity = await context.InventoryDateReportItems.FirstOrDefaultAsync(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
			return entity;
		}
		
		public override InventoryDateReportItem FindByIdInclude<TProperty>(InventoryDateReportItemPK key, params Expression<Func<InventoryDateReportItem, TProperty>>[] members)
		{
			IQueryable<InventoryDateReportItem> dbSet = context.InventoryDateReportItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
		}
		
		public override async Task<InventoryDateReportItem> FindByIdIncludeAsync<TProperty>(InventoryDateReportItemPK key, params Expression<Func<InventoryDateReportItem, TProperty>>[] members)
		{
			IQueryable<InventoryDateReportItem> dbSet = context.InventoryDateReportItems;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.ItemID == key.ItemID && e.ReportID == key.ReportID);
		}
		
		public override InventoryDateReportItem Activate(InventoryDateReportItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReportItem Activate(InventoryDateReportItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReportItem Deactivate(InventoryDateReportItem entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override InventoryDateReportItem Deactivate(InventoryDateReportItemPK key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<InventoryDateReportItem> GetActive()
		{
			return context.InventoryDateReportItems;
		}
		
		public override IQueryable<InventoryDateReportItem> GetActive(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return context.InventoryDateReportItems.Where(expr);
		}
		
		public override InventoryDateReportItem FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override InventoryDateReportItem FirstOrDefault(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<InventoryDateReportItem> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<InventoryDateReportItem> FirstOrDefaultAsync(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override InventoryDateReportItem SingleOrDefault(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<InventoryDateReportItem> SingleOrDefaultAsync(Expression<Func<InventoryDateReportItem, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override InventoryDateReportItem Update(InventoryDateReportItem entity)
		{
			entity = context.InventoryDateReportItems.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			return entity;
		}
		#endregion
		
	}
}
