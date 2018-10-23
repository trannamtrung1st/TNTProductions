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
		public AttendanceDateRepository() : base()
		{
		}
		
		public AttendanceDateRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override AttendanceDate Add(AttendanceDate entity)
		{
			entity.Active = true;
			entity = context.AttendanceDates.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AttendanceDate> AddAsync(AttendanceDate entity)
		{
			entity.Active = true;
			entity = context.AttendanceDates.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AttendanceDate Delete(AttendanceDate entity)
		{
			context.AttendanceDates.Attach(entity);
			entity = context.AttendanceDates.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AttendanceDate> DeleteAsync(AttendanceDate entity)
		{
			context.AttendanceDates.Attach(entity);
			entity = context.AttendanceDates.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AttendanceDate Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AttendanceDates.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AttendanceDate> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.AttendanceDates.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override AttendanceDate FindById(int key)
		{
			var entity = context.AttendanceDates.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override AttendanceDate FindActiveById(int key)
		{
			var entity = context.AttendanceDates.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<AttendanceDate> FindByIdAsync(int key)
		{
			var entity = await context.AttendanceDates.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<AttendanceDate> FindActiveByIdAsync(int key)
		{
			var entity = await context.AttendanceDates.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override AttendanceDate FindByIdInclude<TProperty>(int key, params Expression<Func<AttendanceDate, TProperty>>[] members)
		{
			IQueryable<AttendanceDate> dbSet = context.AttendanceDates;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<AttendanceDate> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<AttendanceDate, TProperty>>[] members)
		{
			IQueryable<AttendanceDate> dbSet = context.AttendanceDates;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
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
			return context.AttendanceDates.Where(e => e.Active);
		}
		
		public override IQueryable<AttendanceDate> GetActive(Expression<Func<AttendanceDate, bool>> expr)
		{
			return context.AttendanceDates.Where(e => e.Active).Where(expr);
		}
		
		public override AttendanceDate FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override AttendanceDate FirstOrDefault(Expression<Func<AttendanceDate, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<AttendanceDate> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<AttendanceDate> FirstOrDefaultAsync(Expression<Func<AttendanceDate, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override AttendanceDate SingleOrDefault(Expression<Func<AttendanceDate, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<AttendanceDate> SingleOrDefaultAsync(Expression<Func<AttendanceDate, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override AttendanceDate Update(AttendanceDate entity)
		{
			entity = context.AttendanceDates.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<AttendanceDate> UpdateAsync(AttendanceDate entity)
		{
			entity = context.AttendanceDates.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
