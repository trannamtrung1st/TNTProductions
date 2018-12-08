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
	public partial interface IDateReportRepository : IBaseRepository<DateReport, int>
	{
	}
	
	public partial class DateReportRepository : BaseRepository<DateReport, int>, IDateReportRepository
	{
		public DateReportRepository(DbContext context) : base(context)
		{
		}
		
		public DateReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DateReport FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override DateReport FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateReport> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override async Task<DateReport> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.ID == key);
			return entity;
		}
		
		public override DateReport Activate(DateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateReport Deactivate(DateReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DateReport> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<DateReport> GetActive(Expression<Func<DateReport, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
