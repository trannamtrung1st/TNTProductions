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
	public partial interface IReportTrackingRepository : IBaseRepository<ReportTracking, int>
	{
	}
	
	public partial class ReportTrackingRepository : BaseRepository<ReportTracking, int>, IReportTrackingRepository
	{
		public ReportTrackingRepository(DbContext context) : base(context)
		{
		}
		
		public ReportTrackingRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override ReportTracking FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override ReportTracking FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ReportTracking> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<ReportTracking> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override ReportTracking Activate(ReportTracking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ReportTracking Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ReportTracking Deactivate(ReportTracking entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override ReportTracking Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<ReportTracking> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<ReportTracking> GetActive(Expression<Func<ReportTracking, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
