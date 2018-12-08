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
	public partial interface ITemplateReportProductItemMappingRepository : IBaseRepository<TemplateReportProductItemMapping, int>
	{
	}
	
	public partial class TemplateReportProductItemMappingRepository : BaseRepository<TemplateReportProductItemMapping, int>, ITemplateReportProductItemMappingRepository
	{
		public TemplateReportProductItemMappingRepository(DbContext context) : base(context)
		{
		}
		
		public TemplateReportProductItemMappingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override TemplateReportProductItemMapping FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateReportProductItemMapping FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<TemplateReportProductItemMapping> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override TemplateReportProductItemMapping Activate(TemplateReportProductItemMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TemplateReportProductItemMapping Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TemplateReportProductItemMapping Deactivate(TemplateReportProductItemMapping entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override TemplateReportProductItemMapping Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<TemplateReportProductItemMapping> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<TemplateReportProductItemMapping> GetActive(Expression<Func<TemplateReportProductItemMapping, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
