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
	public partial interface IDateHotelReportRepository : IBaseRepository<DateHotelReport, int>
	{
	}
	
	public partial class DateHotelReportRepository : BaseRepository<DateHotelReport, int>, IDateHotelReportRepository
	{
		public DateHotelReportRepository(DbContext context) : base(context)
		{
		}
		
		public DateHotelReportRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override DateHotelReport FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override DateHotelReport FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DateHotelReport> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<DateHotelReport> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override DateHotelReport Activate(DateHotelReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateHotelReport Activate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateHotelReport Deactivate(DateHotelReport entity)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override DateHotelReport Deactivate(int key)
		{
			throw new Exception("Entity's not activable. Check if table has 'Active/Deactive' column");
		}
		
		public override IQueryable<DateHotelReport> GetActive()
		{
			return dbSet;
		}
		
		public override IQueryable<DateHotelReport> GetActive(Expression<Func<DateHotelReport, bool>> expr)
		{
			return dbSet.Where(expr);
		}
		#endregion
		
	}
}
