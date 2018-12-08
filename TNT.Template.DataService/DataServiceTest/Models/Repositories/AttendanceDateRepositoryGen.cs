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
	public partial interface IAttendanceDateRepository : IBaseRepository<AttendanceDate, int>
	{
	}
	
	public partial class AttendanceDateRepository : BaseRepository<AttendanceDate, int>, IAttendanceDateRepository
	{
		public AttendanceDateRepository(DbContext context) : base(context)
		{
		}
		
		public AttendanceDateRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AttendanceDate FindById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AttendanceDate FindActiveById(int key)
		{
			var entity = dbSet.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<AttendanceDate> FindByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AttendanceDate> FindActiveByIdAsync(int key)
		{
			var entity = await dbSet.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override AttendanceDate Activate(AttendanceDate entity)
		{
			entity.Active = true; Update(entity); return entity;
		}
		
		public override AttendanceDate Activate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = true;
				Update(entity);
			}
			return entity;
		}
		
		public override AttendanceDate Deactivate(AttendanceDate entity)
		{
			entity.Active = false; Update(entity); return entity;
		}
		
		public override AttendanceDate Deactivate(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
			{
				entity.Active = false;
				Update(entity);
			}
			return entity;
		}
		
		public override IQueryable<AttendanceDate> GetActive()
		{
			return dbSet.Where(e => e.Active);
		}
		
		public override IQueryable<AttendanceDate> GetActive(Expression<Func<AttendanceDate, bool>> expr)
		{
			return dbSet.Where(e => e.Active).Where(expr);
		}
		#endregion
		
	}
}
