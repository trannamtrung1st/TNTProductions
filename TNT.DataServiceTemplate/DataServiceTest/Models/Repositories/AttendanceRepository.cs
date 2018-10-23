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
		public AttendanceRepository() : base()
		{
		}
		
		public AttendanceRepository(IUnitOfWork uow) : base(uow)
		{
		}
		
		#region CRUD Area
		public override Attendance Add(Attendance entity)
		{
			entity.Active = true;
			entity = context.Attendances.Add(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Attendance> AddAsync(Attendance entity)
		{
			entity.Active = true;
			entity = context.Attendances.Add(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Attendance Delete(Attendance entity)
		{
			context.Attendances.Attach(entity);
			entity = context.Attendances.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Attendance> DeleteAsync(Attendance entity)
		{
			context.Attendances.Attach(entity);
			entity = context.Attendances.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Attendance Delete(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Attendances.Remove(entity);
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Attendance> DeleteAsync(int key)
		{
			var entity = FindById(key);
			if (entity!=null)
				entity = context.Attendances.Remove(entity);
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		
		public override Attendance FindById(int key)
		{
			var entity = context.Attendances.FirstOrDefault(
				e => e.Id == key);
			return entity;
		}
		
		public override Attendance FindActiveById(int key)
		{
			var entity = context.Attendances.FirstOrDefault(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override async Task<Attendance> FindByIdAsync(int key)
		{
			var entity = await context.Attendances.FirstOrDefaultAsync(
				e => e.Id == key);
			return entity;
		}
		
		public override async Task<Attendance> FindActiveByIdAsync(int key)
		{
			var entity = await context.Attendances.FirstOrDefaultAsync(
				e => e.Id == key && e.Active);
			return entity;
		}
		
		public override Attendance FindByIdInclude<TProperty>(int key, params Expression<Func<Attendance, TProperty>>[] members)
		{
			IQueryable<Attendance> dbSet = context.Attendances;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return dbSet.FirstOrDefault(
				e => e.Id == key);
		}
		
		public override async Task<Attendance> FindByIdIncludeAsync<TProperty>(int key, params Expression<Func<Attendance, TProperty>>[] members)
		{
			IQueryable<Attendance> dbSet = context.Attendances;
			foreach (var m in members)
			{
				dbSet = dbSet.Include(m);
			}
			
			return await dbSet.FirstOrDefaultAsync(
				e => e.Id == key);
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
			return context.Attendances.Where(e => e.Active);
		}
		
		public override IQueryable<Attendance> GetActive(Expression<Func<Attendance, bool>> expr)
		{
			return context.Attendances.Where(e => e.Active).Where(expr);
		}
		
		public override Attendance FirstOrDefault()
		{
			return GetActive().FirstOrDefault();
		}
		
		public override Attendance FirstOrDefault(Expression<Func<Attendance, bool>> expr)
		{
			return GetActive().FirstOrDefault(expr);
		}
		
		public override async Task<Attendance> FirstOrDefaultAsync()
		{
			return await GetActive().FirstOrDefaultAsync();
		}
		
		public override async Task<Attendance> FirstOrDefaultAsync(Expression<Func<Attendance, bool>> expr)
		{
			return await GetActive().FirstOrDefaultAsync(expr);
		}
		
		public override Attendance SingleOrDefault(Expression<Func<Attendance, bool>> expr)
		{
			return GetActive().SingleOrDefault(expr);
		}
		
		public override async Task<Attendance> SingleOrDefaultAsync(Expression<Func<Attendance, bool>> expr)
		{
			return await GetActive().SingleOrDefaultAsync(expr);
		}
		
		public override Attendance Update(Attendance entity)
		{
			entity = context.Attendances.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				context.SaveChanges();
			return entity;
		}
		
		public override async Task<Attendance> UpdateAsync(Attendance entity)
		{
			entity = context.Attendances.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			if (AutoSave)
				await context.SaveChangesAsync();
			return entity;
		}
		#endregion
		
	}
}
