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
	public partial interface IInventoryTemplateReportRepository : IBaseRepository<InventoryTemplateReport, int>
	{
	}
	
	public partial class InventoryTemplateReportRepository : BaseRepository<InventoryTemplateReport, int>, IInventoryTemplateReportRepository
	{
		public InventoryTemplateReportRepository(DbContext context) : base(context)
		{
		}
		
		public InventoryTemplateReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override InventoryTemplateReport FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override InventoryTemplateReport FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<InventoryTemplateReport> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override InventoryTemplateReport Activate(InventoryTemplateReport entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override InventoryTemplateReport Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override InventoryTemplateReport Deactivate(InventoryTemplateReport entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override InventoryTemplateReport Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<InventoryTemplateReport> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<InventoryTemplateReport> GetActive(Expression<Func<InventoryTemplateReport, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
