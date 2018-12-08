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
	public partial interface IAttendanceRepository : IBaseRepository<Attendance, int>
	{
	}
	
	public partial class AttendanceRepository : BaseRepository<Attendance, int>, IAttendanceRepository
	{
		public AttendanceRepository(DbContext context) : base(context)
		{
		}
		
		public AttendanceRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Attendance FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Attendance FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Attendance> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Attendance> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Attendance Activate(Attendance entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override Attendance Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override Attendance Deactivate(Attendance entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override Attendance Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<Attendance> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<Attendance> GetActive(Expression<Func<Attendance, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
